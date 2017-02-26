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
        private int bId;
        public LouPanXiangQing()
        {
            InitializeComponent();

        }

        private void InitLouPanData()
        {
            bId = DAL.DataRepository.Instance.GetBuildingsList(DAL.GlobalDataPool.Instance.Uid, 1, 1, 1, null).data.First().ID;
            var buildingInfo = DAL.DataRepository.Instance.GetBuildingsInfo(DAL.GlobalDataPool.Instance.Uid, bId).data;

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

            BaoBeiGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe)
                ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            DiaKanGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.DaiKanGuiZhe)
                ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            ChengJiaoGuiZe.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.ChengJiaoGuiZhe)
                ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            ChengJiaoJiangLi.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.JiangLi)
                ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;
            JieSuanZhouQi.Text = string.IsNullOrWhiteSpace(buildingInfo.KaiFaShangGuiZhe.JieShuanZhouQi)
                ? "暂无数据" : buildingInfo.KaiFaShangGuiZhe.BaoBeiGuiZhe;

            listView.ItemsSource = buildingInfo.HuXing;


            KaiPanShiJian.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.KaiPanTime)
                ? "暂无数据" : buildingInfo.XiangQing.KaiPanTime;
            JiaoFangShiJian.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.JiaoFangTime)
                ? "暂无数据" : buildingInfo.XiangQing.JiaoFangTime;
            KaiFaShang.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.KaiFaShang)
                ? "暂无数据" : buildingInfo.XiangQing.KaiFaShang;
            KaiFaShangPinPai.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.KaiFaShangPinPai)
                ? "暂无数据" : buildingInfo.XiangQing.KaiFaShangPinPai;

            WuYeGongShi.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.WuYeGongShi)
               ? "暂无数据" : buildingInfo.XiangQing.WuYeGongShi;
            JianZhuMianJi.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.JianZhuMianJi)
                ? "暂无数据" : buildingInfo.XiangQing.JianZhuMianJi;

            ZhongHuShu.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.ZhongHuShu)
             ? "暂无数据" : buildingInfo.XiangQing.ZhongHuShu;
            RongJiLv.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.RongJiLv)
                ? "暂无数据" : buildingInfo.XiangQing.RongJiLv;

            CheWeiBi.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.CheWeiBi)
            ? "暂无数据" : buildingInfo.XiangQing.CheWeiBi;
            WuYeFei.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.WuYeFei)
                ? "暂无数据" : buildingInfo.XiangQing.WuYeFei;

            JianZhuLeiXing.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.JianZhuLeiXing)
           ? "暂无数据" : buildingInfo.XiangQing.JianZhuLeiXing;
            ZhuangXiuZhongKuang.Text = string.IsNullOrWhiteSpace(buildingInfo.XiangQing.ZhuangXiuZhongKuang)
                ? "暂无数据" : buildingInfo.XiangQing.ZhuangXiuZhongKuang;

            //买点
            listViewLouPanMaiDian.ItemsSource = buildingInfo.MaiDian;


            //webBrowserDiTu.Source = new Uri("www.map.baidu.com");
            //webBrowserDiTu.Navigate("http://map.baidu.com/");

            //buildingInfo.XiangQing

        }

        private void MyUserControlBase_Loaded(object sender, RoutedEventArgs e)
        {
            InitLouPanData();
        }

        private void PropertyConsultantsClick(object sender, RoutedEventArgs e)
        {
            PropertyConsultantsView win = new PropertyConsultantsView();
            win.Bid = bId+1;
            win.ShowDialog();
        }
    }
}
