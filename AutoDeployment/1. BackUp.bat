@echo off
cls
set source=D:\InnoWebRoot
set backuproot=D:\InnoSystem\Backup
set FolderName=%backuproot%\%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%_%Time:~0,2%%Time:~3,2%

IF exist "%FolderName%" ( 
	echo.
	echo Back folder %FolderName% is exists.
	goto %Error
) ELSE ( 
	mkdir "%FolderName%" && echo Back folder %FolderName% created
	echo.
	echo Backup Files.......
	xcopy %source% %FolderName% /S/Q/Y > nul
	goto %END
)

:Error
echo.
echo *****************************************
echo ************ GOT ERROR ******************
echo *****************************************
Goto %DONE

:End
echo.
echo Back Up file process end
Goto %DONE

:DONE
PAUSE
