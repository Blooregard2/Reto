using Examen.Domain.Entities.Examen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.Interfaces.Repositories.Medicamentos
{
    public interface IMedicamentos
    {

        Task<List<ResponseMedicamentos>> GetAllMedicineByFiltro(Med request);

        Task<List<ResponseMedicamentos>> GetAllMedicine(int PageNumber, int PageSize);

        public Task<Med> AddMedicine(Med user);
        public Task<Med> ModMedicine(Med user);
        public Task<Med> DelMedicine(string user);

    }
}
