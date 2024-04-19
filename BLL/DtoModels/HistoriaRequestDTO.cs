using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class HistoriaRequestDTO
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? IdGrupy { get; set; }
        public int TypAkcji { get; set; }
        public DateTime DateTime { get; set; }
    }
}
