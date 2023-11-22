# AppsFolderDialog

Provide a dialog box to select installed app from local machine.
![image](https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/26ad6a1e-3274-4ffa-80f0-2a9264a114e0)

the selected item is [Application User Model ID](https://learn.microsoft.com/en-us/windows/win32/shell/appids) ,You can run it in the following way

**Run dialog**
```
shell:appsfolder\xxx
```

**C#**
```C#
System.Diagnostic.Process.Start("explorer.exe","shell:appsfolder\xxx");
```

**such as Windows Media Player**
```
shell:appsfolder\Microsoft.Windows.MediaPlayer32
```


**Preview**

https://github.com/TianXiaTech/AppsFolderDialog/assets/22126367/cc6bd420-8abb-48cb-b353-13f36dba4693

