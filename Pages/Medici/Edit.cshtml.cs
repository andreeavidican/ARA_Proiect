﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ARA_Proiect.Data;
using ARA_Proiect.Models;

namespace ARA_Proiect.Pages.Medici
{
    public class EditModel : PageModel
    {
        private readonly ARA_Proiect.Data.ARA_ProiectContext _context;

        public EditModel(ARA_Proiect.Data.ARA_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medic Medic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medic = await _context.Medic.FirstOrDefaultAsync(m => m.ID == id);

            if (Medic == null)
            {
                return NotFound();
            }
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

            _context.Attach(Medic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicExists(Medic.ID))
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

        private bool MedicExists(int id)
        {
            return _context.Medic.Any(e => e.ID == id);
        }
    }
}
