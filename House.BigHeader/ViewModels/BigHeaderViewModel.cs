using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace House.BigHeader.ViewModels
{
    public class BigHeaderViewModel : ViewModelBase
    {

        public BigHeaderViewModel()
        {
            initCommand();
        }

        private void initCommand()
        {
            //NavigateUserHomeCommand = new GalaSoft.MvvmLight.Command.RelayCommand(OnExecuteNavigateUserHomeCommand);
        }

        //#region ConfirmCommand


        //public ICommand NavigateUserHomeCommand { get; private set; }

        //private void OnExecuteNavigateUserHomeCommand()
        //{


        //    Messenger.Default.Send<object>(null, Models.MessengerToken.Navigate);
        //}

        //#endregion


        //#region HeaderModel

        //private Models.HeaderModel headerModel = new Models.HeaderModel();
        //public Models.HeaderModel HeaderModel
        //{
        //    get { return headerModel; }
        //    set { Set(() => HeaderModel, ref headerModel, value); }
        //}

        //#endregion

    }
}
