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
using System.Windows.Shapes;

namespace AppsFolderDialog
{
    /// <summary>
    /// ConfirmWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public Action<IntPtr> OnConfirm { get; set; }

        public Action<IntPtr> OnCancel { get; set; }

        public IntPtr ParentHandle { get; set; }

        public ConfirmWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OnConfirm?.Invoke(ParentHandle);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OnCancel?.Invoke(ParentHandle);
        }
    }
}
