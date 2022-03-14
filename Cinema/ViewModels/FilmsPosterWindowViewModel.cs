using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Media.Imaging;
using Cinema.Models;
using Cinema.Views;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class FilmsPosterWindowViewModel : ViewModelBase
    {
        private IEnumerable<Film> _currentCinemaFilms { get; }
        private Cinemas _cinema;
        private TicketOfficeWindowViewModel _ticketsOfficeWindowViewModel;
        private User _currentUser;
       
        private Bitmap _image = null;
        public Bitmap Image
        {
            get => _image;
            set => this.RaiseAndSetIfChanged(ref _image, value);
        }

        private Film _currentFilm;
        public Film CurrentFilm
        {
            get => _currentFilm;
            set
            {
                _currentFilm = value;

                //считать с диска картинку
                var stream = new MemoryStream(File.ReadAllBytes(_currentFilm.Filename));
                var image = new Bitmap(stream);
                Image = image;
                this.RaisePropertyChanged();
            }
        }

        public FilmsPosterWindowViewModel()
        {
        }

        public FilmsPosterWindowViewModel(Cinemas cinema, User currentUser)
        {
            _cinema = cinema;
            _currentUser = currentUser;
            
            _currentCinemaFilms = cinema.Films;
        }

        private void ChooseInterestingFilm()
        {
            if (CurrentFilm != null)
            {
                _ticketsOfficeWindowViewModel = new TicketOfficeWindowViewModel(CurrentFilm, _cinema, _currentUser);
                var ticketsWindow = new TicketOfficeWindow()
                {
                    DataContext = _ticketsOfficeWindowViewModel
                };

                _ticketsOfficeWindowViewModel.OnReservationEnd += ticketsWindow.Close;
                ticketsWindow.Show();
            }
        }
    }
}