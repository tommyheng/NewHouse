using GalaSoft.MvvmLight.Messaging;
using House.Models;
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

namespace House.UserInfo.Views
{
    /// <summary>
    /// 管理中心和新房的矮的用户信息，点击之后转到管理中心
    /// UserInfoView2.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoView2
    {
        public UserInfoView2()
        {
            InitializeComponent();
        }

        #region 用户图像

        /// <summary>
        /// 用户图像
        /// </summary>
        public ImageSource UserImage
        {
            get { return (ImageSource)GetValue(UserImageProperty); }
            set { SetValue(UserImageProperty, value); }
        }

        public static readonly DependencyProperty UserImageProperty =
            DependencyProperty.Register("UserImage", typeof(ImageSource), typeof(UserInfoView2),
                new FrameworkPropertyMetadata(default(ImageSource), FrameworkPropertyMetadataOptions.None,
                    OnUserImagePropertyChanged));

        private static void OnUserImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView2)d;
            var date = (ImageSource)e.NewValue;
            if (Equals(date, e.OldValue)) return;
            u.setUserName(date);
        }

        private void setUserName(ImageSource userImage)
        {
            this.userImage.ImageSource = userImage;
        }

        #endregion

        #region 用户名

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(UserInfoView2),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.None,
                    OnTitlePropertyChanged));

        private static void OnTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView2)d;
            var date = (string)e.NewValue;
            if (Equals(date, e.OldValue)) return;
            u.setUserName(date);
        }

        private void setUserName(string userName)
        {
            this.userName.Text = userName;
        }

        #endregion

        #region 用户头衔

        /// <summary>
        /// 用户头衔
        /// </summary>
        public string UserTitle
        {
            get { return (string)GetValue(UserTitleProperty); }
            set { SetValue(UserTitleProperty, value); }
        }

        public static readonly DependencyProperty UserTitleProperty =
            DependencyProperty.Register("UserTitle", typeof(string), typeof(UserInfoView2),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.None,
                    OnUserTitlePropertyChanged));

        private static void OnUserTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView2)d;
            var date = (string)e.NewValue;
            if (Equals(date, e.OldValue)) return;
            u.setUserTitle(date);
        }

        private void setUserTitle(string userTitle)
        {
            this.userTitle.Text = string.IsNullOrWhiteSpace(userTitle) ? "" :  userTitle;
        }

        #endregion

        private void MyUserControlBase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewInfo viewInfo = new ViewInfo(ViewName.NewHouse, ViewType.SingleWindow);

            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.NewHouseInternalNavigate);
        }
    }
}
