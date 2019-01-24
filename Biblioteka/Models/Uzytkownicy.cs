using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Biblioteka.Models.BibliotekaContext;

namespace Biblioteka.Models
{
    public class Uzytkownicy
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [Display(Name = "DataUrodzenia")]
        [DataType(DataType.Date)]
        public DateTime DataUro { get; set; }
        public bool Verified { get; set; }
    }
}
