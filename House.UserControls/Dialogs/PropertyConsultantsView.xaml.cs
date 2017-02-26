using House.DAL;
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
using System.Windows.Shapes;

namespace House.UserControls
{
    /// <summary>
    /// PropertyConsultantsView.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyConsultantsView
    {
        public int Bid { get; set; }

        public PropertyConsultantsView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var result = DataRepository.Instance.GetPropertyConsultantList(Bid);
            if (result.success)
            {
                listView.ItemsSource = result.data;
            }
        }
    }
}
