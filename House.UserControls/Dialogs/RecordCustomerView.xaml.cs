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
    public partial class RecordCustomerView
    {
        public int Bid { get; set; }
        public int Total { get; set; }
        public int IndexPage { get; set; }

        private int rows = 20;

        public RecordCustomerView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IndexPage = 1;

            var result = DataRepository.Instance.GetBuildingsCustomerList1(Bid,
                GlobalDataPool.Instance.Uid, IndexPage, rows);
            if (result.success)
            {
                Total = result.TotalRows;
                listView.ItemsSource = result.KeHuList;

            }
        }
    }
}
