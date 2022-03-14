using System.Collections.Generic;
using SQLite;

namespace Cinema.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        
        public string CinemaName { get; set; }
        
        public string FilmName { get; set; }
        
        public string Time { get; set; }
        public int Row { get; set; }
        public int Site { get; set; }
        
        public int UserId { get; set; }
        
        public bool IsEnabled { get; set; }
        
        public Ticket(int row, int site, string cinemaName, string filmName, string time)
        {
            CinemaName = cinemaName;
            Row = row;
            Site = site;
            FilmName = filmName;
            Time = time;
            IsEnabled = true;
        }

        public Ticket()
        {
        }
    }
}