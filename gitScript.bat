@echo off
set /p commitMessage=Enter Message: 
git add .
git commit -m "%commitMessage%"
git push origin master