using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Usuario
{
    public class RequestAddUsuario
    {
        public int idusuario = 0;
        public string? nombre { get; set; }
        public string? usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,15}$",
       ErrorMessage = "La contraseña debe tener al menos 8 caracteres, incluyendo una mayúscula, un número y un carácter especial.")]
        public string? password { get; set; }
        public int idPerfil { get; set; }
        public int estatus { get; set; }
    }
}
