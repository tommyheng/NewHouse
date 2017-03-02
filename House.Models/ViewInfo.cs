using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace House.Models
{



    /// <summary>
    /// 视图名称
    /// Description中是页面的程序集和类型字符串
    /// </summary>
    public enum ViewName
    {
        Unknown = 0,//枚举默认值为第一个从0开始

        /// <summary>
        /// 新房，主要业务内容界面，大的单窗体的壳
        /// </summary>
        [Description("House.NewHouse，House.NewHouse.Views.NewHouseView")]
        NewHouse,

        /// <summary>
        /// 管理中心
        /// </summary>
        [Description("House.UserControls,House.UserControls.Views.ManagementCentreView")]
        ManagementCenter,

        /// <summary>
        /// 楼盘列表（新房主页面）
        /// </summary>
        [Description("House.NewHouse,House.NewHouse.Views.LouPanView")]
        LouPanLieBiao,

        /// <summary>
        /// 楼盘详情
        /// </summary>
        [Description("House.UserControls,House.UserControls.Views.LouPanXiangQing")]
        LouPanXiangQing,

        /// <summary>
        /// 大菜单界面
        /// </summary>
        [Description("House.MainMenu,House.MainMenu.Views.MainMenuView2")]
        BigMenuView,


    }

    /// <summary>
    /// 视图类型
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// 普通的页面
        /// </summary>
        View,

        /// <summary>
        /// 模式对话框弹出窗体
        /// </summary>
        Popup,

        /// <summary>
        /// 单独的窗体
        /// </summary>
        SingleWindow
    }

    /// <summary>
    /// 视图信息
    /// </summary>
    public class ViewInfo
    {
        public ViewInfo(ViewName viewName = ViewName.Unknown, ViewType viewType = ViewType.View, object parameter = null)
        {
            ViewName = viewName;
            ViewType = viewType;
            Parameter = parameter;
        }
        public ViewName ViewName { get; set; }

        public ViewType ViewType { get; set; }

        public object Parameter { get; set; }
    }
}
