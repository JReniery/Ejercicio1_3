using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_3
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection db;
        public DataBase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<PersonClass>();            
        }
       
        public Task<int> SavePerson(PersonClass person)
        {
            if (person.Id != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }

        // Read
        public Task<List<PersonClass>> GetPersonList()
        {
            return db.Table<PersonClass>().ToListAsync();
        }

        public Task<PersonClass> GetSinglePerson(int pId)
        {
            return db.Table<PersonClass>()
                .Where(i => i.Id == pId)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePerson(PersonClass person)
        {
            return db.DeleteAsync(person);
        }
    }
}
