using FangChan.WPFModel;
using House.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using House.Utility;

namespace House.UserControls
{
    /// <summary>
    /// BaoBeiXiangQingView.xaml 的交互逻辑
    /// </summary>
    public partial class BaoBeiXiangQingView
    {
        //public RunningsModel RunningsModel { get; set; }
        public NewFangRunningListItem NewFangRunningListItem { get; set; }

        private RunningsModel runningsModel;
        public BaoBeiXiangQingView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            var result = DataRepository.Instance.GetBuildingsOrder(NewFangRunningListItem.ID);
            if (!result.success)
            {
                return;
                //result.data.JinDuTiao.;
                //BaoBeiXiangQingView view = new BaoBeiXiangQingView();
                //view.NewFangRunningListItem = newFangRunningListItem;
                //view.ShowDialog();
            }

            loupanmingcheng.Text = NewFangRunningListItem.LouPanName;
            kehu.Text = NewFangRunningListItem.KeHuName + " " + NewFangRunningListItem.KeHuDianHua;
            jingjiren.Text = NewFangRunningListItem.JingJiRenName + " " + NewFangRunningListItem.JingJiRenDianHua;

            var data = result.data;
            runningsModel = data;
            jindu1Left.Text = data.JinDuText[0].LeftText;
            Jindu1Right.Text = data.JinDuText[0].RightText;

            jindu2Left.Text = data.JinDuText[1].LeftText;
            Jindu2Right.Text = data.JinDuText[1].RightText;

            jindu3Left.Text = data.JinDuText[2].LeftText;
            Jindu3Right.Text = data.JinDuText[2].RightText;

            jindu4Left.Text = data.JinDuText[3].LeftText;
            Jindu4Right.Text = data.JinDuText[3].RightText;

            jindu5Left.Text = data.JinDuText[4].LeftText;
            Jindu5Right.Text = data.JinDuText[4].RightText;

            var images = (from a in data.DaiKanQueRenImage.OrderBy(a => a.ImageIndex)
                          select new KeyValuePair<Uri, int>(new Uri(ConfigHelper.GetAppSetting("ApiUrl") + @"Images/DaiKanQueRenImage/" + a.ImageUrl, UriKind.Absolute), a.ImageIndex)).ToList();
            if (images.Count > 0)
            {
                biTian.Source = new BitmapImage(images[0].Key);
                biTian.Tag = images[0].Value;
            }
            if (images.Count > 1)
            {
                shoulouchu.Source = new BitmapImage(images[1].Key);
                shoulouchu.Tag = images[0].Value;
            }
            if (images.Count > 2)
            {
                shoulouyuan.Source = new BitmapImage(images[2].Key);
                shoulouyuan.Tag = images[0].Value;
            }
            if (images.Count > 3)
            {
                jingjirenImage.Source = new BitmapImage(images[3].Key);
                jingjirenImage.Tag = images[0].Value;
            }
            if (images.Count > 4)
            {
                qita11.Source = new BitmapImage(images[4].Key);
                qita11.Tag = images[0].Value;
            }
            if (images.Count > 5)
            {
                qita12.Source = new BitmapImage(images[5].Key);
                qita12.Tag = images[0].Value;
            }


            var images2 = (from a in data.ChengJiaoQueRenImage.OrderBy(a => a.ImageIndex)
                           select new Uri(ConfigHelper.GetAppSetting("ApiUrl") + @"Images/" + a.ImageUrl, UriKind.Absolute)).ToList();
            if (images2.Count > 0) biTian2.Source = new BitmapImage(images2[0]);
            if (images2.Count > 1) shoulouchu2.Source = new BitmapImage(images2[1]);
            if (images2.Count > 2) shoulouyuan2.Source = new BitmapImage(images2[2]);
            if (images2.Count > 3) jingjirenImage2.Source = new BitmapImage(images2[3]);
            if (images2.Count > 4) qita21.Source = new BitmapImage(images2[4]);
            if (images2.Count > 5) qita22.Source = new BitmapImage(images2[5]);



            //data.i

            //var result = DataRepository.Instance.GetBuildingsOrdersList1(Bid,
            //    GlobalDataPool.Instance.Uid, pageIndex, rows);
            //if (result.success)
            //{
            //    myPager.TotalCount = result.TotalRows;
            //    myPager.PageIndex = pageIndex;
            //    myPager.PageSize = rows;
            //    listView.ItemsSource = result.data;
            //}
        }

        private void OnMouseDown_Image(object sender, MouseButtonEventArgs e)
        {
            var iamge = sender as Image;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {

                var result = DataRepository.Instance.UploadLookHouseImage(runningsModel.ID, openFileDialog.FileName);
                if (result.success == true)
                {

                    //;
                    //;runningsModel.DaiKanQueRenImage.Add( ) result.DaiKanQueRenImage
                    //MessageBox.Show("修改密码成功", "修改密码");
                    //this.Close();


                    //iamge.Source = result.DaiKanQueRenImage

                    iamge.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    //iamge.Tag =
                }
                else
                {
#if DEBUG
                    iamge.Source = new BitmapImage(new Uri(openFileDialog.FileName));
#endif
                    MessageBox.Show("图片上传失败，请重试！" + System.Environment.NewLine + result.message, "图片上传");
                }
                //if (DataRepository.Instance.UploadLookHouseImage(runningsModel.ID,openFileDialog.FileName))
            }
        }

        private void Qita12_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnMouseRightButtonDown_Image(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuItembiTian_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void shoulouchuMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void biTianMenuItem_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}