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
            if (!result.success)
            {
                return;
                //result.data.JinDuTiao.;
                //BaoBeiXiangQingView view = new BaoBeiXiangQingView();
                //view.NewFangRunningListItem = newFangRunningListItem;
                //view.ShowDialog();
            }



            loupanmingcheng.Text = NewFangRunningListItem.LouPanName;
            kehu.Text = NewFangRunningListItem.KeHuName + " " + NewFangRunningListItem.KeHuDianHua;
            jingjiren.Text = NewFangRunningListItem.JingJiRenName + " " + NewFangRunningListItem.JingJiRenDianHua;
            
            var data = result.data;
            jindu1Left.Text = data.JinDuText[0].LeftText;
            Jindu1Right.Text = data.JinDuText[0].RightText;

            jindu2Left.Text = data.JinDuText[1].LeftText;
            Jindu2Right.Text = data.JinDuText[1].RightText;

            jindu3Left.Text = data.JinDuText[2].LeftText;
            Jindu3Right.Text = data.JinDuText[2].RightText;

            jindu4Left.Text = data.JinDuText[3].LeftText;
            Jindu4Right.Text = data.JinDuText[3].RightText;

            jindu5Left.Text = data.JinDuText[4].LeftText;
            Jindu5Right.Text = data.JinDuText[4].RightText;

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