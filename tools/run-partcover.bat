rmdir /S /Q %~dp0..\reports\coverage
mkdir %~dp0..\reports\coverage
call %~dp0partcover.bat --target %~dp0run-unittests.bat --include [Syntan]* --output %~dp0..\reports\coverage\data.xml
call %~dp0reportgenerator.bat %~dp0..\reports\coverage\data.xml %~dp0..\reports\coverage\
del partcover.driver.log
