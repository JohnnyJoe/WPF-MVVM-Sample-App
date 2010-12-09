/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
  
  OR (WPF only):
  
  xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
  DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
*/

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the ViewModelLocatorTemplate in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// <para>
    /// In <strong>*WPF only*</strong> (and if databinding in Blend is not relevant), you can delete
    /// the Main property and bind to the ViewModelNameStatic property instead:
    /// </para>
    /// <code>
    /// xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
    /// DataContext="{Binding Source={x:Static vm:ViewModelLocatorTemplate.ViewModelNameStatic}}"
    /// </code>
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}

            CreateMainViewModel();
            CreateMainViewModel2();
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMainViewModel();
            ClearMainViewModel2();
        }

        #region MainViewModel
        private static MainViewModel _main;
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static MainViewModel MainViewModelStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMainViewModel();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return MainViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Main property.
        /// </summary>
        public static void ClearMainViewModel()
        {
            if (_main == null)
                return;

            _main.Cleanup();
            _main = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMainViewModel()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }
        #endregion

        #region MainViewModel2
        private static MainViewModel2 _mainViewModel2;
        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMainViewModel2()
        {
            if (_mainViewModel2 == null)
            {
                _mainViewModel2 = new MainViewModel2();
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        public static MainViewModel2 MainViewModel2Static
        {
            get
            {
                if (_mainViewModel2 == null)
                {
                    CreateMainViewModel2();
                }

                return _mainViewModel2;
            }
        }

        /// <summary>
        /// Gets the ViewModelPropertyName property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel2 MainViewModel2
        {
            get
            {
                return _mainViewModel2;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the ViewModelPropertyName property.
        /// </summary>
        public static void ClearMainViewModel2()
        {
            if (_mainViewModel2 == null)
                return;

            _mainViewModel2.Cleanup();
            _mainViewModel2 = null;
        }
        #endregion
    }
}