using System;
using System.Collections.Generic;
using SQLite;

namespace Cinema.Models
{
    public class TicketsBaseModel
    {
        private SQLiteConnection _dataBase;

        public TicketsBaseModel(string ticketsBasePath)
        {
            _dataBase = new SQLiteConnection(ticketsBasePath);
            _dataBase.CreateTable<Ticket>();
        }

        public List<Ticket> GetItems()
        {
            return _dataBase.Table<Ticket>().ToList();
        }
        
        public List<Ticket> GetSelectedItems(string filmTitle)
        {
            var ticketsList = from ticket in _dataBase.Table<Ticket>()
              where ticket.FilmName == filmTitle select ticket;

            return ticketsList.ToList();
        }

        public bool IsItemInBase(int id)
        {
            try
            {
                _dataBase.Get<Ticket>(id);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public int AddItem(Ticket newTicket)
        {
            if (newTicket.Id != 0)
            {
                _dataBase.Update(newTicket);
            }
            else
            {
                _dataBase.Insert(newTicket);
            }
            return newTicket.Id;
        }

        public void DeleteItem(int id)
        {
            _dataBase.Delete<Ticket>(id);
        }

        public void ClearDataBase()
        {
            _dataBase.DeleteAll<Ticket>();
        }
    }
}