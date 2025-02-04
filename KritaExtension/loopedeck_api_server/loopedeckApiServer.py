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
                # QtCore.qDebug(str(msg))

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

class AuthorizedAction:
    objectIsMandatory: bool #True: mandatory, False: optional, None: forbidden
    methodIsMandatory: bool
    parametersIsMandatory: bool

    def new(objectIsMandatory, methodIsMandatory, parametersIsMandatory):
        instance = AuthorizedAction()
        instance.objectIsMandatory = objectIsMandatory
        instance.methodIsMandatory = methodIsMandatory
        instance.parametersIsMandatory = parametersIsMandatory
        return instance

class FilterData:
    dialog: object
    config: object

class LoopedeckApiServer(Extension):
    authorizedActions = {
        'D': AuthorizedAction.new(True, None, None), # Delete instance
        'E': AuthorizedAction.new(True, True, False), # Execute method
        'F': AuthorizedAction.new(None, None, None), # Open filter dialog
        'FA': AuthorizedAction.new(True, None, True), # Set filter angle selector value
        'FB': AuthorizedAction.new(True, None, True), # Click on filter button, radio or checkbox
        'FC': AuthorizedAction.new(True, None, True), # Select filter combo box selected index
        'FI': AuthorizedAction.new(True, None, True), # Set filter spinbox int value
        'FF': AuthorizedAction.new(True, None, True), # Set filter spinbox float value
        'FO': AuthorizedAction.new(True, None, None), # Validate filter dialog
        'FK': AuthorizedAction.new(True, None, None) # Cancel filter dialog
    }

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
        if action not in self.authorizedActions.keys(): raise ValueError(f"action mst be an authorized value: {str(self.authorizedActions.keys())}")

        authorizedAction = self.authorizedActions[action]

        if 'object' not in request and authorizedAction.objectIsMandatory == True: raise ValueError("object is mandatory in the request")
        if 'object' in request and authorizedAction.objectIsMandatory == None: raise ValueError("object is forbidden in the request")
        if 'method' not in request and authorizedAction.methodIsMandatory == True: raise ValueError("method is mandatory in the request")
        if 'method' in request and authorizedAction.methodIsMandatory == None: raise ValueError("method is forbidden in the request")
        if 'parameters' not in request and authorizedAction.parametersIsMandatory == True: raise ValueError("parameters is mandatory in the request")
        if 'parameters' in request and authorizedAction.parametersIsMandatory == None: raise ValueError("parameters is forbidden in the request")

        objectName, objectInstance = self.getObject(request)
        method = self.getMethod(objectInstance, request)
        parameters = self.parseParameters(request)

        return action, objectName, objectInstance, method, parameters

    def getObject(self, request):
        if 'object' in request:
            objectName = request["object"]
        else:
            return None, None

        match objectName:
            case "kritaInstance":
                return objectName, Krita.instance()
            case 'currentCanvas':
                return objectName, Krita.instance().activeWindow().activeView().canvas()
            case 'currentView':
                return objectName, Krita.instance().activeWindow().activeView()
            case 'currentDocument':
                return objectName, Krita.instance().activeDocument()
            case 'currentNode':
                return objectName, Krita.instance().activeDocument().activeNode()
            case _:
                return objectName, self.worker.objects[objectName]

    def getMethod(self, object, request):
        if 'method' in request:
            methodName = request["method"]
        else:
            return None

        return getattr(object, methodName)
        
    def parseParameters(self, request):
        parametersArray = []

        if 'parameters' in request:
            parameters = request["parameters"]
        else:
            return parametersArray
        
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

    def child(self, parentWidget, childName):
        filteredChildren = list(filter(lambda w: w.objectName() == childName, parentWidget.children()))
        if len(filteredChildren) == 0:
            return None
        else:
            return filteredChildren[0]

    @pyqtSlot(str)
    def computeMessage(self, msg):
        try:
            action, objectName, objectInstance, method, parameters = self.parseRequest(msg)

            if action == "E":
                parametersString = ", ".join(map(lambda obj: str(obj), parameters))
                QtCore.qDebug(f"Execute method: {type(objectInstance).__name__}.{method.__name__}({parametersString})")
                returnValue = method(*parameters)
                self.computeResponse(returnValue)
                self.worker.result = True
            elif action == "D":
                QtCore.qDebug(f"Delete instance {objectName} of type {type(objectInstance).__name__}")
                self.worker.objects.pop(objectName, None)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "F":
                QtCore.qDebug(f"Get filter configuration widget")
                filterData = FilterData()
                filterData.dialog = self.child(Krita.instance().activeWindow().qwindow(), "FilterDialog")
                filterData.config = filterData.dialog.children()[1].children()[-1].children()[0].children()[0].children()[1].children()[1]
                if (filterData.config is not None):
                    key = str(uuid.uuid4())
                    self.worker.objects[key] = filterData
                    self.worker.returnValue = key
                    self.worker.returnType = type(filterData.config).__name__
                    self.worker.result = True
                else:
                    self.worker.returnType = "None"
                    self.worker.returnValue = None
                    self.worker.result = False
            elif action == "FI":
                QtCore.qDebug(f"Change filter configuration spinBox")
                widget = objectInstance.config
                value = int(parameters[0])
                for param in parameters[slice(1, 500)]:
                    widget = self.child(widget, param)
                newValue = widget.value() + value
                widget.setValue(newValue)
                newValue = widget.value()
                self.computeResponse(newValue)
                self.worker.result = True
            elif action == "FF":
                QtCore.qDebug(f"Change filter configuration spinBox")
                widget = objectInstance.config
                value = float(parameters[0])
                for param in parameters[slice(1, 500)]:
                    widget = self.child(widget, param)
                newValue = widget.value() + value
                widget.setValue(newValue)
                newValue = widget.value()
                self.computeResponse(newValue)
                self.worker.result = True
            elif action == "FA":
                QtCore.qDebug(f"Change filter configuration angle")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, 500)]:
                    widget = self.child(widget, param)
                widget.children()[1].setValue(value)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "FC":
                QtCore.qDebug(f"Change filter configuration combo box")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, 500)]:
                    widget = self.child(widget, param)
                widget.setCurrentIndex(value)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "FB":
                QtCore.qDebug(f"Click filter configuration widget")
                widget = objectInstance.config
                for param in parameters:
                    widget = self.child(widget, param)
                widget.click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "FO":
                QtCore.qDebug(f"Validate filter")
                widget = objectInstance.dialog
                widget = self.child(widget, "buttonBox")
                widget.children()[1].click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "FK":
                QtCore.qDebug(f"Cancel filter")
                widget = objectInstance.dialog
                widget = self.child(widget, "buttonBox")
                widget.children()[2].click()
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
