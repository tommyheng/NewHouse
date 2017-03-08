using House.DAL;
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

namespace House.Login.Views
{
    /// <summary>
    /// ModifyPasswordView.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPasswordView
    {
        public ModifyPasswordView()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //var dr = DataRepository.Instance;

        //    //var name = LoginName.Text.Trim();
        //    //var pwd = LoginPwd.Password.Trim();
        //    //if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd))
        //    //{
        //    //    MessageBox.Show("账号或密码不能为空！", "温馨提示");
        //    //    return;
        //    //}
        //    //var result = dr.Login(name, pwd);
        //    //if (result.success)
        //    //{
        //    //    GlobalDataPool.Instance.Uid = result.GeRenXinXi.UserInfo.ID;
        //    //    GlobalDataPool.Instance.LoginName = name;
        //    //    GlobalDataPool.Instance.UserName = result.GeRenXinXi.UserInfo.UserName;
        //    //    GlobalDataPool.Instance.Position = result.GeRenXinXi.UserInfo.ZhiWu;
        //    //    GlobalDataPool.Instance.LoginData = result;
        //    //    ////测试楼盘数据列表
        //    //    //var requestBuildingslist = dr.GetBuildingsList(GlobalDataPool.Instance.Uid, 1, 10, 0, "");
        //    //    //if (requestBuildingslist.success)
        //    //    //{
        //    //    //    //获得第一个楼盘信息和ID
        //    //    //    var buildings = requestBuildingslist.data.First();
        //    //    //    var bId = buildings.ID;

        //    //    //    //测试楼盘信息功能
        //    //    //    var requestBuildingsInfo = dr.GetBuildingsInfo(GlobalDataPool.Instance.Uid, bId);
        //    //    //    if (requestBuildingsInfo.success)
        //    //    //    {
        //    //    //        //获取楼盘信息
        //    //    //        var buildingsInfo = requestBuildingsInfo.data;
        //    //    //    }

        //    //    //    //测试置业顾问接口
        //    //    //    var requestPropertyConsultantList = dr.GetPropertyConsultantList(bId);
        //    //    //    if (requestPropertyConsultantList.success)
        //    //    //    {
        //    //    //        var propertyConsultantList = requestPropertyConsultantList.data;
        //    //    //    }

        //    //    //    //返回新房订单信息
        //    //    //    //1、获得楼盘详情里我的客户
        //    //    //    var requestBuildingsOrdersList1 = dr.GetBuildingsOrdersList1(bId, GlobalDataPool.Instance.Uid, 1, 10);
        //    //    //    if (requestBuildingsOrdersList1.success)
        //    //    //    {
        //    //    //        var buildingsOrdersList1 = requestBuildingsOrdersList1.data;
        //    //    //    }

        //    //    //    //返回新房订单信息
        //    //    //    //2、获得我报备的新房订单
        //    //    //    var requestBuildingsOrdersList2 = dr.GetBuildingsOrdersList2("", GlobalDataPool.Instance.Uid, 1, 10);
        //    //    //    if (requestBuildingsOrdersList2.success)
        //    //    //    {
        //    //    //        var buildingsOrdersList2 = requestBuildingsOrdersList2.data;

        //    //    //        var orderID = buildingsOrdersList2.First().ID;

        //    //    //        //测试订单详情
        //    //    //        var requestBuildingsOrders = dr.GetBuildingsOrder(orderID);
        //    //    //        if (requestBuildingsOrders.success)
        //    //    //        {
        //    //    //            var buildingsOrders = requestBuildingsOrders.data;
        //    //    //        }

        //    //    //    }

        //    //    //    //返回客户列表
        //    //    //    //1、楼盘详情报备客户
        //    //    //    var requestBuildingsCustomerList1 = dr.GetBuildingsCustomerList1(bId, GlobalDataPool.Instance.Uid, 1, 10);
        //    //    //    if (requestBuildingsCustomerList1.success)
        //    //    //    {
        //    //    //        var buildingsCustomerList1 = requestBuildingsCustomerList1.KeHuList;
        //    //    //    }

        //    //    //    //返回客户列表
        //    //    //    //2、所有客户
        //    //    //    var requestBuildingsCustomerList2 = dr.GetBuildingsCustomerList2("", GlobalDataPool.Instance.Uid, 1, 10);
        //    //    //    if (requestBuildingsCustomerList2.success)
        //    //    //    {
        //    //    //        var buildingsCustomerList2 = requestBuildingsCustomerList2.KeHuList;
        //    //    //    }
        //    //    //}



        //    //    this.DialogResult = true;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("登陆失败，请检查账号和密码！", "温馨提示");
        //    //}
        //    ////
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //this.DialogResult = false;
        //}

        //private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.DragMove();
        //}

        //private void closeBtne_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //    this.Close();
        //}

        //private void minBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        //private void LoginView_OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    //this.LoginName.Focus();
        //    //LoginName.SelectionStart = LoginName.Text.Length;
        //}

        private string smsCodeReceive;

        private void ButtonSMS_Click(object sender, RoutedEventArgs e)
        {
            var rst = DataRepository.Instance.GetRePassSMSCode(this.phoneNo.Text);
            if (!rst.success)
            {
                smsCodeReceive = rst.message;
            }
            else
            {
                MessageBox.Show(rst.message, "修改密码");
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (smsCode.Text.Trim() != smsCodeReceive)
            {
                MessageBox.Show("验证码错误", "修改密码");
            }

            if (newPwd.Password.Trim() != reNewPwd.Password.Trim())
            {
                MessageBox.Show("新密码输入不一致，请重新输入", "修改密码");
            }

            var result = DataRepository.Instance.RePass(this.phoneNo.Text, newPwd.Password.Trim(), smsCodeReceive);
            if (result.success == true)
            {
                MessageBox.Show("修改密码成功", "修改密码");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码修改错误，请重试！", "修改密码");
                this.Close();

            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModifyPasswordView_OnLoaded(object sender, RoutedEventArgs e)
        {
            ////获取用户信息
            //var userInfo = GlobalDataPool.Instance.LoginData.GeRenXinXi.UserInfo;
            //if (userInfo != null)
            //{
            //    this.phoneNo.Text = userInfo.DianHua.Trim();

            //}
            //else
            //{
            //    this.IsEnabled = false;
            //}


        }
    }
}
