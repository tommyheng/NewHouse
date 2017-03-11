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
    /// BaoBeiXiangQingView.xaml 的交互逻辑
    /// </summary>
    public partial class BaoBeiXiangQingView
    {
        //public RunningsModel RunningsModel { get; set; }
        public NewFangRunningListItem NewFangRunningListItem { get; set; }

        public BaoBeiXiangQingView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            var result = DataRepository.Instance.GetBuildingsOrder(NewFangRunningListItem.ID);
            if (result.success)
            {
                //result.data.JinDuTiao.;
                //BaoBeiXiangQingView view = new BaoBeiXiangQingView();
                //view.NewFangRunningListItem = newFangRunningListItem;
                //view.ShowDialog();
            }
            //var result = DataRepository.Instance.GetBuildingsOrdersList1(Bid,
            //    GlobalDataPool.Instance.Uid, pageIndex, rows);
            //if (result.success)
            //{
            //    myPager.TotalCount = result.TotalRows;
            //    myPager.PageIndex = pageIndex;
            //    myPager.PageSize = rows;
            //    listView.ItemsSource = result.data;
            //}
        }

        //private void dataPager_PageChanged(object sender, Views.PageChangedEventArgs e)
        //{
        //    //LoadData(1);
        //}

        //private void dataPager_PageChanging(object sender, Views.PageChangingEventArgs e)
        //{
        //    LoadData(myPager.NewPageIndex);
        //}
    }
}