using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace House.Shell
{
    public partial class App : Application
    {
        public App()
        {
            registerService();
            InitResource();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            unregisterService();
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        private void registerService()
        {
            ServiceLocator.SetLocatorProvider(() => GalaSoft.MvvmLight.Ioc.SimpleIoc.Default);
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<House.MainModule.ViewModelLocator>();
        }

        /// <summary>
        /// 取消注册服务
        /// </summary>
        private void unregisterService()
        {
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Unregister<House.MainModule.ViewModelLocator>();
        }

        /// <summary>
        /// 加载资源并初始化
        /// </summary>
        private void InitResource()
        {
            try
            {
                //加载对应环境的资源
                var thems = LoadComponent(new Uri(@"/House.Thems;component/Default.xaml", UriKind.Relative)) as ResourceDictionary;
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }
                //加载默认的资源

                Resources.MergedDictionaries.Add(thems);

                //MVVMLight 的 ViewModelLocator
                ResourceDictionary mvvmRes = new ResourceDictionary();
                //mvvmRes.Add(@"Locator", new SuperSoft.View.ViewModel.ViewModelLocator());
                mvvmRes.Add(@"Locator", ServiceLocator.Current.GetInstance<House.MainModule.ViewModelLocator>());
                Resources.MergedDictionaries.Add(mvvmRes);

                //启动对象
                StartupUri = new Uri(@"/House.Shell;component/MainWindow.xaml", UriKind.Relative);
            }
            //初始化错误提示
            catch (Exception e)
            {
                Utility.LogHelper.Error("", e);
                MessageBox.Show(e.Message, @"错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 未处理的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Utility.LogHelper.Fatal("发生未处理的异常", e.Exception);
            MessageBox.Show(e.Exception.Message, @"错误", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
