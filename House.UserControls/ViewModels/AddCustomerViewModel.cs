using FangChan.WPFModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using House.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace House.UserControls.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        #region dataContext
        //客户名称
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                Set(() => Name, ref _name, value);
            }
        }

        //性别
        private bool _isMan = false;
        public bool IsMan
        {
            get { return _isMan; }
            set
            {
                Set(() => IsMan, ref _isMan, value);
                if (_isMan) _sex = "先生";
            }
        }

        private bool _isWoman = false;
        public bool IsWoman
        {
            get { return _isWoman; }
            set
            {
                Set(() => IsWoman, ref _isWoman, value);
                if (_isWoman) _sex = "女士";
            }
        }

        //手机号码
        private string _telephone = string.Empty;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                Set(() => Telephone, ref _telephone, value);
            }
        }

        private string _secondTelephone = string.Empty;
        public string SecondTelephone
        {
            get { return _secondTelephone; }
            set
            {
                Set(() => SecondTelephone, ref _secondTelephone, value);
            }
        }

        private string _thirdTelephone = string.Empty;
        public string ThirdTelephone
        {
            get { return _thirdTelephone; }
            set
            {
                Set(() => ThirdTelephone, ref _thirdTelephone, value);
            }
        }

        private bool _secondTelephoneVisibility = false;
        public bool SecondTelephoneVisibility
        {
            get { return _secondTelephoneVisibility; }
            set
            {
                Set(() => SecondTelephoneVisibility, ref _secondTelephoneVisibility, value);
            }
        }

        private bool _thirdTelephoneVisibility = false;
        public bool ThirdTelephoneVisibility
        {
            get { return _thirdTelephoneVisibility; }
            set
            {
                Set(() => ThirdTelephoneVisibility, ref _thirdTelephoneVisibility, value);
            }
        }
        #endregion

        #region private property

        //性别
        private string _sex = "先生";

        //手机号码
        private List<string> _telephoneList = new List<string>();

        #endregion
        

        #region command

        //上传客户信息
        public ICommand UpLoadCustomerInfoCmd { get; private set; }

        //添加电话号码
        public ICommand AddTelephoneCmd { get; private set; }
        //删除电话号码
        public ICommand DelTelephoneCmd { get; private set; }
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public AddCustomerViewModel()
        {
            InitCommand();
        }

        private void InitCommand()
        {
            UpLoadCustomerInfoCmd = new RelayCommand(OnExecuteUpLoadCustomerInfoCmd);
            AddTelephoneCmd = new RelayCommand(OnExecuteAddTelephoneCmd);
            DelTelephoneCmd = new RelayCommand<string>(OnExecuteDelTelephoneCmd);
        }

        private void OnExecuteDelTelephoneCmd(string telephone)
        {
            if (telephone.Equals(SecondTelephone))
            {
                SecondTelephoneVisibility = false;
                SecondTelephone = string.Empty;
            }

            if (telephone.Equals(ThirdTelephone))
            {
                ThirdTelephoneVisibility = false;
                ThirdTelephone = string.Empty;
            }
        }

        private void OnExecuteAddTelephoneCmd()
        {
            if (string.IsNullOrWhiteSpace(Telephone) || string.IsNullOrEmpty(Telephone)) return;

            if (!SecondTelephoneVisibility)
            {
                SecondTelephoneVisibility = true;
                SecondTelephone = Telephone;
                Telephone = string.Empty;
            }
            else if (!ThirdTelephoneVisibility)
            {
                ThirdTelephoneVisibility = true;
                ThirdTelephone = Telephone;
                Telephone = string.Empty;
            }
            else
            {
                MessageBox.Show("最多只能添加三个手机号码！");
            }

        }

        private void OnExecuteUpLoadCustomerInfoCmd()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("请填写客户姓名！");
                return;
            }
            if (string.IsNullOrEmpty(Telephone) || string.IsNullOrWhiteSpace(Telephone))
            {
                MessageBox.Show("必须添加一个电话号码！");
                return;
            }

            _telephoneList.Add(Telephone);
            if (!string.IsNullOrEmpty(SecondTelephone) && !_telephoneList.Contains(SecondTelephone)) _telephoneList.Add(SecondTelephone);
            if (!string.IsNullOrEmpty(ThirdTelephone) && !_telephoneList.Contains(ThirdTelephone)) _telephoneList.Add(ThirdTelephone);

            var customerInfo = new AddKeHuModel();
            customerInfo.ID = 0;
            customerInfo.UserName = Name;
            customerInfo.XingBie = _sex;
            customerInfo.KeHuDianHua = (from t in _telephoneList
                                        select new DianHuaModel
                                        {
                                            ID = 0,
                                            DianHua = t
                                        }).ToList();

            var rst = DataRepository.Instance.AddOrModifyCustomer(GlobalDataPool.Instance.Uid, customerInfo);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                MessageBox.Show("添加客户成功！");
            }
        }
    }
}
