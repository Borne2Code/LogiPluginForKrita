from krita import *
from PyQt5.QtCore import QTimer
from PyQt5.QtWidgets import QApplication, QPushButton
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

class DialogData:
    dialog: object
    config: object

class LoopedeckApiServer(Extension):
    authorizedActions = {
        'Delete': AuthorizedAction.new(True, None, None), # Delete instance
        'Execute': AuthorizedAction.new(True, True, False), # Execute method
        'GetDialog': AuthorizedAction.new(None, None, True), # Open dialog dialog
        'GetModalDialog': AuthorizedAction.new(None, None, True), # Open dialog dialog
        'SetDialogAngle': AuthorizedAction.new(True, None, True), # Set dialog angle selector value
        'ClickDialogButton': AuthorizedAction.new(True, None, True), # Click on dialog button, radio or checkbox
        'SetDialogComboSelect': AuthorizedAction.new(True, None, True), # Select dialog combo box selected index
        'SetDialogSpinboxIntValue': AuthorizedAction.new(True, None, True), # Set dialog spinbox int value
        'SetDialogSpinboxFloatValue': AuthorizedAction.new(True, None, True), # Set dialog spinbox float value
        'ClickMainDialogButton': AuthorizedAction.new(True, None, True), # Click on main dialog button, radio or checkbox
    }

    def __init__(self, parent):
        # This is initialising the parent, always important when subclassing.
        super().__init__(parent)

    def parseRequest(self, msg):
        request = json.loads(msg)
                
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

    def getObjectByName(self, objectName):
        match objectName:
            case "kritaInstance":
                return Krita.instance()
            case 'currentCanvas':
                return Krita.instance().activeWindow().activeView().canvas()
            case 'currentView':
                return Krita.instance().activeWindow().activeView()
            case 'currentDocument':
                return Krita.instance().activeDocument()
            case 'currentNode':
                return Krita.instance().activeDocument().activeNode()
            case 'currentSelection':
                return Krita.instance().activeDocument().selection()
            case 'globalSelectionNode':
                node = Krita.instance().activeDocument().rootNode().childNodes()[-1]
                if node.type() == 'selectionmask':
                    return node
                else:
                    return None
            case _:
                return self.worker.objects[objectName]

    def getObject(self, request):
        if 'object' in request:
            objectName = request["object"]
            return objectName, self.getObjectByName(objectName)
        else:
            return None, None


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
                        parametersArray.append(self.getObjectByName(str(param["value"])))

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

    def isInteger(self, value):
        if value[0] == "-":
            value = value[slice(1, len(value))]
        return value.isnumeric()

    def child(self, parentWidget, childName):
        if self.isInteger(childName):
            childIndex = int(childName)
            if childIndex < 0:
                childIndex = len(parentWidget.children()) + childIndex
            return parentWidget.children()[childIndex]
        else:
            filteredChildren = list(filter(lambda w: w.objectName() == childName, parentWidget.children()))
            if len(filteredChildren) == 0:
                return None
            else:
                return filteredChildren[0]

    @pyqtSlot(str)
    def computeMessage(self, msg):
        try:
            action, objectName, objectInstance, method, parameters = self.parseRequest(msg)

            if action == "Execute":
                parametersString = ", ".join(map(lambda obj: str(obj), parameters))
                QtCore.qDebug(f"Execute method: {type(objectInstance).__name__}.{method.__name__}({parametersString})")
                if method.__name__ == "trigger" and objectInstance.objectName() == "layer_properties":
                    returnValue = None
                    QTimer.singleShot(0, method)
                else:
                    returnValue = method(*parameters)
                self.computeResponse(returnValue)
                self.worker.result = True
            elif action == "Delete":
                QtCore.qDebug(f"Delete instance {objectName} of type {type(objectInstance).__name__}")
                self.worker.objects.pop(objectName, None)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "GetDialog":
                QtCore.qDebug(f"Get dialog configuration widget")
                dialogData = DialogData()
                #try QApplication.activeWindow()
                dialogData.dialog = self.child(Krita.instance().activeWindow().qwindow(), "FilterDialog")
                widget = dialogData.dialog
                for param in parameters:
                    widget = self.child(widget, param)
                dialogData.config = widget

                if (dialogData.config is not None):
                    key = str(uuid.uuid4())
                    self.worker.objects[key] = dialogData
                    self.worker.returnValue = key
                    self.worker.returnType = type(dialogData.config).__name__
                    self.worker.result = True
                else:
                    self.worker.returnType = "None"
                    self.worker.returnValue = None
                    self.worker.result = False
            elif action == "GetModalDialog":
                QtCore.qDebug(f"Get modal dialog configuration widget")
                dialogData = DialogData()
                dialogData.dialog = QApplication.activeModalWidget()
                widget = dialogData.dialog
                for param in parameters:
                    widget = self.child(widget, param)
                dialogData.config = widget

                if (dialogData.config is not None):
                    key = str(uuid.uuid4())
                    self.worker.objects[key] = dialogData
                    self.worker.returnValue = key
                    self.worker.returnType = type(dialogData.config).__name__
                    self.worker.result = True
                else:
                    self.worker.returnType = "None"
                    self.worker.returnValue = None
                    self.worker.result = False
            elif action == "SetDialogSpinboxIntValue":
                QtCore.qDebug(f"Change dialog configuration int spinBox")
                widget = objectInstance.config
                value = int(parameters[0])
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                newValue = widget.value() + value
                widget.setValue(newValue)
                newValue = widget.value()
                self.computeResponse(newValue)
                self.worker.result = True
            elif action == "SetDialogSpinboxFloatValue":
                QtCore.qDebug(f"Change dialog configuration float spinBox")
                widget = objectInstance.config
                value = float(parameters[0])
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                newValue = widget.value() + value
                widget.setValue(newValue)
                newValue = widget.value()
                self.computeResponse(newValue)
                self.worker.result = True
            elif action == "SetDialogAngle":
                QtCore.qDebug(f"Change dialog configuration angle")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                newValue = widget.children()[1].value() + value
                widget.children()[1].setValue(newValue)
                self.computeResponse(newValue)
                self.worker.result = True
            elif action == "SetDialogComboSelect":
                QtCore.qDebug(f"Change dialog configuration combo box")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                widget.setCurrentIndex(value)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "ClickDialogButton":
                QtCore.qDebug(f"Click dialog configuration widget")
                widget = objectInstance.config
                for param in parameters:
                    widget = self.child(widget, param)
                widget.click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            elif action == "ClickMainDialogButton":
                QtCore.qDebug(f"Click main dialog button")
                widget = objectInstance.dialog
                for param in parameters:
                    widget = self.child(widget, param)
                if widget!= None:
                    widget.click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = True
            else:
                QtCore.qDebug(f"Error: action '{action}' is unkonwn.")
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
        pass

# And add the extension to Krita's list of extensions:
Krita.instance().addExtension(LoopedeckApiServer(Krita.instance()))
