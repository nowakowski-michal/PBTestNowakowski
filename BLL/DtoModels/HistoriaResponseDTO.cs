using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class HistoriaResponseDTO
    {
        public int Id { get; init; }
        public string Imie { get; init; }
        public string Nazwisko { get; init; }
        public string NazwaGrupy { get; init; }
        public string TypAkcji { get; init; }
        public DateTime DateTime { get; init; }
    }
}
