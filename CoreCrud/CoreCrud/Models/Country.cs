using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is compulsory")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = " Please provide a valid country name")]
        public string CountryName { get; set; }
        public ICollection<Athlete> Athletes { get; set; }


    }
}
