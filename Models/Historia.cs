using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum TypAkcji
    {
        Edycja,
        Usuwanie
    }
    public class Historia
    {
        [Key]
        public int Id { get; set; }
        public string Imie {  get; set; }
        public string Nazwisko { get; set; }
        public int? IdGrupy { get; set; }
        public TypAkcji TypAkcji { get; set;}
        public DateTime DateTime { get; set; }
    }
}
