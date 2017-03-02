using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using House.Models;

namespace House.NewHouse.ViewModels
{
    public class NewHouseViewModel : ViewModelBase
    {
        public NewHouseViewModel()
        {
            initCommand();
        }

        private void initCommand()
        {
            NavigateUserHomeCommand = new GalaSoft.MvvmLight.Command.RelayCommand(OnExecuteNavigateUserHomeCommand);
        }

        #region ConfirmCommand


        public ICommand NavigateUserHomeCommand { get; private set; }

        private void OnExecuteNavigateUserHomeCommand()
        {


            //Messenger.Default.Send<object>(null, Models.MessengerToken.Navigate);
        }

        #endregion

        #region MVVMLight消息

        /// <summary>
        /// 注册MVVMLight消息
        /// </summary>
        private void registerMessenger()
        {
            Messenger.Default.Register<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);

            //Messenger.Default.Register<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Register<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }

        /// <summary>
        /// 取消注册MVVMlight消息
        /// </summary>
        private void unRegisterMessenger()
        {
            Messenger.Default.Unregister<ViewInfo>(this, MessengerToken.NewHouseInternalNavigate, Navigate);

            //Messenger.Default.Unregister<object>(this, Model.MessengerToken.ClosePopup, ClosePopup);

            //Messenger.Default.Unregister<MenuInfo>(this, Model.MessengerToken.SetMenuStatus, SetMenuStatus);
        }
        #endregion

        private void Navigate(ViewInfo viewInfo)
        {


            switch (viewInfo.ViewType)
            {
                case ViewType.SingleWindow://单个视图。主要为了显示帮助窗口
                    //newHouseView = NewHouse.Views.NewHouseView.Instance;
                    //newHouseView.WindowState = System.Windows.WindowState.Maximized;
                    //newHouseView.Show();

                    break;
            }
        }

    }
}
