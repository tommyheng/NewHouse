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
        private string _figurePath = "未选择任何图像文件";
        public string FigurePath
        {
            get { return _figurePath; }
            set { Set(() => FigurePath, ref _figurePath, value); }
        }

        //手机号码
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

        //获取验证码命令
        public ICommand GetSecurityCodeCommand { get; private set;}

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
            GetSecurityCodeCommand = new RelayCommand(OnExecuteGetSecurityCodeCmd);
        }

        private void OnExecuteGetSecurityCodeCmd()
        {
            var rst = DataRepository.Instance.GetRePassSMSCode(UserInfo.DianHua);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
        }

        private void OnExecuteUploadFigureCmd()
        {
            var rst = DataRepository.Instance.UploadTouXiangImage(UserInfo.ID, FigurePath);
            if (rst.success)
            {
                ImageUrl = DAL.DataRepository.Instance.ApiUrl + @"Images/TouXiang/" + rst.TouXiang;
                return;
            }

            MessageBox.Show(rst.message);
        }

        private void OnExecutePasswordChangeCmd()
        {
            throw new NotImplementedException();
        }

        private void OnExecuteUserInfoChangeCmd()
        {
            var rst = DataRepository.Instance.UpdateUserInfo(UserInfo.ID, Name, Sex, null, WorkingAge);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
        }

        private void OnExecuteTelephoneChangeCmd()
        {
            var rst = DataRepository.Instance;
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
            Telephone = UserInfo.DianHua;
            Sex = UserInfo.XingBie;
            WorkingAge = UserInfo.CongYeNianXian;

        }
    }
}
