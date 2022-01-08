using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARA_Proiect.Models
{
    public class Pacient
    {

        public int ID { get; set; }
        [Display(Name = "Nume Pacient")]
        public string Nume { get; set; }
        [Display(Name = "Telefon")]
        public string NumarTelefon { get; set; }
        [Display(Name = "Scopul vizitei")]
        public string TipProgramare { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        // [DataType(DataType.Date)]
        [Display(Name  = "Data Programare")]
        public DateTime PublishingDate { get; set; }

        public int MedicID { get; set; }
        public Medic Medic { get; set; }
    }
}
