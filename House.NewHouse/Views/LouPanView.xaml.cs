using House.NewHouse.ViewModels;
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
using GalaSoft.MvvmLight;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;

namespace House.NewHouse.Views
{
    /// <summary>
    /// LouPanView.xaml 的交互逻辑
    /// </summary>
    public partial class LouPanView : MyUserControlBase
    {
        private LouPanViewModel dataContext = new LouPanViewModel();
        public LouPanView()
        {
            InitializeComponent();
            this.DataContext = dataContext;
        }

    }
}
