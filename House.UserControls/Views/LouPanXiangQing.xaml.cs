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
    /// 楼盘详情
    /// LouPanXiangQing.xaml 的交互逻辑
    /// </summary>
    public partial class LouPanXiangQing
    {
        public LouPanXiangQing()
        {
            InitializeComponent();

        }

        private void InitLouPanData()
        {
            int bid = DAL.DataRepository.Instance.GetBuildingsList(DAL.GlobalDataPool.Instance.Uid, 1, 1, 1, null).data.First().ID;
            var buildingInfo = DAL.DataRepository.Instance.GetBuildingsInfo(DAL.GlobalDataPool.Instance.Uid, bid).data;

            //var v = buildingInfo.Images.First().ImageUrl;
            //iamge.Source = new BitmapImage(new Uri(buildingInfo.Images.First().ImageUrl));



            bName.Text = buildingInfo.QuYu + "  |  " + buildingInfo.Name;
            prise.Text = buildingInfo.Price;
            address.Text = buildingInfo.Address;

            kehushuliang.Text = "合作经济人：" + buildingInfo.HeZhuoJingJiRenNumber
                + "  |  " + "意向客户：" + buildingInfo.YiXiangKeHuNumber
                + "  |  " + "我的客户：" + buildingInfo.WoDeKeHuNumber;

            yongjing.Text = buildingInfo.YongJin;

            daikan.Text = buildingInfo.DaiKanYongJin;

            var user = buildingInfo.Users.Where(p => p.UserType == 1).First();
            zhiyeguwen.Text = "咨询业务员    " + user.UserName + "  " + user.DianHua;
            //buildingInfo.yew

            yongjing2.Text = "佣金：" + buildingInfo.YongJin;


            //buildingInfo.HuXing.First ().Name

            BaoBeiGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe) ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            DiaKanGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.DaiKanGuiZhe) ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            ChengJiaoGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.ChengJiaoGuiZhe) ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            ChengJiaoJiangLi.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.JiangLi) ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            JieSuanZhouQi.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.JieShuanZhouQi) ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;

            listView.ItemsSource = buildingInfo.HuXing;






        }

        private void MyUserControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            InitLouPanData();
        }
    }
}
