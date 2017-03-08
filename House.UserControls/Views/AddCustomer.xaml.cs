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
using System.Globalization;
using House.UserControls.ViewModels;

namespace House.UserControls.Views
{
    /// <summary>
    /// AddCustomer.xaml 的交互逻辑
    /// </summary>
    public partial class AddCustomer : MyUserControlBase
    {
        private AddCustomerViewModel dataContext = new AddCustomerViewModel();
        public AddCustomer()
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }

    }

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;

            if ((bool)value) return Visibility.Visible;
            else return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
