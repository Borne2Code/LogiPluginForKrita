from krita import *
from PyQt5.QtCore import QTimer
from PyQt5.QtWidgets import QApplication, QPushButton
import datetime
import os
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
    security_token = None

    def __init__(self):
        super().__init__()
        self.__abort = False
      
    def prepareResponse(self):
        if self.result == "OK":
            return json.dumps({"result": "OK", "returnType": self.returnType, "returnValue": self.returnValue}).encode(encoding="utf-8")
        elif self.result == "Error":
            QtCore.qDebug("error: " + str(self.returnValue))
            return json.dumps({"result": "KO", "error": str(self.returnValue)}).encode(encoding="utf-8")
        elif self.result == "SEC":
            QtCore.qDebug('Invalid security Token: the connection will be closed')
            return json.dumps({"result": "KO", "error": "Invalid security token, connection will be closed"}).encode(encoding="utf-8")

    def getSecurityToken(self):
        try:
            filePath = f"{os.getenv('APPDATA')}/Krita/pykrita/logi_api_server/security_token"
            print(filePath)
            with open(filePath, "r", encoding="utf-8") as file:
                for line in file:
                    self.security_token = line
            os.remove(filePath)
        except Exception as ex:
            QtCore.qDebug('Error occurred while reading security token: ' + str(ex))
            return False

        return True

    def initializationConnection(self, connection):
        try:
            msg = connection.recv(1026).decode(encoding="utf-8")
            jsonMessage = json.loads(msg)

            if jsonMessage.get("action", None) == "Initialize":
                if self.checkSecurityToken(jsonMessage):
                    self.result = "OK"
                    self.returnType = "bool"
                    self.returnValue = True
                    connection.send(self.prepareResponse())
                    return True
                else:
                    self.result = "SEC"
                    connection.send(self.prepareResponse())
                    return False
            else:
                self.result = "Error"
                self.returnValue = "Invalid initialization message, the connection will be closed"
                connection.send(self.prepareResponse())
                return False
        except Exception as ex:
            QtCore.qDebug('Error occurred: ' + str(ex))
            return None

    def checkSecurityToken(self, jsonMessage):
        clientToken = jsonMessage.get("securityToken", None)
        return self.security_token != None and self.security_token == clientToken

    def run(self):
        s = socket.socket()
        host = socket.gethostname()
        port = 1247
        QtCore.qDebug("starting Logi plugin...")
        time.sleep(3)
        s.bind(("127.0.0.1", port))
        QtCore.qDebug("Server started on " + host)
        s.listen(1)
        while True:
            QtCore.qDebug("listen started, waiting for connection...")
            c, addr = s.accept()

            if self.getSecurityToken() and self.initializationConnection(c):
                QtCore.qDebug("Connection accepted from " + repr(addr[1]))
                connected = True
            else:
                connected = False
                c.close()

            while connected:
                try:
                    msg = c.recv(1026).decode(encoding="utf-8")
                except:
                    QtCore.qDebug('Error receiving message: ' + str(ex))
                    msg = None
                # QtCore.qDebug(str(msg))

                if not msg:
                    QtCore.qDebug('Connection closed')
                    connected = False
                    self.objects = {} #clean objects cache
                else:
                    self.returnValue = None
                    self.result = None

                    if self.checkSecurityToken(json.loads(msg)):
                        self.message.emit(str(msg))

                        timeoutDateTime = datetime.datetime.now() + datetime.timedelta(seconds=5)
                        while self.result == None and datetime.datetime.now() < timeoutDateTime:
                            time.sleep(0.001)

                        if self.result == None:
                            self.result = "Error"
                            self.returnValue = "Timeout waiting message computing"
                    else:
                        self.result = "SEC"
                    
                    try:
                        c.send(self.prepareResponse())

                        if self.result == "SEC":
                            c.close()
                            connected = False
                    except Exception as ex:
                        QtCore.qDebug('Error sending message: ' + str(ex))
                        c.close()
                        connected = False

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

