using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Cinema.Models;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class TicketOfficeWindowViewModel : ViewModelBase
    {
        public delegate void ReservationHandler();
        public event ReservationHandler OnReservationEnd;
        
        private Film _film;
        private Cinemas _cinema;
        private List<Ticket> _allTickets { get; }
        
        private bool[] IsButtonChecked { get; set; }
        private bool[] IsEnabled { get; set; }

        private User _currentUser;
        private int index;
       
        private Ticket _currentTicket;
        public Ticket CurrentTicket
        {
            get
            {
                _currentTicket = _allTickets[index++];
                return _currentTicket;
            } 
            
            set
            {
                _currentTicket = value;
                this.RaisePropertyChanged();
            }
        }
        
        public TicketOfficeWindowViewModel(Film film, Cinemas cinema, User currentUser)
        {
            _film = film;
            _cinema = cinema;
            _currentUser = currentUser;
            
            //25 билетов на данный фильм
            _allTickets = _cinema.TicketsOffice.GetTickets(_film);

            //выбранные места
            IsButtonChecked = new bool[25];
            IsEnabled = GetEnables();
        }
        public TicketOfficeWindowViewModel()
        {
        }

        private bool[] GetEnables()
        {
            IsEnabled = new bool[25];

            for (var i = 0; i < IsEnabled.Length; i++)
            {
                IsEnabled[i] = _allTickets[i].IsEnabled;
            }
           
            return IsEnabled;
        }

        private void Reserve()
        {
            //выбрал ли пользователь места для брони
            var IsElementsChoose = false;
            
            for (var i = 0; i < IsButtonChecked.Length; i++)
            {
                if (IsButtonChecked[i])
                {
                    IsElementsChoose = true;
                    
                    _allTickets[i].IsEnabled = false;
                    //добавляем Id пользователя билет
                    _allTickets[i].UserId = _currentUser.Id;
                    
                    //обновить в базе данных
                    App.TicketsDataBaseModel.AddItem(_allTickets[i]);
                }
            }

            if (IsElementsChoose)
            {
                OnReservationEnd?.Invoke();
            }
        }
    }
}