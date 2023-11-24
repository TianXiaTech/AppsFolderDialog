# AppsFolderDialog

<p align="center">
 <img align="center" alt="logo" src="nuget/icon.png" />
</p>
</p>
<p align="center">
<a href="https://github.com/TianXiaTech/AppsFolderDialog/stargazers" target="_blank">
 <img alt="GitHub stars" src="https://img.shields.io/github/stars/TianXiaTech/AppsFolderDialog" />
</a>
<a href="https://github.com/TianXiaTech/AppsFolderDialog/releases" target="_blank">
 <img alt="All releases" src="https://img.shields.io/github/downloads/TianXiaTech/AppsFolderDialog/total.svg" />
</a>
<a href="https://github.com/TianXiaTech/AppsFolderDialog/network/members" target="_blank">
 <img alt="Github forks" src="https://img.shields.io/github/forks/TianXiaTech/AppsFolderDialog" />
</a>
<a href="https://github.com/TianXiaTech/AppsFolderDialog/issues" target="_blank">
 <img alt="All issues" src="https://img.shields.io/github/issues/TianXiaTech/AppsFolderDialog" />
</a>
</p>

Provide a dialog box to select installed app from local machine.
![image](https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/26ad6a1e-3274-4ffa-80f0-2a9264a114e0)

the selected item is [Application User Model ID](https://learn.microsoft.com/en-us/windows/win32/shell/appids) ,You can run it in the following way

* **Run dialog**
```
shell:appsfolder\xxx
```

* **C#**
```C#
System.Diagnostic.Process.Start("explorer.exe","shell:appsfolder\xxx");
```

# Example
```C#
System.Diagnostic.Process.Start("explorer.exe","shell:appsfolder\Microsoft.Windows.MediaPlayer32");  //open Windows Media Player
```

# Preview

https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/76a04910-6261-4811-9233-814f802eb7ed


# Usage
```Powershell
PM>NuGet\Install-Package AppsFolderDialog -Version 0.0.1
```
```C#
AppsFolderDialog.AppsFolderDialog appsFolderDialog = new AppsFolderDialog.AppsFolderDialog();
var result = await appsFolderDialog.ShowDialog();

if(result)
{
    //this.listbox.ItemsSource = appsFolderDialog.SelectedPath.ToList();
    foreach (var item in appsFolderDialog.SelectedPath)
    {
        switch(item.PathType)
        {
            case AppsFolderDialog.PathType.Absolute:
                //Absolute
                System.Diagnostics.Process.Start(item.Path);
                break;
            case AppsFolderDialog.PathType.AUMID:
                //AUMID
                System.Diagnostics.Process.Start("explorer.exe", item.Path);
                break;
            case AppsFolderDialog.PathType.Folder:
                //Folder
                break;
            default:
                break;
        }
    }
}
```

### LICENSE
[Apache License](LICENSE)

