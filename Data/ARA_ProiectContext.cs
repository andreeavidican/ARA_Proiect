using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ARA_Proiect.Models;

namespace ARA_Proiect.Data
{
    public class ARA_ProiectContext : DbContext
    {
        public ARA_ProiectContext (DbContextOptions<ARA_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<ARA_Proiect.Models.Pacient> Pacient { get; set; }

        public DbSet<ARA_Proiect.Models.Medic> Medic { get; set; }
    }
}
