using System;
using System.Collections.Generic;
using System.Globalization;
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
using House.Utility;
using GalaSoft.MvvmLight.Messaging;

namespace House.UserControls.Views
{
    /// <summary>
    /// LouPanItem.xaml 的交互逻辑
    /// </summary>
    public partial class LouPanItem : MyUserControlBase
    {
        public LouPanItem()
        {
            InitializeComponent();
        }

        private void OnZhiDingClicked(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send((sender as Button).Tag.CastTo<int>(), "LouPanItemZhiDing");
        }
    }

    [ValueConversion(typeof(bool), typeof(string))]
    public class BonusConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsHaveBonus = false;
            string HaveBonus = "有";
            string NoBonus = "无";

            if (value == null) return NoBonus;
            if (!bool.TryParse(value.ToString(), out IsHaveBonus)) return NoBonus;

            return IsHaveBonus ? HaveBonus : NoBonus;

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(string), typeof(ImageBrush))]
    public class ZhiDingConverter : IValueConverter
    {
        private static readonly BitmapImage _ZhiDing = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/置顶.png"));
        private static readonly BitmapImage _ZhiDingQuXiao = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/取消.png"));
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var zhiding = int.Parse(value.ToString());
            var bitmap = zhiding > 0 ? _ZhiDingQuXiao : _ZhiDing;

            var imageBrush = new ImageBrush(bitmap);
            imageBrush.Stretch = Stretch.Uniform;
            return imageBrush;

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
