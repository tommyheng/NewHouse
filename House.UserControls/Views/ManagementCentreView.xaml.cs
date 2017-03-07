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
        private string newHouseKey = "";
        private string userListKey = "";
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
            LoadCustomerListData();
        }

        #region 我的报备客户
        private void dataPager_PageChanging(object sender, PageChangingEventArgs e)
        {
            LoadData(myPager.NewPageIndex, 10);
        }

        /// <summary>
        /// 我报备的新房
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="rows"></param>
        private void LoadData(int pageIndex = 1, int rows = 10)
        {
            var result = DataRepository.Instance.GetBuildingsOrdersList2(newHouseKey,
                GlobalDataPool.Instance.Uid, pageIndex, rows);
            if (result.success)
            {
                myPager.TotalCount = result.TotalRows;
                myPager.PageIndex = pageIndex;
                myPager.PageSize = rows;
                listView.ItemsSource = result.data;
            }
        }

        /// <summary>
        /// 客户列表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rows"></param>
        private void LoadCustomerListData(int pageIndex = 1, int rows = 14)
        {

            var result = DataRepository.Instance.GetBuildingsCustomerList2(userListKey, GlobalDataPool.Instance.Uid, pageIndex, rows);
            if (result.success)
            {
                usersPager.TotalCount = result.TotalRows;
                usersPager.PageIndex = pageIndex;
                usersPager.PageSize = rows;
                userlistView.ItemsSource = result.KeHuList;
            }
        }



        #endregion

        private void userDataPager_PageChanging(object sender, PageChangingEventArgs e)
        {
            LoadCustomerListData(usersPager.NewPageIndex, 14);
        }
    }
}
