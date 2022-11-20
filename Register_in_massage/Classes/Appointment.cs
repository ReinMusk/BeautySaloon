using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Register_in_massage
{
    [Table("Appointments")]
    public class Appointment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int IdUser { get; set; }
        public int IdSaloon { get; set; }

        public Appointment()
        {

        }
    }
}
