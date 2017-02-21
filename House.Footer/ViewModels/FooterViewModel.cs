using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace House.Footer.ViewModels
{
    public class FooterViewModel : ViewModelBase
    {

        public void Header()
        {
            initCommand();
        }

        private void initCommand()
        {
            NavigateWebHostCommand = new GalaSoft.MvvmLight.Command.RelayCommand(OnExecuteNavigateWebHostCommand);
        }

        #region ConfirmCommand


        public GalaSoft.MvvmLight.Command.RelayCommand NavigateWebHostCommand { get; set; }

        private void OnExecuteNavigateWebHostCommand()
        {
            System.Diagnostics.Process.Start("http://www.fang101.com/Show/Index");

        }

        #endregion




        private string msg = "下载手机版";
        public string Msg
        {
            get { return msg; }
            set { Set(() => Msg, ref msg, value); }
        }

    }
}
