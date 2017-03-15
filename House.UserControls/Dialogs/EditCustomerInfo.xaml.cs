using FangChan.WPFModel;
using House.UserControls.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace House.UserControls.Dialogs
{
    /// <summary>
    /// Interaction logic for EditCustomerInfo.xaml
    /// </summary>
    public partial class EditCustomerInfo : MetroWindow
    {
        private AddCustomerViewModel dataContext = new AddCustomerViewModel();
        public EditCustomerInfo(string command, KeHuShowListItem customerInfo)
        {
            InitializeComponent();
            this.DataContext = dataContext;

            if (command.Equals("Edit"))
            {
                this.Title = "修改客户信息";
                ConfirmBtn.Visibility = Visibility.Collapsed;
                dataContext.InitData(customerInfo);
            }
            else
            {
                this.Title = "查看客户详情";
                EditBtn.Visibility = Visibility.Collapsed;
                dataContext.InitData(customerInfo);
            }
            
        }
    }
}
