# AppsFolderDialog

Provide a dialog box to select installed app from local machine.
![image](https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/26ad6a1e-3274-4ffa-80f0-2a9264a114e0)

the selected item is [Application User Model ID](https://learn.microsoft.com/en-us/windows/win32/shell/appids) ,You can run it in the following way

**Run dialog**
```
shell:appsfolder\xxx
shell:appsfolder\Microsoft.Windows.MediaPlayer32   //Windows Media Player
```

**C#**
```C#
System.Diagnostic.Process.Start("explorer.exe","shell:appsfolder\xxx");
System.Diagnostic.Process.Start("explorer.exe","shell:appsfolder\Microsoft.Windows.MediaPlayer32");  //Windows Media Player
```

**Preview**

https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/cc6bd420-8abb-48cb-b353-13f36dba4693

# Usage
```Powershell
PM>NuGet\Install-Package AppsFolderDialog -Version 0.0.1
```
```C#
AppsFolderDialog.AppsFolderDialog appsFolderDialog = new AppsFolderDialog.AppsFolderDialog();
var result = await appsFolderDialog.ShowDialog();

if(result)
{
     foreach (var path in appsFolderDialog.SelectedPath)
          {
              MessageBox.Show(path);
          }
 }
```

### LICENSE
[Apache License](LICENSE)

