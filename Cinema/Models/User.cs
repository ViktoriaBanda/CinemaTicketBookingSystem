using System.Collections.Generic;
using SQLite;

namespace Cinema.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       
        [Ignore]
        public List<Ticket> MyTickets { get; set; }
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {
        }
    }
}