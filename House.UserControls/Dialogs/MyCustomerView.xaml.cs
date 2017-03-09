using FangChan.WPFModel;
using House.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class MyCustomerView
    {
        public int Bid { get; set; }

        public MyCustomerView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData(int pageIndex = 1, int rows = 10)
        {
            var result = DataRepository.Instance.GetBuildingsOrdersList1(Bid,
                GlobalDataPool.Instance.Uid, pageIndex, rows);
            if (result.success)
            {
                myPager.TotalCount = result.TotalRows;
                myPager.PageIndex = pageIndex;
                myPager.PageSize = rows;
                listView.ItemsSource = result.data;
            }
        }

        private void dataPager_PageChanged(object sender, Views.PageChangedEventArgs e)
        {
            //LoadData(1);
        }

        private void dataPager_PageChanging(object sender, Views.PageChangingEventArgs e)
        {
            LoadData(myPager.NewPageIndex);
        }
    }
}