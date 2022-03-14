using System.Collections.Generic;
using Cinema.Models;

namespace Cinema.Models
{
    public class Cinemas
    {
        public string Name { get; }
        public string Information { get; }
        
        public List<Film> Films;

        private int[] _filmsId;
        
        public TicketsOffice TicketsOffice;
        
        public Cinemas(string name, string information, int[]filmsId)
        {
            Name = name;
            Information = information;
            _filmsId = filmsId;
            Films = new List<Film>();
            GetFilms();
            TicketsOffice = new TicketsOffice(this, Films);
        }

        private void GetFilms()
        {
            for (int i = 0; i < 3; i++)
            {
                if (App.FilmsDataBase.IsItemInBase(_filmsId[i]))
                {
                    Films.Add(App.FilmsDataBase.GetItem(_filmsId[i]));
                }
            }
        }
    }
}