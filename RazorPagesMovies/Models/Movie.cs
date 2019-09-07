using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public int Title { get; set; }

        [DataType(DataType.Date)]         
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal price { get; set; }


    }
}
