using FangChan.WPFModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace House.UserControls.ViewModels
{
    public class MyCustomerViewModel : ViewModelBase
    {
        #region properties

        #region private property
        #endregion

        #region dataContext

        //客户列表
        private IEnumerable<NewFangRunningListItem> _keHuList;

        public IEnumerable<NewFangRunningListItem> KeHuList
        {
            get { return _keHuList; }
            set { Set(() => KeHuList, ref _keHuList, value); }
        }

        //选中的客户节点信息
        private NewFangRunningListItem _selectedItem;
        public NewFangRunningListItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(() => SelectedItem, ref _selectedItem, value);
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

        //当前浏览页面的页码
        private int _currentPageIndex = 1;
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set { Set(() => CurrentPageIndex, ref _currentPageIndex, value); }
        }

        #endregion

        #region Command
        //客户搜索命令
        public ICommand SearchCommand { get; private set; }

        //翻页命令
        public ICommand PageChangingCommand { get; private set; }
        #endregion

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public MyCustomerViewModel()
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
            //Messenger.Default.Register<int>(this, "CheckBaoBeiDetails", CheckBaoBeiDetails);
        }

        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommand()
        {
            SearchCommand = new RelayCommand<string>(OnExecuteKeHuSearchCmd);
            PageChangingCommand = new RelayCommand<string>(OnExecutePageChangeCmd);
        }

        private void OnExecuteKeHuSearchCmd(string searchingKey)
        {
            UpdateKeHuList(searchingKey, 1);
        }

        private void OnExecutePageChangeCmd(string pageIndex)
        {
            CurrentPageIndex = int.Parse(pageIndex);
            UpdateKeHuList(null, CurrentPageIndex);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //获取客户数据列表
            UpdateKeHuList();
        }

        /// <summary>
        /// 获取并更新视图列表
        /// </summary>
        /// <param name="searchingKey">搜索关键字 默认为NULL</param>
        /// <param name="pageIndex">页码 默认第一页</param>
        private void UpdateKeHuList(string searchingKey = null, int pageIndex = 1)
        {
            //第一页，10行数据，0代表全部信息， null代表要搜索的 关键词
            var kehulist = DAL.DataRepository.Instance.GetBuildingsOrdersList1(0, DAL.GlobalDataPool.Instance.Uid, pageIndex, PageSize);
            if (!kehulist.success) MessageBox.Show("获取客户列表信息失败！请喊汤老大！");

            //获得客户列表 和 总记录个数
            KeHuList = kehulist.data;
            TotalCounts = kehulist.TotalRows;

        }
    }
}
