using House.UserControls.ViewModels;
using House.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace House.UserControls.Views
{
    /// <summary>
    /// UserInformation.xaml 的交互逻辑
    /// </summary>
    public partial class UserInformation : MyUserControlBase
    {
        private UserInformationViewModel dataContext = new UserInformationViewModel();
        public UserInformation()
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }

        private void OnSelectUpLoadImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog =
                new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "图像文件|*.GIF;*.PNG;*.JPG;*.JPEG|所有文件|*.*";
            if (dialog.ShowDialog() == true)
            {
                FileNameTextBlk.Text = dialog.FileName;
            }
        }
    }
}
