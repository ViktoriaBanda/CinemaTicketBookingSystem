using System.Collections.Generic;
using Avalonia.Controls;
using Cinema.Models;
using Cinema.Views;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RegistrationWindowViewModel _registrationWindowViewModel;

        private User _currentUser;
        
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                this.RaisePropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                this.RaisePropertyChanged(nameof(Password));
            }
        }

        private string _title = "Авторизация";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                this.RaisePropertyChanged(nameof(Title));
            }
        }

        private void ShowRegistrationWindow()
        {
            _registrationWindowViewModel = new RegistrationWindowViewModel();
            var registrationWindow = new RegistrationWindow()
            {
                DataContext = _registrationWindowViewModel
            };

            _registrationWindowViewModel.OnRegistrationEnd += ChangeTitle;
            _registrationWindowViewModel.OnRegistrationEnd += registrationWindow.Close; 
            
            registrationWindow.Show();
        }

        private void ChangeTitle()
        {
            Title = "Вы успешно зарегистрированы!";
        }
        
        private void IsСorrectPassword()
        {
            if (TryToLogIn())
            {
                var userWindowViewModel = new UserWindowViewModel(_currentUser);
                var userWindow = new UserWindow()
                {
                  DataContext = userWindowViewModel
                };

                userWindow.Show();
                userWindowViewModel.OnExit += userWindow.Close;
            }
            else
            {
                Login = "Неверный логин или пароль";
                Password = "Неверный логин или пароль";
                Title = "Авторизация";
            }
        }

        private bool TryToLogIn()
        {
            var allUsers = App.UserDataBase.GetItems();
            if(IsWrightLoginAndPassword(allUsers))
            {
                return true;
            }

            return false;
        }

        private bool IsWrightLoginAndPassword(IEnumerable<User> allUsers)
        {
            foreach (var allUser in allUsers)
            {
                if (allUser.Login == Login && allUser.Password == Password)
                {
                    _currentUser = allUser;
                    return true;
                }
            }

            return false;
        }
    }
}