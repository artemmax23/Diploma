using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    [Table("MyBooks")]
    public class MyBook
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }
    }
}
