@ECHO ON

@SET ISAPIDIR="c:\program files\common files\microsoft shared\web server extensions\15\ISAPI"
@SET TEMPLATEDIR="c:\program files\common files\microsoft shared\web server extensions\15\Template"
@SET DIR14="c:\program files\common files\microsoft shared\web server extensions\15"
@SET STSADM="c:\program files\common files\microsoft shared\web server extensions\15\bin\stsadm"
@SET GACUTIL="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools\gacutil.exe"
@SET APPCMD="C:\Windows\System32\inetsrv\appcmd.exe"

@ECHO.
@ECHO Deactivating Features ...
::%STSADM% -o deactivatefeature -url http://spdev -name "" -force

::%STSADM% -o deactivatefeature -url http://spdev -name "" -force

@ECHO.
@ECHO Unisntalling Features ...
::%STSADM% -o uninstallfeature -name "" -force

@ECHO.
@ECHO Copying Features and Files ...
::xcopy /e /y /r SharePointRoot\TEMPLATE\* %TEMPLATEDIR%

::net stop sptimerv4

@ECHO.
@ECHO UnInstalling DLLs ...
%GACUTIL% -uf SP2013Branding

@ECHO.
@ECHO Installing DLLs ...
%GACUTIL% -if .\bin\debug\SP2013Branding.dll

::@ECHO Force reset because we are replacing GAC items ...
::iisreset

@ECHO.
@ECHO Recycling app pool ...
%APPCMD% recycle apppool /apppool.name:"Portal"
%APPCMD% recycle apppool /apppool.name:"SharePoint Central Administration v4"

::net start sptimerv4

@ECHO.
@ECHO Installing Features ...
::%STSADM% -o installfeature -name ""

@ECHO.
@ECHO Activating Features ...

@ECHO.
@ECHO Operation done!