using System.Collections.Generic;
using Cinema.Models;
using Cinema.Views;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class CinemaNetworkWindowViewModel: ViewModelBase
    {
        private Cinemas _currentCinema;
        private FilmsPosterWindowViewModel _filmsPosterWindowViewModel;
        private CinemaNetwork _cinemaNetwork;
        private List<Cinemas> _allCinemas { get; }

        private User _currentUser;
        public Cinemas CurrentCinema
        {
            get => _currentCinema;
            set
            {
                _currentCinema = value;
                this.RaisePropertyChanged();
            }
        }

        public CinemaNetworkWindowViewModel(User currentUser)
        {
            _currentUser = currentUser;
            _cinemaNetwork = new CinemaNetwork();
            _allCinemas = _cinemaNetwork.AllCinemas;
        }

        private void ChooseCinema()
        {
            if (CurrentCinema != null)
            {
                _filmsPosterWindowViewModel = new FilmsPosterWindowViewModel(CurrentCinema, _currentUser);
                var filmsWindow = new FilmsWindow()
                {
                    DataContext = _filmsPosterWindowViewModel
                };

                filmsWindow.Show();
            }
        }
    }
}