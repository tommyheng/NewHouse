﻿using House.DAL;
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

namespace House.BigHeader.Views
{
    /// <summary>
    /// BigHeaderView.xaml 的交互逻辑
    /// </summary>
    public partial class BigHeaderView
    {
        public BigHeaderView()
        {
            InitializeComponent();
            userInfoView2.UserName = GlobalDataPool.Instance.UserName;
            userInfoView2.UserTitle = string.Format("( {0})", GlobalDataPool.Instance.Position);

        }



    }
}
