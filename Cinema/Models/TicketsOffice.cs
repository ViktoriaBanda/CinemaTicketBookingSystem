using System.Collections.Generic;

namespace Cinema.Models
{
    public class TicketsOffice
    {
        public TicketsOffice(Cinemas cinema, List<Film> films)
        {
            CreateTickets(cinema, films);
        }

        private void CreateTickets(Cinemas cinema, List<Film> films)
        {
            if (App.TicketsDataBaseModel.GetItems().Count < 225)
            {
                for (int k = 0; k < 3; k++)
                {
                    for (int i = 1; i < 6; i++)
                    {
                        for (int j = 1; j < 6; j++)
                        {
                            var newTicket = new Ticket(i, j, cinema.Name, films[k].Title,
                                films[k].Time);
                            App.TicketsDataBaseModel.AddItem(newTicket);
                        }
                    }
                }
            }
        }
        
        //получить 25 билетов для конкретного фильма
        public List<Ticket> GetTickets(Film currentFilm)
        {
           var tickets = App.TicketsDataBaseModel.GetSelectedItems(currentFilm.Title);
           return tickets;
        }
    }
}