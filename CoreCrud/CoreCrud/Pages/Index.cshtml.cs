using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrudContext _context;
        public IndexModel(CoreCrud.Models.CoreCrudContext context)
        {
            _context = context;
        }
        public int AthletefromIndia;
        public int AthletefromUsa;
        public int AthletefromChina;

        public void OnGet()
        {
            AthletefromIndia = _context.Athlete
                                        .Where(x => x.Nationality.CountryName == "India")
                                        .Count();
            AthletefromUsa = _context.Athlete
                                        .Where(x => x.Nationality.CountryName == "usa")
                                        .Count();
            AthletefromChina = _context.Athlete
                            .Where(x => x.Nationality.CountryName == "china")
                            .Count();
        }
    }
}
