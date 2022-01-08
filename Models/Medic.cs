using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARA_Proiect.Models
{
    public class Medic
    {
        public int ID { get; set; }
        [Display(Name = "Nume Medic")]
        public string NumeMedic { get; set; }
        public ICollection<Pacient> Pacienti { get; set; }
    }
}
