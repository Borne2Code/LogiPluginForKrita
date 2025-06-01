@echo off
IF "%1"=="" GOTO error
echo Building Krita_v%1.lplug4
logiplugintool pack .\KritaPlugin\bin\Release\ .\Krita_v%1.lplug4
echo Testing Krita_v%1.lplug4
logiplugintool verify ./Krita_v%1.lplug4
GOTO end

:error
echo Please give the version number as parameter. Ex: 1.0

:end