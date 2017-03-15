using FangChan.WPFModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using House.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string _originTelephone = string.Empty;
        private string _telephone = string.Empty;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                Set(() => Telephone, ref _telephone, value);
            }
        }

        private string _originSecondTelephone = string.Empty;
        private string _secondTelephone = string.Empty;
        public string SecondTelephone
        {
            get { return _secondTelephone; }
            set
            {
                Set(() => SecondTelephone, ref _secondTelephone, value);
                SecondTelephoneVisibility = true;
            }
        }

        private string _originThirdTelephone = string.Empty;
        private string _thirdTelephone = string.Empty;
        public string ThirdTelephone
        {
            get { return _thirdTelephone; }
            set
            {
                Set(() => ThirdTelephone, ref _thirdTelephone, value);
                ThirdTelephoneVisibility = true;
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

        //修改客户信息
        public ICommand EditCustomerInfoCmd { get; private set; }

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

        private KeHuShowListItem _customerInfo = null;
        public void InitData(KeHuShowListItem customerInfo)
        {
            _customerInfo = customerInfo;

            Name = customerInfo.UserName;
            if (customerInfo.XingBie.Equals("先生"))
            {
                IsMan = true;
                IsWoman = false;
            }
            else
            {
                IsWoman = true;
                IsMan = false;
            }

            var count = customerInfo.DianHuaList.Count;
            if (count == 1)
            {
                Telephone = customerInfo.DianHuaList[0].DianHua;
                _originTelephone = Telephone;
            }
            else if (count == 2)
            {
                Telephone = customerInfo.DianHuaList[0].DianHua;
                SecondTelephone = customerInfo.DianHuaList[1].DianHua;
                _originTelephone = Telephone;
                _originSecondTelephone = SecondTelephone;
            }
            else if (count == 3)
            {
                Telephone = customerInfo.DianHuaList[0].DianHua;
                SecondTelephone = customerInfo.DianHuaList[1].DianHua;
                ThirdTelephone = customerInfo.DianHuaList[2].DianHua;
                _originTelephone = Telephone;
                _originSecondTelephone = SecondTelephone;
                _originThirdTelephone = ThirdTelephone;
            }

        }
        private void InitCommand()
        {
            UpLoadCustomerInfoCmd = new RelayCommand(OnExecuteUpLoadCustomerInfoCmd);
            EditCustomerInfoCmd = new RelayCommand(OnExecuteEditCustomerInfoCmd);
            AddTelephoneCmd = new RelayCommand(OnExecuteAddTelephoneCmd);
            DelTelephoneCmd = new RelayCommand<string>(OnExecuteDelTelephoneCmd);
        }


        private void OnExecuteDelTelephoneCmd(string telephone)
        {
            if (telephone.Equals(SecondTelephone))
            {
                SecondTelephone = string.Empty;
                SecondTelephoneVisibility = false;
            }

            if (telephone.Equals(ThirdTelephone))
            {
                ThirdTelephone = string.Empty;
                ThirdTelephoneVisibility = false; 
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

        private void OnExecuteEditCustomerInfoCmd()
        {
            AddOfModifyCustomerInfo(false);

        }

        private void OnExecuteUpLoadCustomerInfoCmd()
        {
            AddOfModifyCustomerInfo(true);
        }

        private void AddOfModifyCustomerInfo(bool isAdd)
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

            var customerInfo = new AddKeHuModel();
            customerInfo.ID = isAdd ? 0 : _customerInfo.ID;
            customerInfo.UserName = Name;
            customerInfo.XingBie = _sex;
            if (isAdd)
            {
                //添加客户信息
                _telephoneList.Clear();
                _telephoneList.Add(Telephone);
                if (!string.IsNullOrEmpty(SecondTelephone) && !_telephoneList.Contains(SecondTelephone)) _telephoneList.Add(SecondTelephone);
                if (!string.IsNullOrEmpty(ThirdTelephone) && !_telephoneList.Contains(ThirdTelephone)) _telephoneList.Add(ThirdTelephone);

                customerInfo.KeHuDianHua = (from t in _telephoneList
                                            select new DianHuaModel
                                            {
                                                ID = 0,
                                                DianHua = t
                                            }).ToList();
            }
            else
            {
                //修改客户信息
                customerInfo.KeHuDianHua = new List<DianHuaModel>();

                if (_originTelephone != string.Empty && _originTelephone != Telephone)
                {
                    var tmp = _customerInfo.DianHuaList[0];
                    customerInfo.KeHuDianHua.Add(new DianHuaModel() { ID = tmp.ID, DianHua = Telephone, IsMoRen = tmp.IsMoRen, Remark = tmp.Remark });
                }
                if (_originSecondTelephone != string.Empty && _originSecondTelephone != SecondTelephone)
                {
                    var tmp = _customerInfo.DianHuaList[1];
                    customerInfo.KeHuDianHua.Add(new DianHuaModel() { ID = tmp.ID, DianHua = SecondTelephone, IsMoRen = tmp.IsMoRen, Remark = tmp.Remark });
                }
                if (_originThirdTelephone != string.Empty && _originThirdTelephone != ThirdTelephone)
                {
                    var tmp = _customerInfo.DianHuaList[2];
                    customerInfo.KeHuDianHua.Add(new DianHuaModel() { ID = tmp.ID, DianHua = ThirdTelephone, IsMoRen = tmp.IsMoRen, Remark = tmp.Remark });
                }

                if (_originSecondTelephone == string.Empty && SecondTelephone != string.Empty)
                {
                    customerInfo.KeHuDianHua.Add(new DianHuaModel() { ID = 0, DianHua = SecondTelephone });
                }

                if (_originThirdTelephone == string.Empty && ThirdTelephone != string.Empty)
                {
                    customerInfo.KeHuDianHua.Add(new DianHuaModel() { ID = 0, DianHua = ThirdTelephone });
                }
            }
            
            //发送请求
            var rst = DataRepository.Instance.AddOrModifyCustomer(GlobalDataPool.Instance.Uid, customerInfo);
            if (!rst.success)
            {
                MessageBox.Show(rst.message);
            }
            else
            {
                var str = isAdd ? "添加" : "修改";
                MessageBox.Show(string.Format("{0}客户成功！", str));
                
            }
            
        }
    }
}
