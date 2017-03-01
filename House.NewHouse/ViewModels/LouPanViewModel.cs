using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using House.DAL;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using House.Models;

namespace House.NewHouse.ViewModels
{
    public class LouPanViewModel : ViewModelBase
    {
        #region properties

        #region private property
        #endregion

        #region dataContext
        public class LouPanDataItem : ViewModelBase
        {
            //楼盘的ID
            public int ID { get; set; }

            //楼盘名称
            public string Name { get; set; }

            //楼盘佣金说明
            public string YongJin { get; set; }

            //楼盘列表图片文件名  Url：/Images/s   
            private string _imageUrl = null;

            public string ImageUrl
            {
                get { return _imageUrl; }
                set
                {
                    Set("ImageUrl", ref _imageUrl, value);
                    RaisePropertyChanged("ImageSource");
                }
            }

            public ImageSource ImageSource
            {
                get { return new BitmapImage(new Uri(_imageUrl)); }
            }

            //单价
            public string Price { get; set; }

            //带看佣金
            public string DaiKanYongJin { get; set; }

            //结算周期
            public string JieShuanZhouQi { get; set; }

            //是否有奖励
            public bool JiangLi { get; set; }

            //是否置顶 0不置顶，大于0置顶
            private int _zhiDing = int.MinValue;
            public int ZhiDing
            {
                get { return _zhiDing; }
                set { Set("ZhiDing", ref _zhiDing, value); }
            }

        }

        public ObservableCollection<LouPanDataItem> LouPanList;

        private LouPanDataItem _selectedItem;
        public LouPanDataItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set("SelectedItem", ref _selectedItem, value);
                NavigateToLouPanXiangQing();
            }
        }


        #endregion

        #region Command
        #endregion

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public LouPanViewModel()
        {
            InitCommand();
            InitData();
        }

        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommand()
        {

        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //获取楼盘数据列表
            //第一页，10行数据，0代表全部信息， null代表要搜索的 关键词
            var buildingslist = DAL.DataRepository.Instance.GetBuildingsList(DAL.GlobalDataPool.Instance.Uid, 1, 20, 0, null);
            if (!buildingslist.success) MessageBox.Show("获取楼盘列表信息失败！请喊汤老大！");

            //获得楼盘列表 和 总记录个数
            var buildings = buildingslist.data;
            var totalRows = buildingslist.TotalRows;

            var LouPanDataList = (from s in buildings
                                  select new LouPanDataItem
                                  {
                                      ID = s.ID,
                                      Name = s.Name,
                                      YongJin = s.YongJin,
                                      ImageUrl = DAL.DataRepository.Instance.ApiUrl + s.ImageUrl,
                                      Price = s.Price,
                                      DaiKanYongJin = s.DaiKanYongJin,
                                      JieShuanZhouQi = s.JieShuanZhouQi,
                                      JiangLi = s.JiangLi,
                                      ZhiDing = s.ZhiDing
                                  }).ToList();

            LouPanList = new ObservableCollection<LouPanDataItem>(LouPanDataList);
        }

        private void NavigateToLouPanXiangQing()
        {
            var selectedID = _selectedItem.ID;
            ViewInfo viewInfo = new ViewInfo(ViewName.LouPanXiangQing, ViewType.View, selectedID);

            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.NewHouseInternalNavigate);
        }
    }
}
