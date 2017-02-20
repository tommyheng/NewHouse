using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using House.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace House.MainMenu.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {

        public MainMenuViewModel()
        {
            initCommand();
        }

        private void initCommand()
        {
            UserHomeCommand = new GalaSoft.MvvmLight.Command.RelayCommand(OnExecuteUserHomeCommand);
            NewHouseCommand = new GalaSoft.MvvmLight.Command.RelayCommand(OnExecuteNewHouseCommand);
        }

        #region NavigateUserHomeCommand

        public ICommand UserHomeCommand { get; private set; }

        private void OnExecuteUserHomeCommand()
        {


            //Messenger.Default.Send<object>(null, Models.MessengerToken.Navigate);
        }

        #endregion

        #region NewHouseCommand

        public ICommand NewHouseCommand { get; private set; }

        private void OnExecuteNewHouseCommand()
        {
            ViewInfo viewInfo = new ViewInfo(ViewName.NewHouse, ViewType.SingleWindow);

            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.Navigate);
        }

        #endregion

        #region HeaderModel

        //private Models.HeaderModel headerModel = new Models.HeaderModel();
        //public Models.HeaderModel HeaderModel
        //{
        //    get { return headerModel; }
        //    set { Set(() => HeaderModel, ref headerModel, value); }
        //}

        #endregion

    }
}
