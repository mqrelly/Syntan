rmdir /S /Q %~dp0..\reports\unittests
mkdir %~dp0..\reports\unittests
call %~dp0xunit-console.bat %~dp0..\source\Syntan.UnitTests\bin\Debug\Syntan.UnitTests.dll /noshadow /html %~dp0..\reports\unittests\report.html
