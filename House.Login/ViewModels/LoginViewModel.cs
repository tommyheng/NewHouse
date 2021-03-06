﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace House.Login.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
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
    }
}
