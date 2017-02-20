using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using House.Models;
using House.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace House.MainModule.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            registerMessenger(); //Login.UserControl1
        }

        #region MVVMLight消息

        /// <summary>
        /// 注册MVVMLight消息
        /// </summary>
        private void registerMessenger()
        {
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.Navigate, Navigate);

            //Messenger.Default.Register<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Register<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }

        /// <summary>
        /// 取消注册MVVMlight消息
        /// </summary>
        private void unRegisterMessenger()
        {
            Messenger.Default.Unregister<ViewInfo>(this, MessengerToken.Navigate, Navigate);

            //Messenger.Default.Unregister<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Unregister<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }
        #endregion


        #region UserInfoViewModel

        private UserInfo.ViewModels.UserInfoViewModel userInfoViewModel = new UserInfo.ViewModels.UserInfoViewModel();
        public UserInfo.ViewModels.UserInfoViewModel UserInfoViewModel
        {
            get { return userInfoViewModel; }
            set { Set(() => UserInfoViewModel, ref userInfoViewModel, value); }
        }

        #endregion

        #region HeaderNewsModel

        private HeaderNews.ViewModels.HeaderNewsViewModel headerNewsViewModel = new HeaderNews.ViewModels.HeaderNewsViewModel();
        public HeaderNews.ViewModels.HeaderNewsViewModel HeaderNewsViewModel
        {
            get { return headerNewsViewModel; }
            set { Set(() => HeaderNewsViewModel, ref headerNewsViewModel, value); }
        }

        #endregion

        #region MainMenuViewModel

        private MainMenu.ViewModels.MainMenuViewModel mainMenuViewModel = new MainMenu.ViewModels.MainMenuViewModel();
        public MainMenu.ViewModels.MainMenuViewModel MainMenuViewModel
        {
            get { return mainMenuViewModel; }
            set { Set(() => MainMenuViewModel, ref mainMenuViewModel, value); }
        }

        #endregion

        #region FooterViewModel

        private Footer.ViewModels.FooterViewModel footerViewModel = new Footer.ViewModels.FooterViewModel();
        public Footer.ViewModels.FooterViewModel FooterViewModel
        {
            get { return footerViewModel; }
            set { Set(() => FooterViewModel, ref footerViewModel, value); }
        }

        #endregion



        private void Navigate(ViewInfo viewInfo)
        {


            //MyUserControlBase view;
            //view =
            //       System.Reflection.Assembly.Load(@"House.View")
            //           .CreateInstance(@"SuperSoft.View.View." + viewInfo.ViewName.ToString()) as UserControlBase;

            ////if (Equals(viewInfo.Parameter, null))
            ////{
            ////    view =
            ////        System.Reflection.Assembly.Load(@"SuperSoft.View")
            ////            .CreateInstance(@"SuperSoft.View.View." + viewInfo.ViewName.ToString()) as UserControlBase;
            ////}
            ////else
            ////{
            ////    view = System.Reflection.Assembly.Load(@"SuperSoft.View").
            ////        CreateInstance(@"SuperSoft.View.View." + viewInfo.ViewName.ToString(), true, System.Reflection.BindingFlags.Default,
            ////            null, new[] { viewInfo.Parameter }, null, null) as UserControlBase;
            ////}
            //if (view == null)
            //{//未找到视图，抛出异常
            //    throw new Exception(viewInfo.ViewName.ToString());
            //}
            //MyViewModelBase viewModelBase = null;
            //viewModelBase = view.DataContext as MyViewModelBase;
            //if (!Equals(null, viewModelBase))
            //{
            //    viewModelBase.Parameter = viewInfo.Parameter;
            //}

            switch (viewInfo.ViewType)
            {
                //case ViewType.Popup://模式对话框
                //    MahApps.Metro.Controls.MetroWindow popupWindows = new MahApps.Metro.Controls.MetroWindow();
                //    popupWindows.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                //    popupWindows.Style = Utility.Windows.ResourceHelper.FindResource(@"CleanWindowStyleKey") as Style;
                //    popupWindows.GlowBrush = Utility.Windows.ResourceHelper.FindResource(@"AccentColorBrush") as System.Windows.Media.Brush;
                //    //变更语言时，动态更新对话框Title,Title取决于控件的Tag
                //    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.TitleProperty, new Binding(@"Tag") { Source = view });
                //    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.WidthProperty, new Binding(@"Width") { Source = view });
                //    popupWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.HeightProperty, new Binding(@"Height") { Source = view });
                //    popupWindows.Owner = Application.Current.MainWindow;
                //    popupWindows.ResizeMode = ResizeMode.NoResize;
                //    popupWindows.IsCloseButtonEnabled = false;
                //    popupWindows.ShowCloseButton = false;
                //    //popupWindows.Icon = new BitmapImage(new Uri("pack://application:,,,/SuperSoft.Resource.Default;component/Images/Logo_White.png", UriKind.Absolute));
                //    popupWindows.ShowInTaskbar = false;
                //    popupWindows.Focus();
                //    view.Margin = new Thickness(2);
                //    popupWindows.Content = view;
                //    popupWindowsStack.Push(popupWindows);
                //    popupWindows.ShowDialog();
                //    if (!Equals(view, null))
                //    {
                //        view.Dispose();
                //        view = null;
                //        GC.Collect();
                //    }
                //    break;

                //case ViewType.View://普通视图
                //                   //页面切换效果
                //                   //GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<object>(null, Model.MessengerToken.NavigateSplash);
                //    if (!Equals(MainContent, null))
                //    {
                //        MainContent.Dispose();
                //        MainContent = null;
                //        GC.Collect();
                //    }
                //    MainContent = view;
                //    break;

                case ViewType.SingleWindow://单个视图。主要为了显示帮助窗口
                    //MahApps.Metro.Controls.MetroWindow singleWindows = new MahApps.Metro.Controls.MetroWindow();
                    //singleWindows.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    ////popupWindows.Style = Utility.ResourceHelper.FindResource("CleanWindowStyleKey") as Style;
                    //singleWindows.GlowBrush = Utility.Windows.ResourceHelper.FindResource(@"AccentColorBrush") as System.Windows.Media.Brush;
                    //////变更语言时，动态更新对话框Title,Title取决于控件的Tag
                    ////singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.TitleProperty, new Binding(@"Tag") { Source = view });
                    //singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.WidthProperty, new Binding(@"Width") { Source = view });
                    //singleWindows.SetBinding(MahApps.Metro.Controls.MetroWindow.HeightProperty, new Binding(@"Height") { Source = view });
                    //singleWindows.Content = view;
                    //singleWindows.ResizeMode = ResizeMode.NoResize;
                    ////singleWindows.ShowIconOnTitleBar = true;
                    //singleWindows.Icon = new BitmapImage(new Uri("pack://application:,,,/SuperSoft.Resource.Default;component/Images/Logo_White.png", UriKind.Absolute));
                    ////singleWindows.Icon = Utility.Windows.ResourceHelper.FindResource("pack://application:,,,/SuperSoft.Resource.Default;component/Images/Logo_White.png");
                    ////singleWindows.IsCloseButtonEnabled = true;
                    ////singleWindows.ShowCloseButton = true;
                    ////singleWindows.Owner = Application.Current.MainWindow;
                    //singleWindows.Topmost = true;
                    //singleWindows.Show();
                    //singleWindows.Focus();
                    NewHouse.Views.NewHouseView newHouseView = new NewHouse.Views.NewHouseView();
                    newHouseView.Show();
                    break;
            }
        }

    }
}