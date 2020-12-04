using System;
using SQLite;

namespace Assessment.Models
{
    [Table("ReminderList")]
    public class ReminderList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DetailString { get; set; }
    }
}
