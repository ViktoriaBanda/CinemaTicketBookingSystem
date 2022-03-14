using System.Collections.Generic;
using SQLite;

namespace Cinema.Models
{
    public class UserBaseModel
    {
        private SQLiteConnection _dataBase;

        public UserBaseModel(string dataBasePath)
        {
            _dataBase = new SQLiteConnection(dataBasePath);
            _dataBase.CreateTable<User>();
        }

        public IEnumerable<User> GetItems()
        {
            return _dataBase.Table<User>();
        }

        public void AddItem(User newUser)
        {
            if (newUser.Id != 0)
            {
                _dataBase.Update(newUser);
            }
            else
            {
                _dataBase.Insert(newUser);
            }
        }
        
        public void ClearDataBase()
        {
            _dataBase.DeleteAll<User>();
        }
    }
}
        
    
