from krita import *
import sys
import socket
import time
import json
import uuid

class Server(QObject):
    message = pyqtSignal(str)
    objects = {}
    returnValue = None
    result = None

    def __init__(self):
        super().__init__()
        self.__abort = False
      
    def prepareResponse(self):
        if self.result:
            return json.dumps({"result": "OK", "returnType": self.returnType, "returnValue": self.returnValue}).encode(encoding="utf-8")
        else:
            return json.dumps({"result": "KO", "error": str(self.returnValue)}).encode(encoding="utf-8")

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
                QtCore.qDebug(str(msg))

                if not msg:
                    connected = False
                    self.objects = {} #clean objects cache
                    QtCore.qDebug('Connection closed')
                else:
                    try:
                        self.returnValue = None
                        self.result = None

                        self.message.emit(str(msg))
                    
                        while self.result == None:
                            time.sleep(0.01)
                    
                        c.send(self.prepareResponse())
                    except Exception as ex:
                        QtCore.qDebug('Error: ' + str(ex))

class LoopedeckApiServer(Extension):
    def __init__(self, parent):
        # This is initialising the parent, always important when subclassing.
        super().__init__(parent)

    def parseRequest(self, msg):
        request = json.loads(msg)
        
        # Execute method
        # {
        #   action: "E"
        #   object: "Primitive Name or Reference",
        #   method: xxxx,
        #   parameters: [
        #     {
        #       type: int|float|str,
        #       value: xxxx
        #     }
        #   ]
        #   serilizeResult: bool, // If true, no reference stored, but result is serialized
        # }

        # Get object reference
        # {
        #   action: "G"
        #   object: "Primitive Name"
        # }

        # Delete reference
        # {
        #   action: "D"
        #   object: "reference"
        # }
        
        if 'action' not in request: raise ValueError("action is mandatory in the request")
        action = request["action"]

        if 'object' not in request: raise ValueError("object is mandatory in the request")
        objectName = request["object"]
        objectInstance = self.getObject(objectName)

        if 'method' in request:
            methodName = request["method"]
            method = self.getMethod(objectInstance, methodName)
        else:
            method = None

        if 'parameters' in request:
            parameters = self.parseParameters(request["parameters"])
        else:
            parameters = []

        return action, objectName, method, parameters

    def getObject(self, objectName):
        match objectName:
            case "kritaInstance":
                return Krita.instance()
            case 'currentCanvas':
                return Krita.instance().activeWindow().activeView().canvas()
            case 'currentDocument':
                return Krita.instance().activeDocument()
            case _:
                return self.worker.objects[objectName]

    def getMethod(self, object, functionName):
        return getattr(object, functionName)
        
    def parseParameters(self, parameters):
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
                    case "bool":
                        parametersArray.append(bool(param["value"]))
                    case _:
                        parametersArray.append(self.worker.objects[str(param["value"])])

        return parametersArray

    def computeResponse(self, returnValue):
        match type(returnValue).__name__:
            case "str":
                self.worker.returnType = "str"
                self.worker.returnValue = returnValue
            case "int":
                self.worker.returnType = "int"
                self.worker.returnValue = returnValue
            case "float":
                self.worker.returnType = "float"
                self.worker.returnValue = returnValue
            case "bool":
                self.worker.returnType = "bool"
                self.worker.returnValue = returnValue
            case "list":
                self.worker.returnType = "list"
                if len(returnValue) == 0 or type(returnValue[0]).__name__ == "str":
                    self.worker.returnValue = returnValue
                elif getattr(returnValue[0], "objectName", None) != None:
                    self.worker.returnValue = list(map(lambda val: getattr(val, "objectName")(), returnValue))
                else:
                    self.worker.returnValue = list(map(lambda val: str(val), returnValue))
            case "NoneType":
                self.worker.returnType = "None"
                self.worker.returnValue = None
            case _:
                typeName = type(returnValue).__name__
                if typeName == "QWidgetAction": typeName = "QAction"
                self.worker.returnType = typeName
                key = str(uuid.uuid4())
                self.worker.objects[key] = returnValue
                self.worker.returnValue = key

    @pyqtSlot(str)
    def computeMessage(self, msg):
        try:
            action, objectName, method, parameters = self.parseRequest(msg)

            if action == "E":
                parametersString = ", ".join(map(lambda obj: str(obj), parameters))
                QtCore.qDebug(f"Execute method: {objectName}.{method.__name__}({parametersString})")
                returnValue = method(*parameters)
                self.computeResponse(returnValue)
                self.worker.result = True
            elif action == "D":
                QtCore.qDebug(f"Delete instance: {objectName}")
                self.worker.objects.pop(objectName, None)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
        except Exception as ex:
            QtCore.qDebug(f"Error: [{type(ex).__name__}] {str(ex)}")
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
