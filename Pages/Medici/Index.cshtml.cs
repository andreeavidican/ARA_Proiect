using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ARA_Proiect.Data;
using ARA_Proiect.Models;

namespace ARA_Proiect.Pages.Medici
{
    public class IndexModel : PageModel
    {
        private readonly ARA_Proiect.Data.ARA_ProiectContext _context;

        public IndexModel(ARA_Proiect.Data.ARA_ProiectContext context)
        {
            _context = context;
        }

        public IList<Medic> Medic { get;set; }

        public async Task OnGetAsync()
        {
            Medic = await _context.Medic.ToListAsync();
        }
    }
}
