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
            InitLouPanData();
        }

        private void InitLouPanData()
        {
            int bid = DAL.DataRepository.Instance.GetBuildingsList(DAL.GlobalDataPool.Instance.Uid, 1, 1, 1, null).data.First().ID;
            var buildingInfo = DAL.DataRepository.Instance.GetBuildingsInfo(DAL.GlobalDataPool.Instance.Uid, bid);

            //bName.Text = buildingInfo.Address + buildingInfo.Price;

        }



    }
}
