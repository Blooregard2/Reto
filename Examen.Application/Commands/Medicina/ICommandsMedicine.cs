using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Commands.Medicina
{
    public interface ICommandsMedicine
    {
        public Task<ResponseAddMedicine> AddMedicina(RequestAddMedicine user);
        public Task<ResponseAddMedicine> ModMedicina(RequestModMedicine user);
        public Task<ResponseAddMedicine> DelMedicina(string user);
    }
}
