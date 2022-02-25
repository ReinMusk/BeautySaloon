using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Register_in_massage
{
    public class MasseurRepository
    {
        SQLiteConnection database;
        public MasseurRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Masseur>();
        }
        public IEnumerable<Masseur> GetItems()
        {
            return database.Table<Masseur>().ToList();
        }
        public Masseur GetItem(int id)
        {
            return database.Get<Masseur>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Masseur>(id);
        }
        public int SaveItem(Masseur item)
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
