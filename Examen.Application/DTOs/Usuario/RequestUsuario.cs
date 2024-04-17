using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Usuario
{
    public class RequestUsuario
    {
        public int idusuario { get; set; }
        public string? nombre { get; set; }
        public string? usuario { get; set; }
        public string? password { get; set; }
        public int idPerfil { get; set; }
        public int estatus { get; set; }
        public DateTime fechacreacion { get; set; }
    }
}
