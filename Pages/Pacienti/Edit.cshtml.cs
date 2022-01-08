using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARA_Proiect.Data;
using ARA_Proiect.Models;

namespace ARA_Proiect.Pages.Pacienti
{
    public class EditModel : PageModel
    {
        private readonly ARA_Proiect.Data.ARA_ProiectContext _context;

        public EditModel(ARA_Proiect.Data.ARA_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pacient Pacient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacient = await _context.Pacient.FirstOrDefaultAsync(m => m.ID == id);

            if (Pacient == null)
            {
                return NotFound();
            }
            ViewData["MedicID"] = new SelectList(_context.Set<Medic>(), "ID", "NumeMedic");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(Pacient.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PacientExists(int id)
        {
            return _context.Pacient.Any(e => e.ID == id);
        }
    }
}
