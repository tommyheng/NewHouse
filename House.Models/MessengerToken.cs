using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace House.Models
{
    public enum MessengerToken
    {
        /// <summary>
        /// 默认值
        /// </summary>
        UnKnown,

        /// <summary>
        /// 切换主菜单到小窗体
        /// </summary>
        SwitchMainMenuToSmall,


        /// <summary>
        /// 主菜单视图跳转
        /// </summary>
        MainMenuNavigate,

        /// <summary>
        /// 关闭应用
        /// </summary>
        ShutdownApp,

        /// <summary>
        /// 新房窗体内部跳转
        /// </summary>
        NewHouseInternalNavigate




    }
}
