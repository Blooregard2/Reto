using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Usuario
{
    public class RequestPaginado
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
