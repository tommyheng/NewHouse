﻿using System;
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

namespace House.Footer.Views
{
    /// <summary>
    /// FooterView.xaml 的交互逻辑
    /// </summary>
    public partial class FooterView
    {
        public FooterView()
        {
            InitializeComponent();
        }

        private void MyUserControlBase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fang101.com/Show/Index");
        }
    }
}