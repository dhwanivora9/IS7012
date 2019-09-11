using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Athlete
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool USCitizen { get; set; }
        public decimal Weight { get; set; }

        public decimal? Height { get; set; }

        public int NationalityID { get; set; }
        public Country Nationality { get; set; }

    }
}
