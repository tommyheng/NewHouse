using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace House.UserInfo.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {

        public UserInfoViewModel()
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
            ViewInfo viewInfo = new ViewInfo(ViewName.NewHouse, ViewType.SingleWindow);
            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.MainMenuNavigate);

            ViewInfo viewInfo2 = new ViewInfo(ViewName.ManagementCenter, ViewType.View);
            Messenger.Default.Send<ViewInfo>(viewInfo2, MessengerToken.NewHouseInternalNavigate);
        }

        #endregion


        #region UserInfoModel

        private Models.UserInfoModel userInfoModel = new Models.UserInfoModel();
        public Models.UserInfoModel UserInfoModel
        {
            get { return userInfoModel; }
            set { Set(() => UserInfoModel, ref userInfoModel, value); }
        }

        #endregion

    }
}
