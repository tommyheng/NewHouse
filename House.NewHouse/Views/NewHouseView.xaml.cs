using System;
using System.Collections;
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
using House.Utility;
using MahApps.Metro.Controls;

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
            registerMessenger();

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

        #region 最大化 关闭 还原成小菜单

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //大主菜单界面时点击关闭按钮退出应用程序
            if ((RootPanel.Content as MainMenu.Views.MainMenuView2) != null)
            {
                unRegisterMessenger();
                Messenger.Default.Send<string>(null, MessengerToken.ShutdownApp);
            }
            else
            {
                //其他页面关闭时显示小菜单
                this.Hide();
                e.Cancel = true;
                Messenger.Default.Send<string>(null, MessengerToken.SwitchMainMenuToSmall);
            }
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void closeBtne_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void restoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<string>(null, Models.MessengerToken.SwitchMainMenuToSmall);
            this.Hide();
        }

        #endregion

        #region MVVMLight消息

        /// <summary>
        ///     注册MVVMLight消息
        /// </summary>
        private void registerMessenger()
        {
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);
        }

        /// <summary>
        ///     取消注册MVVMlight消息
        /// </summary>
        private void unRegisterMessenger()
        {
            Messenger.Default.Unregister<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);
        }

        #endregion

        /// <summary>
        /// 页面跳转，之后的所有页面在此函数经行
        /// </summary>
        /// <param name="viewInfo"></param>
        private void Navigate(ViewInfo viewInfo)
        {
            MyUserControlBase view;


            if (Equals(viewInfo.Parameter, null))
            {

                var assemblyName = viewInfo.ViewName.ToDescription().Split(',');
                if (assemblyName.Length > 1)
                {
                    view =
                      System.Reflection.Assembly.Load(assemblyName[0])
                          .CreateInstance(assemblyName[1]) as MyUserControlBase;
                }
                else
                {
                    view =
                      System.Reflection.Assembly.Load(@"House.UserControls")
                          .CreateInstance(assemblyName[0]) as MyUserControlBase;
                }
            }
            else
            {
                var assemblyName = viewInfo.ViewName.ToDescription().Split(',');
                if (assemblyName.Length > 1)
                {
                    view =
                      System.Reflection.Assembly.Load(assemblyName[0])
                          .CreateInstance(assemblyName[1], true, System.Reflection.BindingFlags.Default,
                        null, new[] { viewInfo.Parameter }, null, null) as MyUserControlBase;
                }
                else
                {
                    view =
                      System.Reflection.Assembly.Load(@"House.UserControls")
                          .CreateInstance(assemblyName[0], true, System.Reflection.BindingFlags.Default,
                        null, new[] { viewInfo.Parameter }, null, null) as MyUserControlBase;
                }
            }

            if (view == null)
            {//未找到视图，抛出异常
                //throw new Exception(viewInfo.ViewName.ToString());
                this.RootPanel.Content = "视图加载失败请联系客服";
            }

            if ((view as MainMenu.Views.MainMenuView2) != null)
            {
                this.restoreBtn.Visibility = Visibility;
            }
            else
            {
                this.restoreBtn.Visibility = Visibility.Collapsed;
            }

            switch (viewInfo.ViewType)
            {
                case ViewType.Popup://模式对话框
                    MahApps.Metro.Controls.MetroWindow popupWindows = new MahApps.Metro.Controls.MetroWindow();
                    popupWindows.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    popupWindows.Style = FindResource(@"CleanWindowStyleKey") as Style;
                    popupWindows.GlowBrush = FindResource(@"AccentColorBrush") as System.Windows.Media.Brush;
                    //变更语言时，动态更新对话框Title,Title取决于控件的Tag
                    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.TitleProperty, new Binding(@"Tag") { Source = view });
                    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.WidthProperty, new Binding(@"Width") { Source = view });
                    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.HeightProperty, new Binding(@"Height") { Source = view });
                    popupWindows.Owner = Application.Current.MainWindow;
                    popupWindows.ResizeMode = ResizeMode.NoResize;
                    popupWindows.IsCloseButtonEnabled = false;
                    popupWindows.ShowCloseButton = false;
                    //popupWindows.Icon = new BitmapImage(new Uri("pack://application:,,,/SuperSoft.Resource.Default;component/Images/Logo_White.png", UriKind.Absolute));
                    popupWindows.ShowInTaskbar = false;
                    popupWindows.Focus();
                    view.Margin = new Thickness(2);
                    popupWindows.Content = view;
                    popupWindowsStack.Push(popupWindows);
                    popupWindows.ShowDialog();
                    if (!Equals(view, null))
                    {
                        view.Dispose();
                        view = null;
                        GC.Collect();
                    }
                    break;

                case ViewType.View://普通视图
                                   //页面切换效果
                                   //GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<object>(null, Model.MessengerToken.NavigateSplash);
                    if (!Equals(RootPanel, null))
                    {
                        //RootPanel.Dispose();
                        RootPanel.Content = null;

                        GC.Collect();
                    }
                    bigHeaderView.Title = view.Title;
                    RootPanel.Content = view;

                    break;

                case ViewType.SingleWindow://单个视图。主要为了显示帮助窗口
                    MahApps.Metro.Controls.MetroWindow singleWindows = new MahApps.Metro.Controls.MetroWindow();
                    singleWindows.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    //popupWindows.Style = Utility.ResourceHelper.FindResource("CleanWindowStyleKey") as Style;
                    singleWindows.GlowBrush = FindResource(@"AccentColorBrush") as System.Windows.Media.Brush;
                    //变更语言时，动态更新对话框Title,Title取决于控件的Tag
                    singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.TitleProperty, new Binding(@"Tag") { Source = view });
                    singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.WidthProperty, new Binding(@"Width") { Source = view });
                    singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.HeightProperty, new Binding(@"Height") { Source = view });
                    singleWindows.Content = view;
                    singleWindows.ResizeMode = ResizeMode.NoResize;
                    //singleWindows.ShowIconOnTitleBar = true;
                    singleWindows.Icon = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/Logo.ico", UriKind.Absolute));
                    //singleWindows.Icon = Utility.Windows.ResourceHelper.FindResource("pack://application:,,,/SuperSoft.Resource.Default;component/Images/Logo_White.png");
                    //singleWindows.IsCloseButtonEnabled = true;
                    //singleWindows.ShowCloseButton = true;
                    //singleWindows.Owner = Application.Current.MainWindow;
                    singleWindows.Topmost = true;
                    singleWindows.Show();
                    singleWindows.Focus();
                    break;
            }
        }

        private Stack popupWindowsStack = new Stack();

        /// <summary>
        /// 关闭Popup
        /// </summary>
        /// <param name="obj"></param>
        private void ClosePopup(object obj)
        {
            //多个Popup时需要入栈
            if (popupWindowsStack.Count > 0)
            {
                MetroWindow popupWindow = popupWindowsStack.Pop() as MetroWindow;
                popupWindow.Close();
                popupWindow = null;
                GC.Collect();
            }
        }
    }
}
