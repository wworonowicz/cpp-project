using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Biblioteka.Models.BibliotekaContext;


namespace Biblioteka.Models
{
    public class Books
    {
        internal object User;

        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [Display(Name = "Release Day")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        public List<Wypozyczenie> Wypozyczenie { get; set; }

    }
}
