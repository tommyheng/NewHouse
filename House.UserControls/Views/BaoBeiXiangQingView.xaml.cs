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


            Dian1Text.Text = data.JinDuTiao.Dian1Text;
            Dian2Text.Text = data.JinDuTiao.Dian2Text;
            Dian3Text.Text = data.JinDuTiao.Dian3Text;
            Dian4Text.Text = data.JinDuTiao.Dian4Text;

            Xian1Text1.Text = data.JinDuTiao.Xian1Text1;
            Xian2Text1.Text = data.JinDuTiao.Xian2Text1;
            Xian3Text1.Text = data.JinDuTiao.Xian3Text1;

            Xian1Text2.Text = data.JinDuTiao.Xian1Text2;
            Xian2Text2.Text = data.JinDuTiao.Xian2Text2;
            Xian3Text2.Text = data.JinDuTiao.Xian3Text2;

            //TODO 点的颜色
            Dian1.Source = data.JinDuTiao.Dian1Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色点.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色点.png"));
            Dian2.Source = data.JinDuTiao.Dian2Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色点.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色点.png"));
            Dian3.Source = data.JinDuTiao.Dian3Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色点.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色点.png"));
            Dian3.Source = data.JinDuTiao.Dian4Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色点.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色点.png"));

            Xian1.Source = data.JinDuTiao.Xian1Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色横线.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色横线.png"));
            Xian2.Source = data.JinDuTiao.Xian2Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色横线.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色横线.png"));
            Xian3.Source = data.JinDuTiao.Xian3Color == "1" ? new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条绿色横线.png")) : new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/进度条灰色横线.png"));


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
                           select new KeyValuePair<Uri, int>(new Uri(ConfigHelper.GetAppSetting("ApiUrl") + @"Images/DaiKanQueRenImage/" + a.ImageUrl, UriKind.Absolute), a.ImageIndex)).ToList();
            if (images2.Count > 0)
            {
                biTian2.Source = new BitmapImage(images2[0].Key);
                biTian2.Tag = images2[0].Value;
            }
            if (images2.Count > 1)
            {
                shoulouchu2.Source = new BitmapImage(images2[1].Key);
                shoulouchu2.Tag = images2[0].Value;
            }
            if (images2.Count > 2)
            {
                shoulouyuan2.Source = new BitmapImage(images2[2].Key);
                shoulouyuan2.Tag = images2[0].Value;
            }
            if (images2.Count > 3)
            {
                jingjirenImage2.Source = new BitmapImage(images2[3].Key);
                jingjirenImage2.Tag = images2[0].Value;
            }
            if (images2.Count > 4)
            {
                qita21.Source = new BitmapImage(images2[4].Key);
                qita21.Tag = images2[0].Value;
            }
            if (images2.Count > 5)
            {
                qita22.Source = new BitmapImage(images2[5].Key);
                qita22.Tag = images2[0].Value;
            }


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
                //var result = DataRepository.Instance.UploadDealHouseImage(runningsModel.ID, openFileDialog.FileName);

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

        private void OnMouseDown_Image2(object sender, MouseButtonEventArgs e)
        {
            var iamge = sender as Image;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {

                //var result = DataRepository.Instance.UploadLookHouseImage(runningsModel.ID, openFileDialog.FileName);
                var result = DataRepository.Instance.UploadDealHouseImage(runningsModel.ID, openFileDialog.FileName);

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

        #region 图片删除

        private void biTianMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = biTian.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/带看单.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void shoulouchuMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = shoulouchu.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/售楼处.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }


        private void shoulouyuanMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = shoulouyuan.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/客户与售楼员.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void jingjirenMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = jingjirenImage.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/客户与经纪人.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void qita11MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = qita11.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/其他.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void qita12MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = qita12.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/其他.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }


        private void biTian2MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = biTian2.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/带看单.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void shoulouchu2MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = shoulouchu2.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/售楼处.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }


        private void shoulouyuan2MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = shoulouyuan2.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/客户与售楼员.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void jingjirenImage2MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = jingjirenImage2.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/客户与经纪人.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void qita21MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = qita11.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/其他.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        private void qita22MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var id = qita12.Tag.GetInt();
            var result = DataRepository.Instance.DeleteImage(id);
            if (result.success == true)
            {
                biTian.Source = new BitmapImage(new Uri("pack://application:,,,/House.Thems;component/Images/其他.png"));
            }
            else
            {
                MessageBox.Show("删除失败", "删除");
            }
        }

        #endregion 


    }
}