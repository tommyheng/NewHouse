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
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);

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

        //#region HeaderNewsModel

        //private HeaderNews.ViewModels.HeaderNewsViewModel headerNewsViewModel = new HeaderNews.ViewModels.HeaderNewsViewModel();
        //public HeaderNews.ViewModels.HeaderNewsViewModel HeaderNewsViewModel
        //{
        //    get { return headerNewsViewModel; }
        //    set { Set(() => HeaderNewsViewModel, ref headerNewsViewModel, value); }
        //}

        //#endregion

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


        NewHouse.Views.NewHouseView newHouseView;
        private void Navigate(ViewInfo viewInfo)
        {


            switch (viewInfo.ViewType)
            {
                case ViewType.SingleWindow://单个视图。主要为了显示帮助窗口
                    newHouseView = NewHouse.Views.NewHouseView.Instance;
                    newHouseView.WindowState = System.Windows.WindowState.Maximized;
                    newHouseView.Show();
                    break;
                case ViewType.View:
                    break;
            }
        }


        public override void Cleanup()
        {
            base.Cleanup();
            if (newHouseView != null)
            {
                newHouseView.Close();
            }
        }
    }
}