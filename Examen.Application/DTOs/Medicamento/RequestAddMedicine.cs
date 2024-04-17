using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Medicamento
{
    public class RequestAddMedicine
    {
        public int idmedicamento = 0;
        public string? nombre { get; set; }
        public string? concentracion { get; set; }
        public int idformafarmaceutica { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string? presentacion { get; set; }
        public bool bhabilitado { get; set; }
    }
}
