using System;
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
using System.Windows.Shapes;

namespace AppsFolderDialogDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AppsFolderDialog.AppsFolderDialog appsFolderDialog = new AppsFolderDialog.AppsFolderDialog();
            var result = await appsFolderDialog.ShowDialog();

            if(result)
            {
                this.listbox.ItemsSource = appsFolderDialog.SelectedPath.ToList();
            }
        }

        private void listbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.listbox.SelectedIndex == -1)
                return;

            var selectedItem = this.listbox.SelectedItem as AppsFolderDialog.AppsFolderPath;
            RunAppsFolderSelectedItem(selectedItem);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (this.listbox.SelectedIndex == -1)
                return;

            var selectedItem = this.listbox.SelectedItem as AppsFolderDialog.AppsFolderPath;
            RunAppsFolderSelectedItem(selectedItem);
        }

        private void RunAppsFolderSelectedItem(AppsFolderDialog.AppsFolderPath appsFolderPath)
        {
            if (appsFolderPath == null || string.IsNullOrEmpty(appsFolderPath.Path))
                return;

            if (appsFolderPath.PathType == AppsFolderDialog.PathType.Absolute)
            {
                System.Diagnostics.Process.Start(appsFolderPath.Path);
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", appsFolderPath.Path);
            }

        }
    }
}
