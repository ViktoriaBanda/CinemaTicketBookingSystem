using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Avalonia.Media.Imaging;
using Cinema.ViewModels;
using SQLite;

namespace Cinema.Models
{
    [Table("Films")]
    public class Film 
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string Filename { get; set; }
        
        
        private const int ALL_TICKETS_NUMBER = 25;

        [Ignore]
        private string ImageUrl  { get; set; }

        public Film(string title, string time, string price, string duration, string genre, string imageUrl, string filename)
        {
            Title = title;
            Time = time;
            Price = price;

            //дурацкий кусок из-за парсинга продолжительности Аннабель
            Duration = duration == "99&#160;мин" ? "99 мин" : duration;
                
            Genre = genre;
            ImageUrl = imageUrl;
            Filename = filename;
            SaveImageFromUrl();
        }

        public Film()
        {
        }

        private void SaveImageFromUrl()
        {
            var imageHelper = new ImageHelper(Filename, ImageUrl);
        }
    }
}