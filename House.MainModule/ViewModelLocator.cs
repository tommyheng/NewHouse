/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:House.MainModule"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace House.MainModule
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator : Utility.MyUserControlBase
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainModule.ViewModels.MainViewModel>();
            SimpleIoc.Default.Register<UserInfo.ViewModels.UserInfoViewModel>();
            SimpleIoc.Default.Register<HeaderNews.ViewModels.HeaderNewsViewModel>();
            SimpleIoc.Default.Register<MainMenu.ViewModels.MainMenuViewModel>();
            SimpleIoc.Default.Register<Footer.ViewModels.FooterViewModel>();
        }

        public MainModule.ViewModels.MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainModule.ViewModels.MainViewModel>();
            }
        }
        public UserInfo.ViewModels.UserInfoViewModel UserInfoViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserInfo.ViewModels.UserInfoViewModel>();
            }
        }

        public HeaderNews.ViewModels.HeaderNewsViewModel HeaderNewsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeaderNews.ViewModels.HeaderNewsViewModel>();
            }
        }

        public MainMenu.ViewModels.MainMenuViewModel MainMenuViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainMenu.ViewModels.MainMenuViewModel>();
            }
        }

        public Footer.ViewModels.FooterViewModel FooterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Footer.ViewModels.FooterViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            SimpleIoc.Default.Unregister<MainModule.ViewModels.MainViewModel>();
            SimpleIoc.Default.Unregister<UserInfo.ViewModels.UserInfoViewModel>();
            SimpleIoc.Default.Unregister<HeaderNews.ViewModels.HeaderNewsViewModel>();
            SimpleIoc.Default.Unregister<MainMenu.ViewModels.MainMenuViewModel>();
            SimpleIoc.Default.Unregister<Footer.ViewModels.FooterViewModel>();

        }

        protected override void DisposeManagedResources()
        {
            base.DisposeManagedResources();
            Cleanup();
        }
    }
}