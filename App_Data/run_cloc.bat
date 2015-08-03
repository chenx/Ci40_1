@echo off
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
echo Today is: %mydate%
echo.

cloc c:\inetpub\wwwroot\Ci40_1 --exclude-list-file=cloc_exclude_list.txt -out=cloc_log\short_%mydate%.txt 
cloc c:\inetpub\wwwroot\Ci40_1 --exclude-list-file=cloc_exclude_list.txt -out=cloc_log\short_%mydate%.csv --csv

cloc c:\inetpub\wwwroot\Ci40_1 --exclude-list-file=cloc_exclude_list.txt --by-file -out=cloc_log\long_%mydate%.txt 
cloc c:\inetpub\wwwroot\Ci40_1 --exclude-list-file=cloc_exclude_list.txt --by-file -out=cloc_log\long_%mydate%.csv --csv