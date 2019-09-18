using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class CountryProfileModel : PageModel
    {
        private CoreCrudContext _context;
        public Country CountryProfile;
        public CountryProfileModel(CoreCrudContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CountryProfile = _context.Country
                                    .Include(ctr => ctr.Athletes)
                                    .FirstOrDefault(ctr => ctr.ID == id);
            return Page();
        }

    }
}
