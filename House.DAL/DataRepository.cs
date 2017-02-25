using FangChan.WPFModel;
using House.Utility;
using House.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.DAL
{
    public class DataRepository
    {
        private volatile static DataRepository _instance = null;
        private static readonly object lockHelper = new object();
        private static HttpHelper httpHelper = new HttpHelper();
        public string ApiUrl
        {
            get
            {
                return ConfigHelper.GetAppSetting("ApiUrl");
            }
        }
        private DataRepository() { }
        public static DataRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 登录反回信息
        /// Url:/App/Login
        /// 参数：LoginName    登录名
        ///       LoginPass    登录密码
        /// </summary>
        public LoginStateModel Login(string name, string pwd)
        {
            string url = string.Format("{0}App/Login", ApiUrl);

            string postData = string.Format("LoginName={0}&LoginPass={1}", name.Trim(), pwd.Trim());

            return httpHelper.PostAndGetEntity<LoginStateModel>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }


        /// <summary>
        /// 返回新房楼盘列表信息
        /// Url:/App/GetLouPanShowListForDiQuID
        /// 参数：UserID    请求人UserID
        ///       DiQuID    区域筛选ID
        ///       Name      搜索关键字
        ///       Page      页码
        ///       Rows      第页记录数
        /// </summary>
        public LouPanListShowList GetBuildingsList(int uId, int pageIndex, int rows, int areaId, string key)
        {
            string url = string.Format("{0}App/GetLouPanShowListForDiQuID", ApiUrl);

            string postData = string.Format("UserID={0}&DiQuID={1}&Name={2}&Page={3}&Rows={4}",
                uId, areaId, key, pageIndex, rows);

            return httpHelper.PostAndGetEntity<LouPanListShowList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 返回新房楼盘详细信息
        /// Url:/App/GetLouPanModel
        /// 参数：UserID    请求人UserID
        ///       LouPanID    查询楼盘ID
        /// </summary>
        public ReturnLouPanModel GetBuildingsInfo(int uId, int bId)
        {
            string url = string.Format("{0}App/GetLouPanModel", ApiUrl);

            string postData = string.Format("UserID={0}&LouPanID={1}", uId, bId);

            return httpHelper.PostAndGetEntity<ReturnLouPanModel>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 返回新房楼盘置业顾问信息
        /// Url:/App/GetZhiYeGuWenList
        /// 参数：LouPanID    查询楼盘ID
        /// </summary>
        public ZhiYeGuWenList GetPropertyConsultantList(string bId)
        {
            string url = string.Format("{0}App/GetZhiYeGuWenList", ApiUrl);

            string postData = string.Format("LouPanID={0}", bId);

            return httpHelper.PostAndGetEntity<ZhiYeGuWenList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 返回新房订单信息
        /// 1、获得楼盘详情里我的客户
        ///     Url:/App/GetNewFangRunningsList
        ///     参数：LouPanID 查询楼盘ID
        ///           UserID   请求人UserID
        ///           Page      页码
        ///           Rows      每页行数
        /// </summary>
        public NewFangRunningsList GetBuildingsOrdersList1(int bId, int uId, int pageIndex, int rows)
        {
            string url = string.Format("{0}App/GetNewFangRunningsList", ApiUrl);

            string postData = string.Format("LouPanID={0}&UserID={1}&Page={2}&Rows={3}",
                bId, uId, pageIndex, rows);

            return httpHelper.PostAndGetEntity<NewFangRunningsList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 返回新房订单信息
        /// 2、获得我报备的新房订单
        ///     Url:/App/GetNewFangRunningsList
        ///     参数：Name     搜索关键字
        ///           UserID   请求人UserID
        ///           Page      页码
        ///           Rows      每页行数
        /// 
        /// </summary>
        public NewFangRunningsList GetBuildingsOrdersList2(string key, int uId, int pageIndex, int rows)
        {
            string url = string.Format("{0}App/GetNewFangRunningsList", ApiUrl);

            string postData = string.Format("Name={0}&UserID={1}&Page={2}&Rows={3}",
                key, uId, pageIndex, rows);

            return httpHelper.PostAndGetEntity<NewFangRunningsList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }


        /// <summary>
        /// 返回客户列表
        /// 1、楼盘详情报备客户
        ///     Url:/App/GetKeHuShowList
        ///     参数：ChaXunLouPanID 查询楼盘ID
        ///           UserID   请求人UserID
        ///           Page      页码
        ///           Rows      每页行数
        /// </summary>
        public KeHuShowList GetBuildingsCustomerList1(int bId, int uId, int pageIndex, int rows)
        {
            string url = string.Format("{0}App/GetKeHuShowList", ApiUrl);

            string postData = string.Format("ChaXunLouPanID={0}&UserID={1}&Page={2}&Rows={3}",
                bId, uId, pageIndex, rows);

            return httpHelper.PostAndGetEntity<KeHuShowList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 2、所有客户
        ///     Url:/App/GetKeHuShowList
        ///     参数：UserName 搜索关键字
        ///           UserID   请求人UserID
        ///           Page      页码
        ///           Rows      每页行数
        /// 
        /// </summary>
        public KeHuShowList GetBuildingsCustomerList2(string key, int uId, int pageIndex, int rows)
        {
            string url = string.Format("{0}App/GetKeHuShowList", ApiUrl);

            string postData = string.Format("UserName={0}&UserID={1}&Page={2}&Rows={3}",
                key, uId, pageIndex, rows);

            return httpHelper.PostAndGetEntity<KeHuShowList>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        /// <summary>
        /// 新房订单详情
        /// Url:/App/GetNewFangRunningModel
        /// 参数：ID   查询订单ID
        /// 
        /// 颜色1绿   2灰   3橙色
        /// </summary>
        public NewFangRunningsModel GetBuildingsOrders(string id)
        {
            string url = string.Format("{0}App/GetNewFangRunningModel", ApiUrl);

            string postData = string.Format("ID={0}", id);

            return httpHelper.PostAndGetEntity<NewFangRunningsModel>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }
    }
}

