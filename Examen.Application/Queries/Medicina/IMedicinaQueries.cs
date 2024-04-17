using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Queries.Medicina
{
    public interface ImedicinaQueries
    {        

        Task<ResponseMedicine> GetMedicineByFiltro(RequestMedicine request);

        Task<ResponseMedicine> GetMedicine(int pageNumbre, int PageSize);
    }
}
