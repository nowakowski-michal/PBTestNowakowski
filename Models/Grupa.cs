using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grupa
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public List<Student>? Students { get; set; }
        //RELACJA REKURENCYJNA
        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Grupa? Parent { get; set; }
        public List<Grupa>? Children { get; set; }


        //między historia a grupa nie widzę sensu relacji wiec jej nie tworzę
        //tabela ma przechowywać tylko id jak było powiedziane, a nazwę grupy moge pobrać z relacji student-grupa
    }

}
