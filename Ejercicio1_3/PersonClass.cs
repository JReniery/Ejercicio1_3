using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_3
{
    public class PersonClass
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
