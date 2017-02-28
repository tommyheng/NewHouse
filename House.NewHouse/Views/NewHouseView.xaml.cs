using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using House.UserControls.Views;
using House.Models;

namespace House.NewHouse.Views
{
    /// <summary>
    /// NewHouseView.xaml 的交互逻辑
    /// </summary>
    public partial class NewHouseView
    {
        #region Instance

        private NewHouseView()
        {
            InitializeComponent();
        }

        private readonly static NewHouseView newHouseView = new NewHouseView();
        public static NewHouseView Instance
        {
            get
            {
                return newHouseView;
            }

        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.Hide();
            e.Cancel = true;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = true;
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;

        //}

        //private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.DragMove();
        //}

        //private void closeBtne_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //    this.Close();
        //}

        //private void minBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        /// <summary>
        /// 大主菜单界面时点击关闭按钮退出应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewHouseView_OnClosing(object sender, CancelEventArgs e)
        {
            //if (true)
            //{
            //    Application.Current.Shutdown();
            //}
            if ((RootPanel.Content as ManagementCentreView) != null)
            {
                Messenger.Default.Send<string>(null, MessengerToken.ShutdownApp);
            }

        }

    }
}
