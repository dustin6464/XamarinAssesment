using System;
using SQLite;

namespace Assessment.Models
{
    public class Reminder
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Deails { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Completed { get; set; }

        public int ListId { get; set; }
    }
}
