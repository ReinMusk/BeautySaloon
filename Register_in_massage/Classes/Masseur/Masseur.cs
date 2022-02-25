using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Register_in_massage
{
    [Table("Masseurs")]
    public class Masseur
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int WorkExperience { get; set; }
    }
}
