using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Usuario
{
    public class ResponseUser
    {
        public List<RespUser?> responseUsers { get; set; } = [];
    }
    public class RespUser
    {        
           public int idusuario{get;set;}
           public string? nombre{get;set;}
           public DateTime fechacreacion{get;set;}
           public string? usuario{get;set;}
           public string? password{get;set;}
           public int idperfil{get;set;}
           public int estatus { get; set; }
    }
}
