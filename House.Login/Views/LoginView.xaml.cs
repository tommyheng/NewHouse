using House.DAL;
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

namespace House.Login.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dr = DataRepository.Instance;
            
            var name = LoginName.Text.Trim();
            var pwd = LoginPwd.Password.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("账号或密码不能为空！", "温馨提示");
                return;
            }
            var result = dr.Login(name, pwd);
            if (result.success)
            {
                GlobalDataPool.Instance.Uid = result.GeRenXinXi.UserInfo.ID;
                GlobalDataPool.Instance.UserName = result.GeRenXinXi.UserInfo.UserName;
                GlobalDataPool.Instance.Position = result.GeRenXinXi.UserInfo.ZhiWu;
                GlobalDataPool.Instance.LoginData = result;

                var list = dr.GetBuildingsList(GlobalDataPool.Instance.Uid, 1, 10, 0, "");
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("登陆失败，请检查账号和密码！", "温馨提示");
            }
            //
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeBtne_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
