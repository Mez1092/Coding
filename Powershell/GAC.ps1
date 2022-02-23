#List DLL GAC

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\gacutil.exe" /l > "C:\TEMP\GAC.txt"


#Note that you should be running PowerShell as an Administrator
[System.Reflection.Assembly]::Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
$publish = New-Object System.EnterpriseServices.Internal.Publish
$publish.GacInstall("C:\Path\To\DLL.dll")