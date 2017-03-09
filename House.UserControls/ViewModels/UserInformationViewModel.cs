using FangChan.WPFModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using House.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace House.UserControls.ViewModels
{
    public class UserInformationViewModel : ViewModelBase
    {

        #region properties

        #region private property

        private UserModel UserInfo = null;

        #endregion

        #region dataContext

        //用户头像图片文件名  Url：/Images/s   
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

        //上传头像路径
        private static string DEFAULT_FIGURE_PATH = "未选择任何图像文件";
        private string _figurePath = DEFAULT_FIGURE_PATH;
        public string FigurePath
        {
            get { return _figurePath; }
            set { Set(() => FigurePath, ref _figurePath, value); }
        }

        //旧手机号码
        public string OldTelephone { get; private set; }
        //新手机号码
        private string _telephone = string.Empty;
        public string Telephone
        {
            get { return _telephone; }
            set { Set(() => Telephone, ref _telephone, value); }
        }

        //真实姓名
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }
        //性别
        private string _sex = string.Empty;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private bool _isMan = false;
        public bool IsMan
        {
            get
            {
                if (string.IsNullOrEmpty(Sex)) return false;
                return Sex.Equals("先生") ? true : false;
            }
            set
            {
                Set(() => IsMan, ref _isMan, value);
                Sex = _isMan ? "先生" : "女士";
            }
        }

        private bool _isWoman = false;
        public bool IsWoman
        {
            get
            {
                if (string.IsNullOrEmpty(Sex)) return false;
                return Sex.Equals("女士") ? true : false;
            }
            set
            {
                Set(() => IsWoman, ref _isWoman, value);
                Sex = _isWoman ? "女士" : "先生";
            }
        }
        //工龄
        private int _workingAge = 0;
        public int WorkingAge
        {
            get { return _workingAge; }
            set { Set(() => WorkingAge, ref _workingAge, value); }
        }

        //验证码
        private string _securityCode = string.Empty;
        public string SecurityCode
        {
            get { return _securityCode; }
            set { Set(() => SecurityCode, ref _securityCode, value); }
        }
        //新密码
        private string _newPassword = string.Empty;
        public string NewPassword
        {
            get { return _newPassword; }
            set { Set(() => NewPassword, ref _newPassword, value); }
        }
        //确认密码
        private string _newPasswordAgain = string.Empty;
        public string NewPasswordAgain
        {
            get { return _newPasswordAgain; }
            set { Set(() => NewPasswordAgain, ref _newPasswordAgain, value); }
        }
        #endregion

        #region Command
        //修改手机号命令
        public ICommand ChangeTelephoneCommand { get; private set; }

        //修改个人信息命令
        public ICommand ChangeUserInfoCommand { get; private set; }

        //上传头像命令
        public ICommand UploadFigureCommand { get; private set; }

        //修改密码时获取验证码命令
        public ICommand GetSecurityCodeChangePwdCommand { get; private set;}
        //修改手机时获取验证码命令
        public ICommand GetSecurityCodeChangeTelCommand { get; private set; }

        //修改密码命令
        public ICommand ChangePasswordCommand { get; private set; }
        #endregion

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public UserInformationViewModel()
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
            //Messenger.Default.Register<int>(this, "UserInformationViewModel", LouPanItemZhiDing);
        }

        /// <summary>
        /// 初始化命令
        /// </summary>
        private void InitCommand()
        {
            ChangeTelephoneCommand = new RelayCommand(OnExecuteTelephoneChangeCmd);
            ChangeUserInfoCommand = new RelayCommand(OnExecuteUserInfoChangeCmd);
            ChangePasswordCommand = new RelayCommand(OnExecutePasswordChangeCmd);
            UploadFigureCommand = new RelayCommand(OnExecuteUploadFigureCmd);
            GetSecurityCodeChangePwdCommand = new RelayCommand(OnExecuteGetSecurityCodeChangePwdCmd);
            GetSecurityCodeChangeTelCommand = new RelayCommand(OnExecuteGetSecurityCodeChangeTelCmd);
        }

        /// <summary>
        /// 修改手机时获取验证码
        /// </summary>
        private void OnExecuteGetSecurityCodeChangeTelCmd()
        {
            if (string.IsNullOrWhiteSpace(OldTelephone) || string.IsNullOrWhiteSpace(Telephone))
            {
                MessageBox.Show("新手机号码不能为空！");
                return;
            }
            var rst = DataRepository.Instance.GetReLoginNameSMSCode(OldTelephone, Telephone);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("获取验证码成功！请查看手机！");
            }
        }

        /// <summary>
        /// 修改密码时获取验证码
        /// </summary>
        private void OnExecuteGetSecurityCodeChangePwdCmd()
        {
            var rst = DataRepository.Instance.GetRePassSMSCode(UserInfo.DianHua);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("获取验证码成功！请查看手机！");
            }
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        private void OnExecuteUploadFigureCmd()
        {
            if (FigurePath.Equals(DEFAULT_FIGURE_PATH))
            {
                MessageBox.Show("请选择头像文件！");
                return;
            }
            var rst = DataRepository.Instance.UploadTouXiangImage(UserInfo.ID, FigurePath);
            if (rst.success)
            {
                ImageUrl = DAL.DataRepository.Instance.ApiUrl + @"Images/TouXiang/" + rst.TouXiang;
                return;
            }

            MessageBox.Show(rst.message);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        private void OnExecutePasswordChangeCmd()
        {
            if (!NewPassword.Equals(NewPasswordAgain) || string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(NewPasswordAgain))
            {
                MessageBox.Show("您输入的两次新密码不相同，请确认！");
                return;
            }

            var rst = DataRepository.Instance.RePass(UserInfo.LoginName, NewPassword, SecurityCode);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("修改密码成功！请使用新的密码重新登录！");
            }
        }

        /// <summary>
        /// 修改用户资料
        /// </summary>
        private void OnExecuteUserInfoChangeCmd()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("真实姓名不能为空！");
                return;
            }

            var rst = DataRepository.Instance.UpdateUserInfo(UserInfo.ID, Name, Sex, null, WorkingAge);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("修改资料成功！");
            }
        }

        /// <summary>
        /// 修改手机号码
        /// </summary>
        private void OnExecuteTelephoneChangeCmd()
        {
            if (string.IsNullOrWhiteSpace(SecurityCode))
            {
                MessageBox.Show("请填写验证码！");
                return;
            }
            var rst = DataRepository.Instance.ReLoginName(OldTelephone, Telephone, SecurityCode);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("修改手机号码成功！");
            }
        }
        

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            //获取用户信息
            UserInfo = GlobalDataPool.Instance.LoginData.GeRenXinXi.UserInfo;

            ImageUrl = DAL.DataRepository.Instance.ApiUrl + @"Images/TouXiang/" + UserInfo.TouXiang;
            Name = UserInfo.UserName;
            OldTelephone = UserInfo.DianHua;
            Sex = UserInfo.XingBie;
            WorkingAge = UserInfo.CongYeNianXian;

        }
    }
}
