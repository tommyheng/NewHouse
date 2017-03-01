using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using House.Footer.ViewModels;
using House.MainMenu.ViewModels;
using House.Models;
using House.NewHouse.Views;
using House.UserInfo.ViewModels;

namespace House.MainModule.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NewHouseView newHouseView;

        public MainViewModel()
        {
            registerMessenger(); //Login.UserControl1
        }

        private void Navigate(ViewInfo viewInfo)
        {
            switch (viewInfo.ViewType)
            {
                case ViewType.SingleWindow: //单个视图。主要为了显示帮助窗口
                    newHouseView = NewHouseView.Instance;
                    newHouseView.WindowState = WindowState.Maximized;
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
                newHouseView.Close();
        }

        #region MVVMLight消息

        /// <summary>
        ///     注册MVVMLight消息
        /// </summary>
        private void registerMessenger()
        {
            //Messenger.Default.Register<ViewInfo>(this, MessengerToken.Navigate, Navigate);
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.MainMenuNavigate, Navigate);

            //Messenger.Default.Register<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Register<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }

        /// <summary>
        ///     取消注册MVVMlight消息
        /// </summary>
        private void unRegisterMessenger()
        {
            Messenger.Default.Unregister<ViewInfo>(this, MessengerToken.MainMenuNavigate, Navigate);

            //Messenger.Default.Unregister<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Unregister<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }

        #endregion

        #region UserInfoViewModel

        private UserInfoViewModel userInfoViewModel = new UserInfoViewModel();

        public UserInfoViewModel UserInfoViewModel
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

        private MainMenuViewModel mainMenuViewModel = new MainMenuViewModel();

        public MainMenuViewModel MainMenuViewModel
        {
            get { return mainMenuViewModel; }
            set { Set(() => MainMenuViewModel, ref mainMenuViewModel, value); }
        }

        #endregion

        #region FooterViewModel

        private FooterViewModel footerViewModel = new FooterViewModel();

        public FooterViewModel FooterViewModel
        {
            get { return footerViewModel; }
            set { Set(() => FooterViewModel, ref footerViewModel, value); }
        }

        #endregion
    }
}