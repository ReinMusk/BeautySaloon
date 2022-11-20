using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Register_in_massage
{
    [Table("BeautySaloon")]
    public class BeautySaloon
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Photo { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        public BeautySaloon()
        {
            
        }
    }
}
