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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace House.UserControls.Views
{
    /// <summary>
    /// ManagementCentreView.xaml 的交互逻辑
    /// </summary>
    public partial class ManagementCentreView
    {
        public ManagementCentreView()
        {
            InitializeComponent();
        }

        private void onSearchClick(object sender, RoutedEventArgs e)
        {

        }


        private void userCenter_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        #region 我的报备客户
        private void dataPager_PageChanging(object sender, PageChangingEventArgs e)
        {
            LoadData(myPager.NewPageIndex, 10);
        }
        private void LoadData(int pageIndex = 1, int rows = 10)
        {
            var result = DataRepository.Instance.GetBuildingsOrdersList2("",
                GlobalDataPool.Instance.Uid, pageIndex, rows);
            if (result.success)
            {
                myPager.TotalCount = result.TotalRows;
                myPager.PageIndex = pageIndex;
                myPager.PageSize = rows;
                listView.ItemsSource = result.data;
            }
        }
        #endregion


    }
}
