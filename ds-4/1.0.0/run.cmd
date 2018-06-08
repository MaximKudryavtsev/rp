@echo off
setlocal enabledelayedexpansion

rem Запускаем редис
for %%i in ("%~dp0\..") do set "parent=%%~fi"
for %%i in ("%parent%\..") do set "big_parent=%%~fi"
start /d %big_parent%\Redis redis-server.exe

start "Frontend"  /d Frontend dotnet Frontend.dll
start "Backend"  /d Backend dotnet Backend.dll 
start "TextRankCalc"  /d TextRankCalc dotnet TextRankCalc.dll
start "TextListener" /d TextListener dotnet TextListener.dll

start http://127.0.0.1:5001/home/upload

