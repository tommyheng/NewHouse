using House.UserControls.ViewModels;
using House.Utility;
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

namespace House.UserControls.Views
{
    /// <summary>
    /// MyCustomer.xaml 的交互逻辑
    /// </summary>
    public partial class MyCustomer : MyUserControlBase
    {
        private MyCustomerViewModel dataContext = new MyCustomerViewModel();
        public MyCustomer()
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }
    }
}
