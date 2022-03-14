using System.Collections.Generic;
using Cinema.Models;
using ReactiveUI;

namespace Cinema.ViewModels
{
    public class TicketsWindowViewModel: ViewModelBase
    {
        private List<Ticket> _currentUserTickets { get; }
        private User _currentUser;
        
        private Ticket _currentItem;
        public Ticket CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                this.RaisePropertyChanged();
            }
        }

        public TicketsWindowViewModel(User currentUser)
        {
            _currentUser = currentUser;
            var allTickets = App.TicketsDataBaseModel.GetItems();
            
            _currentUser.MyTickets = new List<Ticket>();
            
            for (var i = 0; i < allTickets.Count; i++)
            {
                if (_currentUser.Id == allTickets[i].UserId)
                {
                    _currentUser.MyTickets.Add(allTickets[i]);
                }
            }

            _currentUserTickets = _currentUser.MyTickets;
        }
    }
}