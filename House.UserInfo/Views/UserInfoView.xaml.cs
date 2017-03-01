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
    /// UserInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfoView
    {
        public UserInfoView()
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
            DependencyProperty.Register("UserImage", typeof(ImageSource), typeof(UserInfoView),
                new FrameworkPropertyMetadata(default(ImageSource), FrameworkPropertyMetadataOptions.None,
                    OnUserImagePropertyChanged));

        private static void OnUserImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView)d;
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
            DependencyProperty.Register("UserName", typeof(string), typeof(UserInfoView),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.None,
                    OnTitlePropertyChanged));

        private static void OnTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView)d;
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
            DependencyProperty.Register("UserTitle", typeof(string), typeof(UserInfoView),
                new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.None,
                    OnUserTitlePropertyChanged));

        private static void OnUserTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var u = (UserInfoView)d;
            var date = (string)e.NewValue;
            if (Equals(date, e.OldValue)) return;
            u.setUserTitle(date);
        }

        private void setUserTitle(string userTitle)
        {
            this.userTitle.Text = userTitle;
        }

        #endregion

        private void MyUserControlBase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //点击小窗体用户头像时，显示管理中心，先转到新房界面，然后在内部跳转到管理中心
            ViewInfo viewInfo = new ViewInfo(ViewName.NewHouse, ViewType.SingleWindow);
            Messenger.Default.Send<ViewInfo>(viewInfo, MessengerToken.MainMenuNavigate);

            ViewInfo viewInfo2 = new ViewInfo(ViewName.ManagementCenter, ViewType.View);
            Messenger.Default.Send<ViewInfo>(viewInfo2, MessengerToken.NewHouseInternalNavigate);

        }
    }
}
