from krita import *
import sys
import socket
import time
import json

class Server(QObject):
    message = pyqtSignal(str)
    returnValue = None
    result = None

    def __init__(self):
        super().__init__()
        self.__abort = False
      
    def run(self):
        
        s = socket.socket()
        host = socket.gethostname()
        port = 1247
        s.bind(("127.0.0.1",port))
        QtCore.qDebug("Server started on " + host)
        s.listen(1)
        while True:
            c, addr = s.accept()
            QtCore.qDebug("Connection accepted from " + repr(addr[1]))
            connected = True
            while connected:
                msg = c.recv(1026).decode(encoding="utf-8")

                if not msg:
                    connected = False
                    QtCore.qDebug('Connection closed')
                else:
                    try:
                        self.returnValue = None
                        self.result = None

                        self.message.emit(str(msg))
                    
                        while self.result == None:
                            time.sleep(0.01)
                    
                        if self.result:
                            c.send(json.dumps({"result": "OK", "returnValue": self.returnValue}).encode(encoding="utf-8"))
                        else:
                            c.send(json.dumps({"result": "KO", "error": str(self.returnValue)}).encode(encoding="utf-8"))
                    except Exception as ex:
                        QtCore.qDebug('Error: ' + str(ex))

class LoopedeckApiServer(Extension):
    def __init__(self, parent):
        # This is initialising the parent, always important when subclassing.
        super().__init__(parent)

    def parseRequest(self, msg):
        request = json.loads(msg)
        
        # {
        #   context: null,
        #   object: xxxx,
        #   method: xxxx,
        #   parameters: [
        #     {
        #       type: int|str,
        #       value: xxxx
        #     }
        #   ]
        # }
        
        context = request["context"]
        objectName = request["object"]
        object = self.getObject(objectName)
        methodName = request["method"]
        method = self.getMethod(object, methodName)
        parameters = request["parameters"]

        parametersArray = []
        
        if parameters:
            for param in parameters:
                match param["type"]:
                    case "str":
                        parametersArray.append(str(param["value"]))
                    case "int":
                        parametersArray.append(int(param["value"]))
                    case "float":
                        parametersArray.append(float(param["value"]))

        parametersString = ", ".join(map(lambda obj: str(obj), parametersArray))
        QtCore.qDebug(f"[{context}]{objectName}.{methodName}({parametersString})")
        
        return context, method, parametersArray

    def getObject(self, objectName):
        match objectName:
            case 'currentCanvas':
                return Krita.instance().activeWindow().activeView().canvas()
            case 'currentDocument':
                return Krita.instance().activeDocument()

    def getMethod(self, object, functionName):
        return getattr(object, functionName)
        
    @pyqtSlot(str)
    def computeMessage(self, msg):
        try:
            context, method, parameters = self.parseRequest(msg)
            self.worker.returnValue = method(*parameters)
            self.worker.result = True
        except Exception as ex:
            QtCore.qDebug(str(ex))
            self.worker.returnValue = ex
            self.worker.result = False

    def setup(self):
        self.thread = QtCore.QThread()
        self.worker = Server()
        self.worker.moveToThread(self.thread)
        self.worker.message.connect(self.computeMessage)
        self.thread.started.connect(self.worker.run)
        self.thread.start()

    def createActions(self, window):
        action = window.createAction("", "Rotation 10")
        action.triggered.connect(self.rotation)

    def rotation(self):
        Krita.instance().activeWindow().activeView().canvas().setRotation(float(10))

        
# And add the extension to Krita's list of extensions:
Krita.instance().addExtension(LoopedeckApiServer(Krita.instance()))
