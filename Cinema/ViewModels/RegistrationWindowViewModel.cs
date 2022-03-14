using System.Collections.Generic;
using Cinema.Models;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class RegistrationWindowViewModel : ViewModelBase
    {
        public delegate void RegistrationHandler();
        public event RegistrationHandler OnRegistrationEnd;
        
        private string _login = "";
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                this.RaisePropertyChanged(nameof(Login));
            }
        }
        
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                this.RaisePropertyChanged(nameof(Password));
            }
        }

        private void Register()
        {
            var allUsers = App.UserDataBase.GetItems();
            if(AreSuchParametersAlreadyExist(allUsers))
            {
                Login = "Такой логин уже занят";
                Password = "";
            }

            else
            {
                App.UserDataBase.AddItem(new User(Login, Password));
                OnRegistrationEnd?.Invoke();
            }
        }

        private bool AreSuchParametersAlreadyExist(IEnumerable<User> allUsers)
        {
            foreach (var allUser in allUsers)
            {
                if (allUser.Login == Login)
                {
                    return true;
                }
            }

            return false;
        }
    }
}