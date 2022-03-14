using Cinema.Models;
using Cinema.Views;

namespace Cinema.ViewModels
{
    public class UserWindowViewModel : ViewModelBase
    {
        public delegate void ExitHandler();
        public event ExitHandler OnExit;
        
        private User _currentUser;

        public UserWindowViewModel(User currentUser)
        {
            _currentUser = currentUser;
        }
        private void Exit()
        {
            OnExit?.Invoke();
        }

        private void ChooseFilm()
        {
            var cinemasWindowViewModel = new CinemaNetworkWindowViewModel(_currentUser);
            var cinemasWindow = new CinemasWindow()
            {
                DataContext = cinemasWindowViewModel
            };

            cinemasWindow.Show();
        }

        private void OpenTickets()
        {
            var ticketsWindowViewModel = new TicketsWindowViewModel(_currentUser);
            var ticketsWindow = new TicketsWindow()
            {
                DataContext = ticketsWindowViewModel
            };

            ticketsWindow.Show();
        }
    }
}