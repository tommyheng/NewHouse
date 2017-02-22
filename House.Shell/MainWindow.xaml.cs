using FangChan.WPFModel;
using House.Login.Views;
using House.Utility.Common;
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

namespace House.Shell
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            verifyUser();
            InitializeComponent();
        }

        /// <summary>
        /// 验证用户是否登录成功
        /// </summary>
        private void verifyUser()
        {

            //var t = HttpClientHelper.GetResponse<LoginStateModel>
            //(@"http://test.fang101.com/App/Login?LoginName=1&LoginPass=1");

            var result = TestAPI();
            House.Login.Views.LoginView loginWindows = new LoginView();
            //登陆没有返回true,关闭了窗体，结束应用程序
            if (!loginWindows.ShowDialog() == true)
            {
                Application.Current.Shutdown();
            }
            else
            {


            }

        }

        public string TestAPI()
        {
            HttpHelper httpHelper = new HttpHelper();
            UTF8Encoding utf8 = new UTF8Encoding();
            string registerURL = "http://test.fang101.com/App/Login";
            string postData = string.Format("LoginName={0}&LoginPass={1}", "1", "2");

            httpHelper.CC = new System.Net.CookieContainer(); 
            string html = httpHelper.PostAndGetHtml(registerURL, postData, null, null, false, Encoding.UTF8);
            return html;

        }

    }
}
