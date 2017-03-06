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
using GalaSoft.MvvmLight.Messaging;
using House.Models;

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
            btnCurrentArea.Content = GlobalDataPool.Instance.LoginData.DiQu.Name;
        }

        #region  Title

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
            ("TitleProperty", typeof(string), typeof(BigHeaderView), new PropertyMetadata("新房", OnTitlePropertyChangedCallback));

        private static void OnTitlePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var h = (BigHeaderView)d;
            if (e.NewValue != e.OldValue)
            {
                h.setTitleText(e.NewValue as string);
            }
        }

        private void setTitleText(string title)
        {
            //this.tickerTape.Text = text;
            this.title.Text = title;
        }

        #endregion

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Messenger.Default.Send<string>(null, MessengerToken.ShutdownApp);

            //Messenger.Default.Send<string>(null, Models.MessengerToken.SwitchMainMenuToSmall);
            ViewInfo viewInfo2 = new ViewInfo(ViewName.LouPanLieBiao, ViewType.View);
            Messenger.Default.Send<ViewInfo>(viewInfo2, MessengerToken.NewHouseInternalNavigate);

        }

        private void changeAreaButton_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO 点击之后弹出地区选择对话框，改变地区之后从新设置显示地区
            btnCurrentArea.Content = GlobalDataPool.Instance.LoginData.DiQu.Name;
        }
    }
}
