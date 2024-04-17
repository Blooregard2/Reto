﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.DTOs.Medicamento
{
    public class ResponseMedicine
    {
        public List<RMedicine?> responseMed { get; set; } = [];
    }

    public class RMedicine
    {
        public int idmedicamento { get; set; }
        public string? nombre { get; set; }
        public string? concentracion { get; set; }
        public int idformafarmaceutica { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string? presentacion { get; set; }
        public int bhabilitado { get; set; }
        public int idffarmaceutica { get; set; }
        public string? nombreF { get; set; }
        public int habilitado { get; set; }
    }
}
