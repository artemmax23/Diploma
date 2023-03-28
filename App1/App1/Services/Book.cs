using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Services
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<int> cost { get; set; } = new List<int>();
        public bool discount { get; set; }
        public string author { get; set; }
        public string pubhouse { get; set; }
        public string seria { get; set; }
        public float averageCost { get; set; }
    }
}
