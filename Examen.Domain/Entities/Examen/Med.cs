using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.Entities.Examen
{
    public class Med
    {
        [Key]
            public int   idmedicamento {get;set;}
            public string?   nombre{get;set;}
            public string?   concentracion {get;set;}
            public int   idformafarmaceutica {get;set;}
            public decimal   precio {get;set;}
            public int   stock   {get;set;}
            public string?   presentacion {get;set;}
            public int bhabilitado { get; set; }
    }
}
