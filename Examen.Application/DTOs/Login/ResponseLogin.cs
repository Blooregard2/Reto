using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Login
{
    public  class ResponseLogin
    {
        public string idusuario { get; set; }
        public string nombre { get; set; }
        public string idperfil { get; set; }
        public string usuario { get; set; }
        public int estatus { get; set; }
    }
}
