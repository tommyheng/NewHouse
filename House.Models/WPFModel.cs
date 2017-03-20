using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FangChan.WPFModel
{
    #region ================= 新房和用户中心等 ==================
    public class ApiResultModelBase
    {
        //登录是否成功
        public bool success { get; set; }

        //错误信息
        public string message { get; set; }
    }

    public class UploadImageModel1 : ApiResultModelBase
    {
        //登录是否成功
        public string DaiKanQueRenImage { get; set; }
    }

    public class UploadImageModel2 : ApiResultModelBase
    {
        //登录是否成功
        public string ChengJiaoQueRenImage { get; set; }
    }

    /// <summary>
    /// 公告数据model
    /// </summary>
    public class GongGaoTextItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
    }

    /// <summary>
    /// 请求公告数据结果
    /// </summary>
    public class GongGaoTextList
    {
        public bool success { get; set; }

        public string message { get; set; }
        public List<GongGaoTextItem> GongGaoList { get; set; }
    }

    /// <summary>
    /// 修改头像
    /// </summary>
    public class UploadImageModel3 : ApiResultModelBase
    {
        //登录是否成功
        public string TouXiang { get; set; }
    }


    /// <summary>
    /// 添加或者修改客户
    /// 外层ID写0表示新添加的客户，不是0表示修改现有客户
    /// 电话里的ID写0表示新添加的电话，非0表示修改已有电话
    /// </summary>
    public class AddKeHuModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string XingBie { get; set; }
        public List<DianHuaModel> KeHuDianHua { get; set; }

    }

    /// <summary>
    /// 登录反回信息
    /// Url:/App/Login
    /// 参数：LoginName    登录名
    ///       LoginPass    登录密码
    /// </summary>
    public class LoginStateModel
    {
        //登录是否成功
        public bool success { get; set; }

        //错误信息
        public string message { get; set; }

        //个人信息
        public GeRenXinXi GeRenXinXi { get; set; }

        //已不用
        public List<QuYuModel> QuYuList { get; set; }

        //当前城市地区列表
        public List<DiQuModel> DiQuList { get; set; }

        //户型标签
        public List<HuXingTagModel> HuXingTag { get; set; }

        //新房流程状态
        public List<MaiFangRunningState> MaiFangRunningState { get; set; }

        //装修流程状态
        public List<MaiFangRunningState> ZhuangXiuRunningState { get; set; }

        //住宅类别
        public List<QuYuModel> ZhuZhaiLeiBie { get; set; }

        //家政类型
        public List<QuYuModel> JiaZhengType { get; set; }

        //当前所在城市
        public DiQuModel DiQu { get; set; }

        //显示哪些功能
        //1	 新房
        //2	 二手房
        //3	 租房
        //4	 顶帐房
        //5	 装修
        //6	 活动
        //7	 金融
        //8	 家政
        //9	 旅游
        //10 房贷计算器
        //11 门票
        public List<int> Tabs { get; set; }
    }

    /// <summary>
    /// 个人信息
    /// </summary>
    public class GeRenXinXi
    {
        //个人资料
        public UserModel UserInfo { get; set; }

        //所在门店
        public string MenDianName { get; set; }

        //业务员信息
        public UserModel ShangJiUserInfo { get; set; }

        //版本流水号
        public int versionCode { get; set; }

        //片本号串
        public string versionName { get; set; }

        //下载地址
        public string DownLoadUrl { get; set; }

        //是否可以报备金融服务
        public int IsBaoBeiJinRong { get; set; }
    }

    /// <summary>
    /// 人员资料
    /// </summary>
    public class UserModel
    {
        //ID
        public int ID { get; set; }

        //姓名
        public string UserName { get; set; }

        //电话
        public string DianHua { get; set; }

        //性别  先生/女士
        public string XingBie { get; set; }

        //职务
        public string ZhiWu { get; set; }

        //从业所限
        public int CongYeNianXian { get; set; }

        //服务宣言
        public string FuWuXuanYan { get; set; }

        //头像  Url:/Images/TouXiang/
        public string TouXiang { get; set; }

        //用户类型
        public int UserType { get; set; }

        //登录名
        public string LoginName { get; set; }

        //区域代理编号
        public int SysDaiLiID { get; set; }

        //区域代理名称
        public string SysDaiLiName { get; set; }

        //状态
        public int State { get; set; }

        //状态
        public int state { get; set; }

        //角色  1经纪人   2店长
        public int JueShe { get; set; }
    }


    public class QuYuModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class DiQuModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class MaiFangRunningState
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class HuXingTagModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
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

    public class LouPanListShowList
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //楼盘列表
        public List<LouPanListShowModel> data { get; set; }
        //客户是否显示红点（不用）
        public int KeHuHongDian { get; set; }
        //新房楼盘总记录数
        public int TotalRows { get; set; }
    }
    /// <summary>
    /// 楼盘列表项信息
    /// </summary>
    public class LouPanListShowModel
    {
        //楼盘的ID
        public int ID { get; set; }
        //已弃用
        public int QuYuID { get; set; }
        //楼盘名称
        public string Name { get; set; }
        //楼盘佣金说明
        public string YongJin { get; set; }
        //推荐户型
        public string[] TuiJianHuXing { get; set; }
        //楼盘列表图片文件名  Url：/Images/s
        public string ImageUrl { get; set; }
        //是否收藏
        public bool IsShouChang { get; set; }
        //单价
        public string Price { get; set; }
        //带看佣金
        public string DaiKanYongJin { get; set; }
        //合作经纪人数量
        public int HeZhuoJingJiRenNumber { get; set; }
        //意向客户数量
        public int YiXiangKeHuNumber { get; set; }
        //最近成交数量
        public int ZhuiJinChengJiao { get; set; }
        //结算周期
        public string JieShuanZhouQi { get; set; }
        //是否有奖励
        public bool JiangLi { get; set; }
        //是否置顶 0不置顶，大于0置顶
        public int ZhiDing { get; set; }

    }
    /// <summary>
    /// 返回新房楼盘详细信息
    /// Url:/App/GetLouPanModel
    /// 参数：UserID    请求人UserID
    ///       LouPanID    查询楼盘ID
    /// </summary>

    public class ReturnLouPanModel
    {
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //楼盘详细
        public LouPanModel data { get; set; }
    }

    public class LouPanModel
    {
        //楼盘ID
        public int ID { get; set; }
        //楼盘名称
        public string Name { get; set; }
        //楼盘说明
        public string Remark { get; set; }
        //楼盘单价
        public string Price { get; set; }
        //楼盘地址
        public string Address { get; set; }
        //楼盘所在地区
        public string QuYu { get; set; }
        //楼盘佣金说明
        public string YongJin { get; set; }
        //楼盘带看佣金说明
        public string DaiKanYongJin { get; set; }
        //是否收藏
        public bool IsShouChang { get; set; }
        //收藏人数
        public int ShouChangNumber { get; set; }
        //意向客户数量
        public int YiXiangKeHuNumber { get; set; }
        //合作经纪人数量
        public int HeZhuoJingJiRenNumber { get; set; }
        //最近成交数量
        public int ZhuiJinChengJiao { get; set; }
        //我的客户数量
        public int WoDeKeHuNumber { get; set; }
        //户型列表
        public List<HuXingModel> HuXing { get; set; }
        //楼盘业务人员列表
        public List<UserModel> Users { get; set; }
        //楼盘图片文件名  Url:/Images/
        public List<ImageModel> Images { get; set; }
        //楼盘详情
        public LouPanXiangQing XiangQing { get; set; }
        //开户商规则
        public KaiFaShangGuiZheModel KaiFaShangGuiZhe { get; set; }
        //楼盘卖点
        public List<TitleContentModel> MaiDian { get; set; }
        //弃用
        public double X { get; set; }
        //弃用
        public double Y { get; set; }
        //弃用
        public string ZhiYeGuWenZhiWu { get; set; }
        //弃用
        public string ZhiYeGuWenName { get; set; }
        //弃用
        public string ZhiYeGuWenDianHua { get; set; }
    }
    /// <summary>
    /// 开发商规则
    /// </summary>
    public class KaiFaShangGuiZheModel
    {
        //合作时间
        public string HeZhuoShiJian { get; set; }
        //认购截止时间
        public string RenGouJieZhi { get; set; }
        //合作房源
        public string HeZhuoFangYuan { get; set; }
        //规则
        public string GuiZhe { get; set; }
        //奖励
        public string JiangLi { get; set; }
        //结算周期
        public string JieShuanZhouQi { get; set; }
        //报备规则
        public string BaoBeiGuiZhe { get; set; }
        //带看规则
        public string DaiKanGuiZhe { get; set; }
        //成交规则
        public string ChengJiaoGuiZhe { get; set; }
    }
    /// <summary>
    /// 户型详情
    /// </summary>
    public class HuXingModel
    {
        //户型ID
        public int ID { get; set; }
        //户型名称
        public string Name { get; set; }
        //户型说明
        public string Remark { get; set; }
        //面积
        public decimal MianJi { get; set; }
        //价格
        public string Price { get; set; }
        //库存数量
        public int KuChun { get; set; }
        //已售数量
        public int YiShou { get; set; }
        //户型标签
        public string[] Tag { get; set; }
        //户型图片名称  Url:/Images/
        public List<ImageModel> Images { get; set; }
        //户型详情
        public HuXingXiangQingModel XiangQing { get; set; }
        //户型佣金
        public string YongJin { get; set; }
        //结算周期
        public string YongJinJieDian { get; set; }

    }

    //户型详情
    public class HuXingXiangQingModel
    {
        //优惠
        public string HuXingYouHui { get; set; }
        //朝向
        public string ChaoXiang { get; set; }
        //装修状况
        public string ZhuangXiuQingKuang { get; set; }
        //推荐理由
        public string TuiJianLiYou { get; set; }
    }
    /// <summary>
    /// 图片
    /// </summary>
    public class ImageModel
    {
        //类型
        public int ImageType { get; set; }
        //索引
        public int ImageIndex { get; set; }
        //文件名
        public string ImageUrl { get; set; }
        //标记
        public string Tag { get; set; }
    }
    /// <summary>
    /// 楼盘详情
    /// </summary>
    public class LouPanXiangQing
    {
        //开盘时间
        public string KaiPanTime { get; set; }
        //交房时间
        public string JiaoFangTime { get; set; }
        //开发商
        public string KaiFaShang { get; set; }
        //开发商品牌
        public string KaiFaShangPinPai { get; set; }
        //物业公司
        public string WuYeGongShi { get; set; }
        //建筑面积
        public string JianZhuMianJi { get; set; }
        //总户数
        public string ZhongHuShu { get; set; }
        //容积率
        public string RongJiLv { get; set; }
        //绿化率
        public string LvHuaLv { get; set; }
        //车位数
        public string CheWeiShu { get; set; }
        //车位比
        public string CheWeiBi { get; set; }
        //均价
        public string JunJia { get; set; }
        //物业费
        public string WuYeFei { get; set; }
        //建筑类型
        public string JianZhuLeiXing { get; set; }
        //装修状况
        public string ZhuangXiuZhongKuang { get; set; }
        //产权年限
        public string ChanQuanNianXian { get; set; }
    }
    public class TitleContentModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// 返回新房楼盘置业顾问信息
    /// Url:/App/ZhiYeGuWenList
    /// 参数：LouPanID    查询楼盘ID
    /// </summary>
    public class ZhiYeGuWenList
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //置业顾问列表
        public List<ZhiYeGuWenListItem> data { get; set; }
    }
    /// <summary>
    /// 置业顾问信息
    /// </summary>
    public class ZhiYeGuWenListItem
    {
        //ID
        public int ID { get; set; }
        //姓名
        public string Name { get; set; }
        //职务
        public string ZhiWu { get; set; }
        //电话
        public string DianHua { get; set; }
        //说明
        public string Remark { get; set; }
        //楼盘ID
        public int LouPanID { get; set; }
        //楼盘名称
        public string LouPanName { get; set; }
    }


    /// <summary>
    /// 返回新房订单信息
    /// 1、获得楼盘详情里我的客户
    ///     Url:/App/GetNewFangRunningsList
    ///     参数：LouPanID 查询楼盘ID
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 2、获得我报备的新房订单
    ///     Url:/App/GetNewFangRunningsList
    ///     参数：Name     搜索关键字
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 
    /// </summary>
    public class NewFangRunningsList
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //新房订单列表
        public List<NewFangRunningListItem> data { get; set; }
        //总行数
        public int TotalRows { get; set; }
    }
    /// <summary>
    /// 新房订单信息
    /// </summary>
    public class NewFangRunningListItem
    {
        //流水号
        public int ID { get; set; }
        //楼盘名称
        public string LouPanName { get; set; }
        //客户姓名
        public string KeHuName { get; set; }
        //客户电话
        public string KeHuDianHua { get; set; }
        //经纪人姓名
        public string JingJiRenName { get; set; }
        //经纪人电话
        public string JingJiRenDianHua { get; set; }
        //佣金
        public decimal YongJin { get; set; }
        //已结佣金
        public decimal YiJieYongJin { get; set; }
        //未结佣金
        public decimal WeiJieYongJIn { get; set; }
        //税点
        public decimal ShuiDian { get; set; }
        //最后操作时间
        public string LastTime { get; set; }
        //状态说明
        public string State { get; set; }
    }

    /// <summary>
    /// 返回客户列表
    /// 1、楼盘详情报备客户
    ///     Url:/App/GetKeHuShowList
    ///     参数：ChaXunLouPanID 查询楼盘ID
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 2、所有客户
    ///     Url:/App/GetKeHuShowList
    ///     参数：UserName 搜索关键字
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 
    /// </summary>
    public class KeHuShowList
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //客户列表
        public List<KeHuShowListItem> KeHuList { get; set; }
        //总行数
        public int TotalRows { get; set; }
    }
    /// <summary>
    /// 客户列表详情
    /// </summary>
    public class KeHuShowListItem
    {
        //客户ID
        public int ID { get; set; }
        //客户姓名
        public string UserName { get; set; }
        //客户性别(先生/女士)
        public string XingBie { get; set; }
        //已弃用
        public string DianHua { get; set; }
        //已弃用
        public string YiXiang { get; set; }
        //订单状态说明
        public string MaiFangRunning { get; set; }
        //是否显示经点
        public bool HongDian { get; set; }
        //电话列表
        public List<DianHuaModel> DianHuaList { get; set; }
        //新房是否已报备(报备新房用这个，)
        public bool LouPanBaoBei { get; set; }
        //抵帐房是否已报备
        public bool DiZhangFangBaoBei { get; set; }
        //装修是否已报备
        public bool ZhuangXiuGongShiBaoBei { get; set; }
        //家政是否已报备
        public bool JiaZhengGongShiBaoBei { get; set; }
        //金融是否已报备
        public bool JinRongTypeBaoBei { get; set; }
    }

    public class KeHuShowListItemInfo : KeHuShowListItem
    {
        public string StateInfo { get; set; }

    }
    /// <summary>
    /// 电话列表详细
    /// </summary>
    public class DianHuaModel
    {
        //客户电话ID
        public int ID { get; set; }
        //客户电话
        public string DianHua { get; set; }
        public string Remark { get; set; }
        public bool IsMoRen { get; set; }
    }
    /// <summary>
    /// 返回客户列表
    /// 新房订单详情
    /// Url:/App/GetNewFangRunningModel
    /// 参数：ID   查询订单ID
    /// 
    /// 颜色1绿   2灰   3橙色
    /// </summary>
    public class NewFangRunningsModel
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //订单详情
        public RunningsModel data { get; set; }
    }
    /// <summary>
    /// 订单详情
    /// </summary>
    public class RunningsModel
    {
        //流水号
        public int ID { get; set; }
        //进度条
        public MaiFangJinDuTiaoModel JinDuTiao { get; set; }
        //进度说明 注：从上到下5条 第2条第3条中间放带看图片列表，第3第4放成交图片表表。
        public List<MaiFangJinDuListModel> JinDuText { get; set; }
        //带看图片列表
        public List<ImageModel> DaiKanQueRenImage { get; set; }
        //成交图片列表
        public List<ImageModel> ChengJiaoQueRenImage { get; set; }
    }
    /// <summary>
    /// 进度条
    /// </summary>
    public class MaiFangJinDuTiaoModel
    {
        //点1颜色
        public string Dian1Color { get; set; }
        //点1文本
        public string Dian1Text { get; set; }
        //点2颜色
        public string Dian2Color { get; set; }
        //点2文本
        public string Dian2Text { get; set; }
        //点3颜色
        public string Dian3Color { get; set; }
        //点3文本
        public string Dian3Text { get; set; }
        //点4颜色
        public string Dian4Color { get; set; }
        //点4文本
        public string Dian4Text { get; set; }
        //线1颜色
        public string Xian1Color { get; set; }
        //线1第1行文本
        public string Xian1Text1 { get; set; }
        //线1第1行文本颜色
        public string Xian1Text1Color { get; set; }
        //线1第2行文本
        public string Xian1Text2 { get; set; }
        //线1第2行文本颜色
        public string Xian1Text2Color { get; set; }
        //线2颜色
        public string Xian2Color { get; set; }
        //线2第1行文本
        public string Xian2Text1 { get; set; }
        //线2第1行文本颜色
        public string Xian2Text1Color { get; set; }
        //线2第2行文本
        public string Xian2Text2 { get; set; }
        //线2第2行文本颜色
        public string Xian2Text2Color { get; set; }
        //线3颜色
        public string Xian3Color { get; set; }
        //线3第1行文本
        public string Xian3Text1 { get; set; }
        //线3第1行文本颜色
        public string Xian3Text1Color { get; set; }
        //线3第2行文本
        public string Xian3Text2 { get; set; }
        //线3第2行文本颜色
        public string Xian3Text2Color { get; set; }
        //弃用
        public int JinDu { get; set; }

    }
    /// <summary>
    /// 进度文本说明
    /// </summary>
    public class MaiFangJinDuListModel
    {
        //左边文字
        public string LeftText { get; set; }
        //左边颜色
        public string LeftTextColor { get; set; }
        //用不上
        public int RightTextType { get; set; }
        //右边文字
        public string RightText { get; set; }
        //右边颜色
        public string RightTextColor { get; set; }

    }

    #endregion

    #region ==================== 装修 ================================

    /// <summary>
    /// 返回装修公司列表信息
    /// Url:/App/GetZhuangXiuGongShiShowList
    /// 参数：UserID    请求人UserID
    ///       DiQuID    区域筛选ID
    ///       Page      页码
    ///       Rows      第页记录数
    /// </summary>
    public class ZhuangXiuGongShiShowList
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //装修公司列表
        public List<ZhuangXiuGongShiShowListItem> data { get; set; }
        //装修公司总记录数
        public int TotalRows { get; set; }
    }
    public class ZhuangXiuGongShiShowListItem
    {
        //流水号
        public int RowID { get; set; }
        //ID
        public int ID { get; set; }
        //名称
        public string Name { get; set; }
        //区域
        public string DiQuName { get; set; }
        //奖励
        public string JiangLi { get; set; }
        //佣金
        public string YongJin { get; set; }
        //结算周期
        public string YongJinZhangQi { get; set; }
        //图片（/Images/）
        public string ImageUrl { get; set; }
        //带看条件
        public string DaiKanTiaoJian { get; set; }
        //结算条件
        public string JieShuanTiaoJian { get; set; }
    }

    /// <summary>
    /// 返回装修公司详细信息
    /// Url:/App/GetZhuangXiuGongShiModel
    /// 参数：UserID                请求人UserID
    ///       ZhuangXiuGongShiID    装修公司ID
    /// </summary>
    public class ReturnZhuangXiuGongShiModel
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //装修公司信息（是个数组，第一条就行）
        public List<ZhuangXiuGongShiModel> data { get; set; }
    }
    public class ZhuangXiuGongShiModel
    {
        //ID
        public int ID { get; set; }
        //名称
        public string Name { get; set; }
        //说明
        public string Remark { get; set; }
        //地址
        public string Address { get; set; }
        //区域
        public string DiQuName { get; set; }
        //佣金标题
        public string YongJin { get; set; }
        //佣金详情
        public string GuiZhe { get; set; }
        //合作经纪人数量
        public int HeZhuoJingJiRenNumber { get; set; }
        //意向客户数量
        public int YiXiangKeHuNumber { get; set; }
        //结算周期
        public string JieShuanZhouQi { get; set; }
        //我的客户数量
        public int WoDeKeHuNumber { get; set; }
        //不用
        public float X { get; set; }
        //不用
        public float Y { get; set; }
        //报备规则
        public string BaoBeiGuiZhe { get; set; }
        //带看规则
        public string DaiKanGuiZhe { get; set; }
        //成交规则
        public string ChengJiaoGuiZhe { get; set; }
        //奖励
        public string JiangLi { get; set; }
        //图片
        public string ImageUrl { get; set; }
        //负责人姓名
        public string FuZheRenName { get; set; }
        //负责人电话
        public string FuZheRenDianHua { get; set; }
        //优惠信息
        public string YouHuiXinXi { get; set; }
        //图片列表
        public string ImageList { get; set; }
        //收费标准
        public string BaoJia { get; set; }
        //带看条件
        public string DaiKanTiaoJian { get; set; }
        //结算条件
        public string JieShuanTiaoJian { get; set; }
    }

    /// <summary>
    /// 返回装修公司门店
    /// Url:/App/GetZhuangXiuGuWenList
    /// 参数：UserID                请求人UserID
    ///       ZhuangXiuGongShiID    装修公司ID
    /// </summary>
    public class ReturnZhuangXiuGongShiMenDianModel
    {
        //是否成功
        public bool success { get; set; }
        //错误信息
        public string message { get; set; }
        //装修公司门店
        public List<ZhuangXiuGongShiMenDianModel> data { get; set; }
    }

    public class ZhuangXiuGongShiMenDianModel
    {
        //ID
        public int ID { get; set; }
        //名称
        public string Name { get; set; }
        //地址
        public string Address { get; set; }
        //地区编号
        public string DiQuID { get; set; }
        //地区名称
        public string DiQuName { get; set; }
        //装修顾问
        public List<ZhuangXiuGuWenModel> ZhuangXiuGuWen { get; set; }
    }
    /// <summary>
    /// 装修顾问
    /// </summary>
    public class ZhuangXiuGuWenModel
    {
        //ID
        public int ID { get; set; }
        //姓名
        public string Name { get; set; }
        //职务
        public string ZhiWu { get; set; }
        //电话
        public string DianHua { get; set; }
        //备注
        public string Remark { get; set; }
    }

    /// <summary>
    /// 返回装修订单信息
    /// 1、获得装修详情里我的客户
    ///     Url:/App/GetZhuangXiuRunningsList
    ///     参数：ZhuangXiuGongShiID 查询装修公司ID
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 2、获得我报备的新房订单
    ///     Url:/App/GetZhuangXiuRunningsList
    ///     参数：Name     搜索关键字
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    /// 
    /// </summary>
    /// 
    /// <summary>
    /// 返回客户列表
    /// 装修订单详情
    /// Url:/App/GetZhuangXiuRunningModel
    /// 参数：ID   查询订单ID
    /// 
    /// 颜色1绿   2灰   3橙色
    /// </summary>
    ///这三个接口返回的和新房的一样，用的新房的Model


    /// <summary>
    /// 返回客户列表
    /// 1、装修公司详情报备客户
    ///     Url:/App/GetKeHuShowList
    ///     参数：ChaXunZhuangXiuGongShiID 查询装修公司ID
    ///           UserID   请求人UserID
    ///           Page      页码
    ///           Rows      每页行数
    ///     看ZhuangXiuGongShiBaoBei这个属性是否报备过此装修公司


    #endregion


    #region ==================== 金融 ====================

    /// <summary>
    /// 返回项目列表
    /// Url:/App/GetJinRongList
    /// 参数：UserID
    ///       ParentID：父项ID 第一层传0
    /// </summary>
    public class JinRongList
    {
        //登录是否成功
        public bool success { get; set; }

        //错误信息
        public string message { get; set; }
        public List<JinRongItem> JinRongItemList { get; set; }

    }
    public class JinRongItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int NodeNumber { get; set; }
        public List<JinRongAttrItem> Attr { get; set; }
    }
    public class JinRongAttrItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    #endregion

}
