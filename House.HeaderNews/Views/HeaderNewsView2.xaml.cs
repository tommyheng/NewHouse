using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace House.HeaderNews.Views
{
    /// <summary>
    /// HeaderNewsView2.xaml 的交互逻辑
    /// </summary>
    public partial class HeaderNewsView2
    {
        public HeaderNewsView2()
        {
            InitializeComponent();
            //var t = new DispatcherTimer(TimeSpan.FromSeconds(2), DispatcherPriority.Normal, Tick, this.Dispatcher);
        }

        Storyboard storyboard = new Storyboard();
        void Tick(object sender, EventArgs e)
        {
            //var dateTime = DateTime.Now;
            //transitioning.Content = new TextBlock { Text = "跑马灯啊跑马灯等等!现在时间 " + dateTime, SnapsToDevicePixels = true };
        }

        private void MyUserControlBase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://www.fang101.com/Show/Index");
            try
            {
                System.Diagnostics.Process.Start(Hyperlink);

            }
            catch
            { }

        }

        #region  ScrollingText

        public string ScrollingText
        {
            get { return (string)GetValue(ScrollingTextProperty); }
            set { SetValue(ScrollingTextProperty, value); }
        }
        public static readonly DependencyProperty ScrollingTextProperty = DependencyProperty.Register
            ("ScrollingText", typeof(string), typeof(HeaderNewsView2), new PropertyMetadata("超链接跑马灯", OnScrollingTextPropertyChangedCallback));

        private static void OnScrollingTextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var h = (HeaderNewsView2)d;
            if (e.NewValue != e.OldValue)
            {
                h.setScrollingText(e.NewValue as string);
            }
        }

        private void setScrollingText(string text)
        {
            //this.tickerTape.Text = text;
            this.scrollingTextControl.Content = text;
        }

        #endregion


        #region  Hyperlink

        public string Hyperlink
        {
            get { return (string)GetValue(HyperlinkProperty); }
            set { SetValue(HyperlinkProperty, value); }
        }
        public static readonly DependencyProperty HyperlinkProperty = DependencyProperty.Register
            ("Hyperlink", typeof(string), typeof(HeaderNewsView2), new PropertyMetadata("超链接跑马灯", OnHyperlinkPropertyChangedCallback));

        private static void OnHyperlinkPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            //var h = (HeaderNewsView)d;
            //if (e.NewValue != e.OldValue)
            //{
            //    h.setHyperlink(e.NewValue as string);
            //}
        }

        //private void setHyperlink(string text)
        //{
        //    this.scrollingTextControle.Content = text;
        //}

        #endregion



        //#region 跑马灯

        //private void tickerTape_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    storyboard.Pause();
        //}

        //private void tickerTape_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    storyboard.Resume();
        //}

        //private void tickerTape_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //string text = "石头网全新改版：9月14日《龙头回来了》 用户专题教学：每周二、周四下午15：30-16：30";
        //    //tickerTape.Text = text;

        //    //Hyperlink hlink = new Hyperlink(new Run(tickerTape.Text));
        //    //hlink.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(248, 188, 76));
        //    //hlink.NavigateUri = new Uri(Hyperlink);
        //    //hlink.RequestNavigate += Hyperlink_RequestNavigate;

        //    //tickerTape.Inlines.Clear();
        //    //tickerTape.Inlines.Add(hlink);

        //    CreateAnimation(tickerTape);
        //}

        //private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        //{
        //    Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
        //    e.Handled = true;
        //}

        ////获取文字长度
        //private double MeasureTextWidth(string text, double fontSize, string fontFamily)
        //{
        //    FormattedText formattedText = new FormattedText(
        //        text,
        //        System.Globalization.CultureInfo.InvariantCulture,
        //        FlowDirection.LeftToRight,
        //        new Typeface(fontFamily.ToString()),
        //        fontSize,
        //      System.Windows.Media.Brushes.Black
        //    );
        //    return formattedText.WidthIncludingTrailingWhitespace;
        //}

        //private void CreateAnimation(TextBlock text)
        //{

        //    double length = MeasureTextWidth(text.Text, text.FontSize, text.FontFamily.Source);

        //    //移动动画
        //    {
        //        DoubleAnimationUsingKeyFrames WidthMove = new DoubleAnimationUsingKeyFrames();
        //        Storyboard.SetTarget(WidthMove, text);
        //        DependencyProperty[] propertyChain = new DependencyProperty[]
        //        {
        //            TextBlock.RenderTransformProperty,
        //            TransformGroup.ChildrenProperty,
        //            TranslateTransform.XProperty,
        //        };
        //        Storyboard.SetTargetProperty(WidthMove, new PropertyPath("(0).(1)[3].(2)", propertyChain));
        //        WidthMove.KeyFrames.Add(new EasingDoubleKeyFrame(this.ActualWidth,
        //            KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0))));
        //        WidthMove.KeyFrames.Add(new EasingDoubleKeyFrame(-length,
        //            KeyTime.FromTimeSpan(new TimeSpan(0, 0, (int)(length / 20)))));
        //        storyboard.Children.Add(WidthMove);
        //    }

        //    storyboard.RepeatBehavior = RepeatBehavior.Forever;
        //    storyboard.Begin();
        //}

        //#endregion

    }




}
