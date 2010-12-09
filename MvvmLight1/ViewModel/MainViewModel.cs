using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string welcome;
        public string Welcome
        {
            get { return welcome; }
            set
            {
                welcome = value;
                base.RaisePropertyChanged("Welcome");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            SignInVisible = Visibility.Visible;
            SignOutVisible = Visibility.Hidden;

            SignInCommand = new RelayCommand(() => SignIn());
            SignOutCommand = new RelayCommand(() => SignOut());
            SetNameCommand = new RelayCommand(() => SetName());
            ChangeNameCommand = new Action<PropertyChangedMessage<string>>(s => ChangeName(s));

            Messenger.Default.Register<PropertyChangedMessage<string>>(this, ChangeNameCommand);

            Welcome = "Hello";

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        string name = "Bradley";

        public void ChangeName(PropertyChangedMessage<string> s)
        {
            name = s.NewValue;
        }

        public void SignIn()
        {
            Welcome = string.Format("Hello {0}!", name);
            SignInVisible = Visibility.Hidden;
            SignOutVisible = Visibility.Visible;
        }

        public void SignOut()
        {
            Welcome = "Hello!";
            SignInVisible = Visibility.Visible;
            SignOutVisible = Visibility.Hidden;
        }

        public void SetName()
        {
            new MainWindow2().ShowDialog();
        }
   
        private Visibility signInVisibility;
        public Visibility SignInVisible
        {
            get { return signInVisibility; }
            private set
            {
                signInVisibility = value;
                base.RaisePropertyChanged("SignInVisible");
            }
        }

        private Visibility signOutVisibility;
        public Visibility SignOutVisible
        {
            get { return signOutVisibility; }
            private set
            {
                signOutVisibility = value;
                base.RaisePropertyChanged("SignOutVisible");
            }
        }

        public RelayCommand SignInCommand
        {
            get;
            private set;
        }

        public RelayCommand SignOutCommand
        {
            get;
            private set;
        }

        public RelayCommand SetNameCommand
        {
            get;
            private set;
        }

        public Action<PropertyChangedMessage<string>> ChangeNameCommand
        {
            get;
            private set;
        }
    }
}