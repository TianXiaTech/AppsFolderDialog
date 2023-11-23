using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Shell32;
using System.IO;
using System;
using System.Windows.Interop;
using System.Threading;

namespace AppsFolderDialog
{
    public class AppsFolderDialog
    {
        private AppsFolderPath[] selectedPath;
        private bool dialogResult = false;
        private bool liveFlag = true;
        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        public AppsFolderPath[] SelectedPath { get => selectedPath; private set => selectedPath = value; }

        public async Task<bool> ShowDialog()
        {
            var selectedList = new List<AppsFolderPath>();
            var process = System.Diagnostics.Process.Start("explorer.exe", "shell:appsfolder");
            var handle = await GetApplicationHwndAsync();
            CreateHostWindow(handle);

            await Task.Factory.StartNew(() =>
            {
                while (liveFlag)
                {
                    autoResetEvent.WaitOne();
                }
            }, TaskCreationOptions.LongRunning);

            if(dialogResult == true)
            {
                foreach (SHDocVw.InternetExplorer window in new SHDocVw.ShellWindows())
                {
                    
                    if (window.HWND == (long)handle)
                    {
                        Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
                        foreach (Shell32.FolderItem item in items)
                        {
                            AppsFolderPath appsFolderPath = new AppsFolderPath();
                            (var path, var type) = GetFormatedPath(item.Path);
                            appsFolderPath.Path = path;
                            appsFolderPath.PathType = type;
                            selectedList.Add(appsFolderPath);
                        }
                        selectedPath = selectedList.ToArray();
                        CloseShellExplorer(handle);
                        break;
                    }
                }
            }

            return dialogResult;
        }

        private Tuple<string,PathType> GetFormatedPath(string path)
        {
            if (System.IO.Directory.Exists(path))
                return new Tuple<string, PathType>(path, PathType.Folder);

            if (System.IO.File.Exists(path))
                return new Tuple<string, PathType>(path, PathType.Absolute);

            return new Tuple<string, PathType>("shell:appsfolder\\" + path, PathType.AUMID);
        }

        private async Task<IntPtr> GetApplicationHwndAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(300);
                var handle = WindowsHelper.GetForegroundWindow();
                StringBuilder stringBuilder = new StringBuilder(260);
                WindowsHelper.GetWindowText(handle, stringBuilder, 260);

                if (stringBuilder.ToString() == "Applications")
                    return handle;
            }

            return IntPtr.Zero;
        }

        private void CreateHostWindow(IntPtr handle)
        {
            ConfirmWindow confirmWindow = new ConfirmWindow();
            confirmWindow.ParentHandle = handle;
            confirmWindow.OnConfirm = OnConfirm;
            confirmWindow.OnCancel = OnCancel;
            confirmWindow.Show();
            var hostHandle = new WindowInteropHelper(confirmWindow).Handle;
            WindowsHelper.SetParent(hostHandle, handle);
            LimitHostWindowSize(handle, hostHandle);
        }

        private void OnConfirm(IntPtr handle)
        {
            dialogResult = true;
            liveFlag = false;
            autoResetEvent.Set();
        }
        
        private void OnCancel(IntPtr handle)
        {
            dialogResult = false;
            liveFlag = false;
            autoResetEvent.Set();
            CloseShellExplorer(handle);
        }

        private void CloseShellExplorer(IntPtr handle)
        {
            WindowsHelper.SendMessage(handle, WindowsHelper.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        private void LimitHostWindowSize(IntPtr parentHwnd,IntPtr hostHandle)
        {
            Task.Factory.StartNew(async () => {
               while(liveFlag)
                {
                    WindowsHelper.tagRECT rect = new WindowsHelper.tagRECT();
                    var result = WindowsHelper.GetWindowRect(parentHwnd, ref rect);

                    if(result == false)
                    {
                        liveFlag = false;
                        dialogResult = false;
                    }

                    int width = rect.right - rect.left;
                    int height = rect.bottom - rect.top;
                    WindowsHelper.SetWindowPos(hostHandle, new IntPtr(0), 0, height - 90, width - 15, 50, WindowsHelper.SWP_SHOWWINDOW);
                    await Task.Delay(1000);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}