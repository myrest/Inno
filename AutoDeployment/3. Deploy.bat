@echo off
cls
set TargetFolder=D:\InnoWebRoot
set TemplateFolder=D:\InnoSystem\Deploy
set ZipExeFullPath="C:\Program Files\7-Zip\7z.exe"
set ArchiveFileName=Publish.zip

set FolderName=%TemplateFolder%\%DATE:~0,4%%DATE:~5,2%%DATE:~8,2%_%Time:~0,2%%Time:~3,2%

IF exist "%FolderName%" ( 
	echo.
	echo Temp folder %FolderName% is exists.
	echo If you want deploy again, please clear the existing files.
	goto %Error
) ELSE ( 
	%ZipExeFullPath% x %ArchiveFileName% -y -o%FolderName%
	echo Remove Configuration folder
	rmdir %FolderName%\Configuration /S/Q > nul
	xcopy %FolderName% %TargetFolder% /S/Q/Y > nul
	goto %End
)

:Error
echo.
echo *****************************************
echo ************ GOT ERROR ******************
echo *****************************************
Goto %DONE

:End
echo.
echo Extra files from archive file into temp folder done.
echo Folder full path
echo %FolderName%
Goto %DONE

:DONE
PAUSE
