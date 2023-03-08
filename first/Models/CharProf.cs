using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.Models
{
    public class CharProf
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Filename { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Class { get; set; }
    }
}
