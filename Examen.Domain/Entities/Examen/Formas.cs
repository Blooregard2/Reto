using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.Entities.Examen
{
    public class Formas
    {
        [Key]
        public int idformafarmaceutica { get; set; }
        public string? nombre { get; set; }
        public int habilitado  { get; set; }
    }
}
