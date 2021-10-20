using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Data.Models
{
    public class Holiday :BaseEntity
    {
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
