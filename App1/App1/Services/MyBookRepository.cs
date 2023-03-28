using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.Models;

namespace App1.Services
{
    public class MyBookRepository
    {
        SQLiteConnection database;
        
        public MyBookRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<MyBook>();
        }

        public IEnumerable<MyBook> GetItems()
        {
            return database.Table<MyBook>().ToList();
        }
        public MyBook GetItem(int id)
        {
            return database.Get<MyBook>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<MyBook>(id);
        }
        public int SaveItem(MyBook item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
