@echo off
SET PhpStormPath=C:\Program Files\JetBrains\PhpStorm 2017.1.1\bin\PhpStorm64.exe
 
echo Adding folder entries
@reg add "HKEY_CLASSES_ROOT\Directory\shell\Open directory in PhpStorm" /t REG_SZ /v "" /d "Open directory in PhpStorm"   /f
@reg add "HKEY_CLASSES_ROOT\Directory\shell\Open directory in PhpStorm" /t REG_EXPAND_SZ /v "Icon" /d "%PhpStormPath%,0" /f
@reg add "HKEY_CLASSES_ROOT\Directory\shell\Open directory in PhpStorm\command" /t REG_SZ /v "" /d "%PhpStormPath% \"%%1\"" /f

pause