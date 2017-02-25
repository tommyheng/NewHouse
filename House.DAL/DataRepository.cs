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

        #region 下行数据（获取数据接口）

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
        public ZhiYeGuWenList GetPropertyConsultantList(int bId)
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
        /// 颜色1绿   2灰   3橙色
        /// </summary>
        public NewFangRunningsModel GetBuildingsOrder(int id)
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

        #endregion

        #region 上行接口（提交数据接口）
        ///<summary>
        /// 1.修改个人资料
        /// /App/UpdateUserInfo
        /// 参数：
        /// UserID：修改者ID
        /// UserName：姓名
        /// XingBie：性别(先生/女士)
        /// FuWuXuanYan：服务宣言
        /// ChongYeNianXian：从业年限
        ///</summary>
        public ApiResultModelBase UpdateUserInfo(int uId, string uName, string sex, string declaration, int years)
        {
            string url = string.Format("{0}App/UpdateUserInfo", ApiUrl);

            string postData = string.Format("UserID={0}&UserName={1}&XingBie={2}&FuWuXuanYan={3}&ChongYeNianXian={4}",
                 uId, uName, sex, declaration, years);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 2.获得修改密码验证码
        /// /App/GetRePassSMSCode
        /// 参数：
        /// LoginName：当前用户登录手机号
        ///</summary>
        public ApiResultModelBase GetRePassSMSCode(string phone)
        {
            string url = string.Format("{0}App/GetRePassSMSCode", ApiUrl);

            string postData = string.Format("LoginName={0}", phone);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        ///3.修改密码
        /// /App/RePass
        /// 参数：
        /// LoginName
        /// LoginPass
        /// SMSCode
        ///</summary>
        public ApiResultModelBase RePass(string uName, string pwd, string SMSCode)
        {
            string url = string.Format("{0}App/RePass", ApiUrl);

            string postData = string.Format("LoginName={0}&LoginPass={1}&SMSCode={2}",
                 uName, pwd, SMSCode);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 4.获得修改手机验证码
        /// /App/GetReLoginNameSMSCode
        /// 参数：
        /// OldLoginName：用户当前登录手机号
        /// NewLoginName：用户新登录手机号
        ///</summary>
        public ApiResultModelBase GetReLoginNameSMSCode(string oldPhone, string newPhone)
        {
            string url = string.Format("{0}App/GetReLoginNameSMSCode", ApiUrl);

            string postData = string.Format("OldLoginName={0}&NewLoginName={1}",
                 oldPhone, newPhone);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 5.修改手机号码
        /// /App/ReLoginName
        /// 参数：
        /// OldLoginName：用户当前登录手机号
        /// NewLoginName：用户新登录手机号
        /// SMSCode：验证码
        ///</summary>
        public ApiResultModelBase ReLoginName(string oldPhone, string newPhone, string SMSCode)
        {
            string url = string.Format("{0}App/ReLoginName", ApiUrl);

            string postData = string.Format("OldLoginName={0}&NewLoginName={1}&SMSCode={2}",
                 oldPhone, newPhone, SMSCode);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 6.添加修改客户
        /// /App/KeHuAdd
        /// 参数：
        /// UserID
        /// KeHu：这是个JSON用来传客户信息
        /// 外层ID写0表示新添加的客户，不是0表示修改现有客户
        /// 电话里的ID写0表示新添加的电话，非0表示修改已有电话        
        /// </summary>
        public ApiResultModelBase AddOrModifyCustomer(int uId, AddKeHuModel customer)
        {
            string url = string.Format("{0}App/KeHuAdd", ApiUrl);

            string str = ValueConvert.ObjToJsonStr(customer);

            string postData = string.Format("UserID={0}&KeHu={1}",
                 uId, str);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 7.报备客户
        /// /App/BaoBeiKeHu
        /// 参数：
        /// UserID：操作人ID
        /// KeHuID：客户ID
        /// LouPanID：楼盘ID
        /// KeHuDianHuaID：客户电话ID
        ///</summary>
        public ApiResultModelBase RecordCustomer(int uId, int cId, int bId, int pId)
        {
            string url = string.Format("{0}App/BaoBeiKeHu", ApiUrl);

            string postData = string.Format("UserID={0}&KeHuID={1}&LouPanID={2}&KeHuDianHuaID={3}",
                 uId, cId, bId, pId);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }

        ///<summary>
        /// 8.上传带看确认单图片(进度说明第2条第3条中间)
        /// /App/DaiKanQueRenImageUpLoad
        /// 参数：
        /// ID：新房定单ID
        /// DaiKanQueRenImage：图片本地路径
        ///</summary>
        public UploadImageModel1 UploadLookHouseImage(int oId, string imgPath)
        {
            string url = string.Format("{0}App/DaiKanQueRenImageUpLoad", ApiUrl);
            FangChan.Common.WebClient wc = new FangChan.Common.WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            FangChan.Common.MultipartForm mf = new FangChan.Common.MultipartForm();
            mf.AddFlie("DaiKanQueRenImage", imgPath);
            mf.AddString("ID", oId.ToString());
            string s = wc.Post(url, mf);

            return ValueConvert.StrToObj<UploadImageModel1>(s);
        }

        ///<summary>
        /// 9.上传成交确认单图片(进度说明第3条第4条中间)
        /// /App/ChengJiaoQueRenImageUpLoad
        /// 参数：
        /// ID：新房定单ID
        /// DaiKanQueRenImage：图片
        ///</summary>
        public UploadImageModel2 UploadDealHouseImage(int oId, string imgPath)
        {
            string url = string.Format("{0}App/ChengJiaoQueRenImageUpLoad", ApiUrl);
            FangChan.Common.WebClient wc = new FangChan.Common.WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            FangChan.Common.MultipartForm mf = new FangChan.Common.MultipartForm();
            mf.AddFlie("DaiKanQueRenImage", imgPath);
            mf.AddString("ID", oId.ToString());
            string s = wc.Post(url, mf);

            return ValueConvert.StrToObj<UploadImageModel2>(s);
        }
        ///<summary>
        /// 10.删除图片(带看和成交都是这个)
        /// /App/DaiKanQueRenImageDel
        /// 参数：
        /// ID：图片ID
        ///</summary>
        public ApiResultModelBase DeleteImage(int imgId)
        {
            string url = string.Format("{0}App/DaiKanQueRenImageDel", ApiUrl);

            string postData = string.Format("ID={0}",
                 imgId);

            return httpHelper.PostAndGetEntity<ApiResultModelBase>(
                   url,
                   postData,
                   null,
                   null,
                   false,
                   Encoding.UTF8);
        }
        #endregion
    }
}

