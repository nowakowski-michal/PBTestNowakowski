using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class StudentResponseDTO
    {
        public int Id { get; init; }
        public string Imie { get; init; }
        public string Nazwisko { get; init; }
        public string NazwaGrupy { get; init; }
    }
}
