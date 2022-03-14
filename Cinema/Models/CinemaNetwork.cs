using System.Collections.Generic;
using System.IO;

namespace Cinema.Models
{
    public class CinemaNetwork
    {
        public List<Cinemas> AllCinemas { get; set; }

        private int[][] _filmsId;
        
        private const int CINEMAS_FILMS_COUNTER = 3;
        
        public CinemaNetwork()
        {
            //очистка базы фильмов
            //App.FilmsDataBase.ClearDataBase();
            
            var allFilms = App.FilmsDataBase.GetItems();
            
            //заполнение базы данных фильмов, если она пустая
            if (allFilms.Count == 0)
            {
                _filmsId = App.FilmsDataBase.FilmsPoster.GenerateFilms();
            }
            else
            {
                //забирам из БД Id фильмов 
                GetFilmsFromDataBase(allFilms);
            }

            CreateCinemas();
        }

        private void CreateCinemas()
        {
            AllCinemas = new List<Cinemas>
            {
                new("Жемчужина", "Всё о пиратах", _filmsId?[0]),
                new("Карусель", "Детский", _filmsId?[1]),
                new("Хэллоуин", "Страшный", _filmsId?[2])
            };
        }

        private void GetFilmsFromDataBase(List<Film> items)
        {
            _filmsId = App.FilmsDataBase.FilmsPoster.FilmsId;
               
            for (var k = 0; k < items.Count;)
            {
                for (var i = 0; i < CINEMAS_FILMS_COUNTER && k < items.Count; i++)
                {
                    for (var j = 0; j < CINEMAS_FILMS_COUNTER && k < items.Count; j++)
                    {
                        _filmsId[i][j] = items[k].Id;
                        k++;
                    }
                }
            }
        }
    }
}