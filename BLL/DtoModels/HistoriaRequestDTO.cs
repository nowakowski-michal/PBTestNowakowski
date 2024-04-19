using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class HistoriaRequestDTO
    {
        public string Imie { get; init; }
        public string Nazwisko { get; init; }
        public int? IdGrupy { get; init; }
        public int TypAkcji { get; init; }
        public DateTime DateTime { get; init; }
    }
}
