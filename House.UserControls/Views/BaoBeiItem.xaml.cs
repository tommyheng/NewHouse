﻿using GalaSoft.MvvmLight.Messaging;
using House.Utility;
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

namespace House.UserControls.Views
{
    /// <summary>
    /// BaoBei.xaml 的交互逻辑
    /// </summary>
    public partial class BaoBeiItem : MyUserControlBase
    {
        public BaoBeiItem()
        {
            InitializeComponent();
        }

        private void OnCheckBaoBeiDetailsClicked(object sender, RoutedEventArgs e)
        {
            //Messenger.Default.Send();
        }
    }
}
