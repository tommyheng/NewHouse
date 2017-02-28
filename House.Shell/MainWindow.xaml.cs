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
using GalaSoft.MvvmLight.Messaging;
using House.Models;

namespace House.Shell
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            registerMessenger();
            verifyUser();
            InitializeComponent();
        }

        /// <summary>
        /// 验证用户是否登录成功
        /// </summary>
        private void verifyUser()
        {
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

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            unRegisterMessenger();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeBtne_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void restoreBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewInfo viewInfo = new ViewInfo(ViewName.NewHouse, ViewType.SingleWindow);
                Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.MainMenuNavigate);
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }

        }

        #region MVVMLight消息

        /// <summary>
        /// 注册MVVMLight消息
        /// </summary>
        private void registerMessenger()
        {
            Messenger.Default.Register<string>(this, MessengerToken.ShutdownApp, ShutdownApp);

            //Messenger.Default.Register<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Register<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }

        /// <summary>
        /// 取消注册MVVMlight消息
        /// </summary>
        private void unRegisterMessenger()
        {
            Messenger.Default.Unregister<string>(this, MessengerToken.MainMenuNavigate, ShutdownApp);

        }

        private void ShutdownApp(string obj)
        {
            Application.Current.Shutdown();
        }
        #endregion









    }
}
