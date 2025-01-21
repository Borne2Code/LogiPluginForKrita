using LoupedeckKritaApiClient.ClientBase;

namespace LoupedeckKritaApiClient
{
    public class Filter() : LoupedeckClientKritaBaseClass
    {
        public Task Apply() => Execute("apply");
    }
}
/*
['apply'
'blockSignals'
'childEvent'
'children'
'configuration'
'connectNotify'
'customEvent'
'deleteLater'
'destroyed'
'disconnect'
'disconnectNotify'
'dumpObjectInfo'
'dumpObjectTree'
'dynamicPropertyNames'
'event'
'eventFilter'
'findChild'
'findChildren'
'inherits'
'installEventFilter'
'isSignalConnected'
'isWidgetType'
'isWindowType'
'killTimer'
'metaObject'
'moveToThread'
'name'
'objectName'
'objectNameChanged'
'parent'
'property'
'pyqtConfigure'
'receivers'
'removeEventFilter'
'sender'
'senderSignalIndex'
'setConfiguration'
'setName'
'setObjectName'
'setParent'
'setProperty'
'signalsBlocked'
'startFilter'
'startTimer'
'thread'
'timerEvent'
'tr']
 */