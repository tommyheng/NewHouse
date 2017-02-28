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

namespace House.UserControls
{
    /// <summary>
    /// PropertyConsultantsView.xaml 的交互逻辑
    /// </summary>
    public partial class RecordCustomerView
    {
        public int Bid { get; set; }
        public string BName { get; set; }
        public int Total { get; set; }
        public int IndexPage { get; set; }

        private int rows = 20;

        public RecordCustomerView()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IndexPage = 1;
            BuildingsName.Text = BName;

            var result = DataRepository.Instance.GetBuildingsCustomerList1(Bid,
                GlobalDataPool.Instance.Uid, IndexPage, rows);
            if (result.success)
            {
                Total = result.TotalRows;
                List<KeHuShowListItemInfo> Infos = new List<KeHuShowListItemInfo>();
                for (int i = 0; i < result.KeHuList.Count; i++)
                {
                    Infos.Add(new KeHuShowListItemInfo
                    {
                        //客户ID
                        ID = result.KeHuList[i].ID,
                        //客户姓名
                        UserName = result.KeHuList[i].UserName,
                        //客户性别(先生/女士)
                        XingBie = result.KeHuList[i].XingBie,
                        //已弃用
                        DianHua = result.KeHuList[i].DianHua,
                        //已弃用
                        YiXiang = result.KeHuList[i].YiXiang,
                        //订单状态说明
                        MaiFangRunning = result.KeHuList[i].MaiFangRunning,
                        //是否显示经点
                        HongDian = result.KeHuList[i].HongDian,
                        //电话列表
                        DianHuaList = result.KeHuList[i].DianHuaList,
                        //新房是否已报备(报备新房用这个，)
                        LouPanBaoBei = result.KeHuList[i].LouPanBaoBei,
                        //抵帐房是否已报备
                        DiZhangFangBaoBei = result.KeHuList[i].DiZhangFangBaoBei,
                        //装修是否已报备
                        ZhuangXiuGongShiBaoBei = result.KeHuList[i].ZhuangXiuGongShiBaoBei,
                        //家政是否已报备
                        JiaZhengGongShiBaoBei = result.KeHuList[i].JiaZhengGongShiBaoBei,
                        //金融是否已报备
                        JinRongTypeBaoBei = result.KeHuList[i].JinRongTypeBaoBei,
                        StateInfo = result.KeHuList[i].LouPanBaoBei == true ? "已报备" : "未报备"
                    });
                }
                listView.ItemsSource = Infos;

            }
        }

        private void SubmitBtnClick(object sender, RoutedEventArgs e)
        {
            listView.SelectedIndex = -1;
            var items = GetChildObjects<RadioButton>(this, typeof(RadioButton));
            var rdo = items.FirstOrDefault(m => m.IsChecked == true);
            if (rdo != null)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(rdo);
                while (parent != null)
                {
                    parent = VisualTreeHelper.GetParent(parent);
                    if (parent == null) break;
                    if (parent.GetType() == typeof(ListViewItem))
                    {
                        var item = parent as ListViewItem;
                        item.IsSelected = true;
                        var data = listView.SelectedItem;
                        var cb = GetChildObjects<ComboBox>(parent, typeof(ComboBox)).FirstOrDefault();
                        if (cb != null)
                        {
                            var phoneEntity = cb.SelectedItem as DianHuaModel;
                        }
                        break;
                    }
                    //Debug.WriteLine(parent.GetType().ToString());
                }
            }

        }

        public List<T> GetChildObjects<T>(DependencyObject obj, Type typename) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).GetType() == typename))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, typename));
            }
            return childList;
        }
    }
}
