using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Register_in_massage
{
    public class LocalRepository
    {
        SQLiteConnection database;
        public LocalRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<BeautySaloon>();
            database.CreateTable<User>();
            database.CreateTable<Appointment>();
        }

        public int SaveUser(User item)
        {
            if (item.Id == 0)
            {
                return database.Insert(item);
            }
            else
            {
                database.Update(item);
                return item.Id;
            }
        }
        public int SaveBeautySaloon(BeautySaloon item)
        {
            if (item.Id == 0)
            {
                return database.Insert(item);
            }
            else
            {
                database.Update(item);
                return item.Id;
            }
            
        }

        public int DeleteAppointment(int id)
        {
            return database.Delete<Appointment>(id);
        }
        public int DeleteBeautySaloon(int id)
        {
            return database.Delete<BeautySaloon>(id);
        }
        public BeautySaloon GetBeautySaloon(int id)
        {
            return database.Get<BeautySaloon>(id);
        }

        public List<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public List<BeautySaloon> GetSaloons()
        {
            return database.Table<BeautySaloon>().ToList();
        }

        public int SaveAppointment(Appointment app)
        {
            return database.Insert(app);
        }

        public List<Appointment> GetAllAppointments()
        {
            return database.Table<Appointment>().ToList();
        }

        public bool UserIsCorrect(User user)
        {
            return database.Get<User>(x => x.Number == user.Number && x.Password == user.Password) != null;
        }
    }
}
