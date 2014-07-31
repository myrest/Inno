@echo off
cls

rem iisweb /stop Inno
C:\Windows\System32\inetsrv\appcmd stop site /site.name:inno
echo.
echo After your deployment, please press any key to star up service.
pause
rem iisweb /start Inno
C:\Windows\System32\inetsrv\appcmd start site /site.name:inno
Goto %End

:Error
echo.
echo *****************************************
echo ************ GOT ERROR ******************
echo *****************************************
Goto %DONE

:End
echo.
echo Restart Web site done.
Goto %DONE

:DONE
PAUSE
