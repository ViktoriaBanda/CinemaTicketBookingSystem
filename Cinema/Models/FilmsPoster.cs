using System.Collections.Generic;
using Cinema.ViewModels;
using HtmlAgilityPack;

namespace Cinema.Models
{
    public class FilmsPoster
    {
        private HtmlWeb _web = new HtmlWeb();
        public int[][] FilmsId;
         
        private string _titleUrl;

        public FilmsPoster()
        {
            FilmsId = new int[3][];
            for (var i = 0; i < 3; i++)
            {
                FilmsId[i] = new int[3];
            }
            _titleUrl = "//*[@id=\"firstHeading\"]/text()";
        }
        
        public int[][] GenerateFilms()
        {
            FilmsId[0][0] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%9F%D0%B8%D1%80%D0%B0%D1%82%D1%8B_%D0%9A%D0%B0%D1%80%D0%B8%D0%B1%D1%81%D0%BA%D0%BE%D0%B3%D0%BE_%D0%BC%D0%BE%D1%80%D1%8F:_%D0%9F%D1%80%D0%BE%D0%BA%D0%BB%D1%8F%D1%82%D0%B8%D0%B5_%D0%A7%D1%91%D1%80%D0%BD%D0%BE%D0%B9_%D0%B6%D0%B5%D0%BC%D1%87%D1%83%D0%B6%D0%B8%D0%BD%D1%8B",
                "10:00", "5 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[13]/td/span", 
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[4]/td/span/a[3]", "https://upload.wikimedia.org/wikipedia/en/8/89/Pirates_of_the_Caribbean_-_The_Curse_of_the_Black_Pearl.png",
                "./film1.jpeg");
            FilmsId[0][1] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%9F%D0%B8%D1%80%D0%B0%D1%82%D1%8B_%D0%9A%D0%B0%D1%80%D0%B8%D0%B1%D1%81%D0%BA%D0%BE%D0%B3%D0%BE_%D0%BC%D0%BE%D1%80%D1%8F:_%D0%A1%D1%83%D0%BD%D0%B4%D1%83%D0%BA_%D0%BC%D0%B5%D1%80%D1%82%D0%B2%D0%B5%D1%86%D0%B0",
                "14:00", "5 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[14]/td/span",
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[4]/td/span/a[3]", "https://upload.wikimedia.org/wikipedia/ru/e/ed/Kinopoisk.ru-Pirates-of-the-Caribbean_3A-Dead-Man_27s-Chest-380676.jpg",
                "./film2.jpeg");
            FilmsId[0][2] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%9F%D0%B8%D1%80%D0%B0%D1%82%D1%8B_%D0%9A%D0%B0%D1%80%D0%B8%D0%B1%D1%81%D0%BA%D0%BE%D0%B3%D0%BE_%D0%BC%D0%BE%D1%80%D1%8F:_%D0%9D%D0%B0_%D0%BA%D1%80%D0%B0%D1%8E_%D1%81%D0%B2%D0%B5%D1%82%D0%B0",
                 "18:00", "5 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[14]/td/span",
            "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[4]/td/span/a[4]", "https://upload.wikimedia.org/wikipedia/ru/e/ee/Pirates3.jpg",
            "./film3.jpeg"); 
            FilmsId[1][0] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%97%D0%B2%D0%B5%D1%80%D0%BE%D0%BF%D0%BE%D0%BB%D0%B8%D1%81",
                "10:00", "4 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[18]/td/span/text()",
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[6]/td/span/a[8]", "https://upload.wikimedia.org/wikipedia/ru/9/91/Zootopia_poster.jpg",
                "./film4.jpeg");
            FilmsId[1][1] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%92%D0%B2%D0%B5%D1%80%D1%85",
                "13:00", "4 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[17]/td/span",
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[5]/td/span/a[4]", "https://upload.wikimedia.org/wikipedia/ru/4/40/Up%28poster%29.jpg", 
                "./film5.jpeg");
            FilmsId[1][2] = GenerateFilm(@"https://ru.wikipedia.org/wiki/Angry_Birds_%D0%B2_%D0%BA%D0%B8%D0%BD%D0%BE",
                 "16:00", "4 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[17]/td/span",
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[5]/td/span/a[3]", "https://upload.wikimedia.org/wikipedia/ru/0/00/AngryBirdsMovie.jpeg", 
                "./film6.jpeg");
            FilmsId[2][0] = GenerateFilm( @"https://ru.wikipedia.org/wiki/%D0%92%D0%BE%D1%81%D1%81%D1%82%D0%B0%D0%B2%D1%88%D0%B8%D0%B9_%D0%B8%D0%B7_%D0%B0%D0%B4%D0%B0",
                "18:00", "6 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[14]/td/span", 
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[4]/td/span/a", "https://upload.wikimedia.org/wikipedia/ru/6/6f/Hellraiser_DVD.jpg", 
                "./film7.jpeg");
            FilmsId[2][1] = GenerateFilm( @"https://ru.wikipedia.org/wiki/%D0%9F%D1%80%D0%BE%D0%BA%D0%BB%D1%8F%D1%82%D0%B8%D0%B5_%D0%90%D0%BD%D0%BD%D0%B0%D0%B1%D0%B5%D0%BB%D1%8C", 
                 "20:00", "6 руб", "//*[@id=\"mw-content-text\"]/div[1]/table/tbody/tr[13]/td/span/span",
                "//*[@id=\"mw-content-text\"]/div[1]/table/tbody/tr[4]/td/span/a", "https://upload.wikimedia.org/wikipedia/ru/d/d0/Annabelle_poster.jpg", 
                "./film8.jpeg");
            FilmsId[2][2] = GenerateFilm(@"https://ru.wikipedia.org/wiki/%D0%A7%D1%83%D0%B6%D0%BE%D0%B9_3", 
                 "22:00", "6 руб", "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[13]/td/span/text()[2]",
                "//*[@id=\"mw-content-text\"]/div[1]/table[1]/tbody/tr[4]/td/span/a[2]", "https://upload.wikimedia.org/wikipedia/ru/b/b9/Alien3_poster.jpg", 
                "./film9.jpeg");
            return FilmsId;
        }

        private int GenerateFilm(string html, string time, string price, 
            string durationUrl, string genreUrl, string imageUrl, string fileName)
        {
            var htmlDoc = _web.Load(html);
            var newFilm = new Film(htmlDoc.DocumentNode.SelectSingleNode
                    (_titleUrl).InnerHtml, time, price,
                htmlDoc.DocumentNode.SelectSingleNode
                    (durationUrl).InnerHtml,
                htmlDoc.DocumentNode.SelectSingleNode
                    (genreUrl).InnerHtml, imageUrl, fileName);
            newFilm.Id = App.FilmsDataBase.AddItem(newFilm);
            return newFilm.Id;
        }
    }
}