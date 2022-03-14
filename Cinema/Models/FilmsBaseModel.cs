using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.ViewModels;
using SQLite;

namespace Cinema.Models
{
    public class FilmsBaseModel
    {
        private SQLiteConnection _dataBase;
        public FilmsPoster FilmsPoster;

        public FilmsBaseModel(string dataBasePath)
        {
            _dataBase = new SQLiteConnection(dataBasePath);
            _dataBase.CreateTable<Film>();

            FilmsPoster = new FilmsPoster();
        }

        public List<Film> GetItems()
        {
            return _dataBase.Table<Film>().ToList();
        }

        public Film GetItem(int id)
        {
            return _dataBase.Get<Film>(id);
        }
        
        public List<int> GetItemsId()
        {
            var filmsId =  from film in _dataBase.Table<Film>()
                select film.Id;
           return filmsId.ToList();
        }
        
        public bool IsItemInBase(int id)
        {
            try
            {
                _dataBase.Get<Film>(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public int AddItem(Film newFilm)
        {
            if (newFilm.Id != 0)
            {
                _dataBase.Update(newFilm);
            }
            else
            {
                _dataBase.Insert(newFilm);
            }
            return newFilm.Id;
        }
        
        public void ClearDataBase()
        {
            _dataBase.DeleteAll<Film>();
        }
    }
}