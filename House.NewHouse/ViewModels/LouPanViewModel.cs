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
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using FangChan.WPFModel;
using System.Diagnostics;

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
                    Set(() => ImageUrl, ref _imageUrl, value);
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
                set { Set(() => ZhiDing, ref _zhiDing, value); }
            }

        }

        //楼盘列表
        private IEnumerable<LouPanDataItem> _louPanList;

        public IEnumerable<LouPanDataItem> LouPanList
        {
            get { return _louPanList; }
            set { Set(() => LouPanList, ref _louPanList, value); }
        }

        //选中的楼盘节点信息
        private LouPanDataItem _selectedItem;
        public LouPanDataItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(() => SelectedItem, ref _selectedItem, value);
                NavigateToLouPanXiangQing();
            }
        }

        //所有记录的个数
        private int _totalCounts = 0;
        public int TotalCounts
        {
            get { return _totalCounts; }
            set { Set(() => TotalCounts, ref _totalCounts, value); }
        }

        //每页显示的记录个数
        private int _pageSize = 20;
        public int PageSize
        {
            get { return _pageSize; }
            set { Set(() => PageSize, ref _pageSize, value); }
        }

        //搜索字符串
        private string _searchingKey = null;
        public string SearchingKey
        {
            get { return _searchingKey; }
            set { Set(() => SearchingKey, ref _searchingKey, value); }
        }

        //所在城市包含的区域列表
        public List<DiQuModel> RegionList { get; set; }

        //选择的区域ID
        private int _selectedRegionID;
        public int SelectedRegionID
        {
            get { return _selectedRegionID; }
            set
            {
                Set(() => SelectedRegionID, ref _selectedRegionID, value);
                UpdateLouPanList(_selectedRegionID);
            }
        }

        //当前浏览页面的页码
        private int _currentPageIndex = 1;
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set { Set(() => CurrentPageIndex, ref _currentPageIndex, value); }
        }

        //用户所在城市
        public string City
        {
            get { return DAL.GlobalDataPool.Instance.LoginData.DiQu.Name; }
        }
        #endregion

        #region Command
        //楼盘搜索命令
        public ICommand SearchCommand { get; private set; }

        //区域筛选命令
        public ICommand RegionFilterCommand { get; private set; }

        //翻页命令
        public ICommand PageChangingCommand { get; private set; }
        #endregion

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public LouPanViewModel()
        {
            InitMessenger();
            InitCommand();
            InitData();
            
        }

        /// <summary>
        /// 初始化 Messenger
        /// </summary>
        private void InitMessenger()
        {
            Messenger.Default.Register<int>(this, "LouPanItemZhiDing", LouPanItemZhiDing);
        }

        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommand()
        {
            SearchCommand = new RelayCommand<string>(OnExecuteLouPanSearchCmd);
            PageChangingCommand = new RelayCommand<string>(OnExecutePageChangeCmd);
        }

        private void OnExecuteLouPanSearchCmd(string searchingKey)
        {
            UpdateLouPanList(SelectedRegionID, searchingKey, 1);
        }

        private void OnExecutePageChangeCmd(string pageIndex)
        {
            CurrentPageIndex = int.Parse(pageIndex);
            UpdateLouPanList(SelectedRegionID, null, CurrentPageIndex);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //获取区域列表
            RegionList = GlobalDataPool.Instance.LoginData.DiQuList;
            //获取楼盘数据列表
            UpdateLouPanList();
        }
        /// <summary>
        /// 置顶/取消置顶
        /// </summary>
        /// <param name="louPanID">选中的楼盘ID</param>
        private void LouPanItemZhiDing(int louPanID)
        {
            var rst = DataRepository.Instance.SetOrCancelTop(DAL.GlobalDataPool.Instance.Uid, louPanID);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
                return;
            }

            UpdateLouPanList(SelectedRegionID, SearchingKey, CurrentPageIndex);
            Debug.WriteLine("发出置顶/取消置顶请求，楼盘ID：{0}", louPanID);
        }

        /// <summary>
        /// 获取并更新视图列表
        /// </summary>
        /// <param name="regionID">区域ID 默认0：全部区域</param>
        /// <param name="searchingKey">搜索关键字 默认为NULL</param>
        /// <param name="pageIndex">页码 默认第一页</param>
        private void UpdateLouPanList(int regionID = 0, string searchingKey = null, int pageIndex = 1)
        {
            //第一页，10行数据，0代表全部信息， null代表要搜索的 关键词
            var buildingslist = DAL.DataRepository.Instance.GetBuildingsList(DAL.GlobalDataPool.Instance.Uid, pageIndex, PageSize, regionID, searchingKey);
            if (!buildingslist.success) MessageBox.Show("获取楼盘列表信息失败！请喊汤老大！");

            //获得楼盘列表 和 总记录个数
            var buildings = buildingslist.data;
            TotalCounts = buildingslist.TotalRows;

            var LouPanDataList = from s in buildings
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
                                 };

            LouPanList = LouPanDataList;

        }


        private void NavigateToLouPanXiangQing()
        {
            var selectedID = _selectedItem.ID;
            ViewInfo viewInfo = new ViewInfo(ViewName.LouPanXiangQing, ViewType.View, selectedID);

            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.NewHouseInternalNavigate);
        }
    }
}