class ObjectAuthorizedMethods:
    authorizedMethods: list[str]

    def new(authorizedMethods):
        instance = ObjectAuthorizedMethods()
        instance.authorizedMethods = authorizedMethods
        return instance

class DialogData:
    dialog: object
    config: object

class LogiApiServer(Extension):
    authorizedActions = {
        'Delete': AuthorizedAction.new(True, None, None), # Delete instance
        'Execute': AuthorizedAction.new(True, True, False), # Execute method
        'ExecuteAction': AuthorizedAction.new(None, None, True), # Execute a Krita Action
        'GetDialog': AuthorizedAction.new(None, None, True), # Open dialog dialog
        'GetModalDialog': AuthorizedAction.new(None, None, True), # Open dialog dialog
        'SetDialogAngle': AuthorizedAction.new(True, None, True), # Set dialog angle selector value
        'ClickDialogButton': AuthorizedAction.new(True, None, True), # Click on dialog button, radio or checkbox
        'SetDialogComboSelect': AuthorizedAction.new(True, None, True), # Select dialog combo box selected index
        'SetDialogSpinboxIntValue': AuthorizedAction.new(True, None, True), # Set dialog spinbox int value
        'SetDialogSpinboxFloatValue': AuthorizedAction.new(True, None, True), # Set dialog spinbox float value
        'ClickMainDialogButton': AuthorizedAction.new(True, None, True), # Click on main dialog button, radio or checkbox
    }

    objectsAuthorizedMethods = {
        'Canvas': ObjectAuthorizedMethods.new(['resetRotation', 'resetZoom', 'rotation', 'setRotation', 'setZoomLevel', 'zoomLevel']),
        'Document': ObjectAuthorizedMethods.new(['activeNode', 'resolution', 'refreshProjection', 'setActiveNode', ]),
        'Filter': ObjectAuthorizedMethods.new(['name']),
        'Krita': ObjectAuthorizedMethods.new(['action']),
        'Node': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'PaintLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'VectorLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'FillLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'FilterLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'FilterMask': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'TransparencyMask': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'TransformMask': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'CloneLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'FileLayer': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'ColorizeMask': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'NewLocalSelection': ObjectAuthorizedMethods.new(['type', 'opacity', 'setOpacity', 'filter']),
        'QAction': ObjectAuthorizedMethods.new(['trigger']),
        'QWidgetAction': ObjectAuthorizedMethods.new(['trigger']),
        'Selection': ObjectAuthorizedMethods.new(['grow', 'shrink']),
        'View': ObjectAuthorizedMethods.new(['brushSize', 'setBrushSize', 'brushRotation', 'setBrushRotation', 'paintingFlow', 'setPaintingFlow', 'paintingOpacity', 'setPaintingOpacity', 'patternSize', 'setPatternSize'])
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
        if objectInstance != None:
            method = self.getMethod(objectInstance, request)
        else:
            method = None

        parameters = self.parseParameters(request)

        return action, objectName, objectInstance, method, parameters

    def getObjectByName(self, objectName):
        try:
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
        except:
            return None

    def getObject(self, request):
        if 'object' in request:
            objectName = request["object"]
            return objectName, self.getObjectByName(objectName)
        else:
            return None, None


    def getMethod(self, object, request):
        authorizedMethods = self.objectsAuthorizedMethods.get(type(object).__name__, None)
        if 'method' in request and authorizedMethods and request["method"] in authorizedMethods.authorizedMethods:
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
                if method == None:
                    QtCore.qDebug(f"Not allowed method call: {type(objectInstance).__name__}.{method.__name__}")
                    self.worker.result = "SEC"
                else:
                    QtCore.qDebug(f"Execute method: {type(objectInstance).__name__}.{method.__name__}({parametersString})")
                    if method.__name__ == "trigger" and (objectInstance.objectName() == "layer_properties" or objectInstance.objectName() == "layer_style"):
                        #Blocking calls are executed in separated thread
                        returnValue = None
                        QTimer.singleShot(0, method)
                    else:
                        returnValue = method(*parameters)
                    self.computeResponse(returnValue)
                    self.worker.result = "OK"
            elif action == "ExecuteAction":
                actionName = parameters[0]
                QtCore.qDebug(f"Execute Krita action: {actionName}")
                action = Krita.instance().action(actionName)
                if action is not None:
                    if actionName == "layer_properties" or actionName == "layer_style":
                        #Blocking calls are executed in separated thread
                        returnValue = None
                        QTimer.singleShot(0, action.trigger)
                    else:
                        returnValue = action.trigger()

                    self.worker.returnType = "None"
                    self.worker.returnValue = None
                    self.worker.result = "OK"
                else:
                    self.worker.returnType = "Error"
                    self.worker.returnValue = f"Krita action '{actionName}' not found"
                    self.worker.result = "Error"
            elif action == "Delete":
                QtCore.qDebug(f"Delete instance {objectName} of type {type(objectInstance).__name__}")
                self.worker.objects.pop(objectName, None)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = "OK"
            elif action == "GetDialog":
                QtCore.qDebug(f"Get dialog configuration widget")
                dialogData = DialogData()
                #try QApplication.activeWindow()
                dialogData.dialog = QApplication.activeWindow()
                widget = dialogData.dialog
                for param in parameters:
                    widget = self.child(widget, param)
                dialogData.config = widget

                if (dialogData.config is not None):
                    key = str(uuid.uuid4())
                    self.worker.objects[key] = dialogData
                    self.worker.returnValue = key
                    self.worker.returnType = type(dialogData.config).__name__
                    self.worker.result = "OK"
                else:
                    self.worker.returnType = "Error"
                    self.worker.returnValue = "Dialog is not open"
                    self.worker.result = "Error"
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
                    self.worker.result = "OK"
                else:
                    self.worker.returnType = "Error"
                    self.worker.returnValue = "Modal dialog is not open"
                    self.worker.result = "Error"
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
                self.worker.result = "OK"
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
                self.worker.result = "OK"
            elif action == "SetDialogAngle":
                QtCore.qDebug(f"Change dialog configuration angle")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                newValue = widget.children()[1].value() + value
                widget.children()[1].setValue(newValue)
                self.computeResponse(newValue)
                self.worker.result = "OK"
            elif action == "SetDialogComboSelect":
                QtCore.qDebug(f"Change dialog configuration combo box")
                widget = objectInstance.config
                value = parameters[0]
                for param in parameters[slice(1, len(parameters))]:
                    widget = self.child(widget, param)
                widget.setCurrentIndex(value)
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = "OK"
            elif action == "ClickDialogButton":
                QtCore.qDebug(f"Click dialog configuration widget")
                widget = objectInstance.config
                for param in parameters:
                    widget = self.child(widget, param)
                widget.click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = "OK"
            elif action == "ClickMainDialogButton":
                QtCore.qDebug(f"Click main dialog button")
                widget = objectInstance.dialog
                for param in parameters:
                    widget = self.child(widget, param)
                if widget!= None:
                    widget.click()
                self.worker.returnType = "None"
                self.worker.returnValue = None
                self.worker.result = "OK"
            else:
                QtCore.qDebug(f"Error: action '{action}' is unkonwn.")
                self.worker.returnType = "Error"
                self.worker.returnValue = "Action '{action}' is unkonwn."
                self.worker.result = "Error"
        except Exception as ex:
            QtCore.qDebug(f"Error: [{type(ex).__name__}] {str(ex)}")
            self.worker.returnValue = ex
            self.worker.result = "Error"

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
Krita.instance().addExtension(LogiApiServer(Krita.instance()))
