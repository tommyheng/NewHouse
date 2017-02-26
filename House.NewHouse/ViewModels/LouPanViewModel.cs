using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using House.DAL;

namespace House.NewHouse.ViewModels
{
    public class LouPanViewModel : ViewModelBase
    {
        #region properties

        #region private property
        #endregion

        #region dataContext
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
            var dr = DataRepository.Instance;
        }
    }
}
