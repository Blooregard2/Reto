using AutoMapper;
using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using Examen.Application.Queries.Usuario;
using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Examen.Domain.Interfaces.Repositories.Medicamentos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Queries.Medicina
{
    public class MedicinaQuery : ImedicinaQueries
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioQuery> _logger;
        private readonly IMedicamentos _examRepositorio;
        public MedicinaQuery(IMapper mapper, ILogger<UsuarioQuery> logger, IMedicamentos examRepositorio)
        {
            _mapper = mapper;
            _logger = logger;
            _examRepositorio = examRepositorio;
        }

        public async Task<ResponseMedicine> GetMedicineByFiltro(RequestMedicine request)
        {
            ResponseMedicine oResp = new ResponseMedicine();
            Med oRequestUser = _mapper.Map<RequestMedicine, Med>(request);
            var resp = await _examRepositorio.GetAllMedicineByFiltro(oRequestUser);
            oResp.responseMed = _mapper.Map<List<RMedicine>>(resp);
            if (oResp.responseMed != null)
            {
                return oResp;
            }
            else
            {
                throw new ArgumentException("No existe  usuario en la BD");
            }

        }


        public async Task<ResponseMedicine> GetMedicine(int pageNumber, int PageSize)
        {
            ResponseMedicine oResp = new ResponseMedicine();
            var resp = await _examRepositorio.GetAllMedicine(pageNumber, PageSize);
            oResp.responseMed = _mapper.Map<List<RMedicine>>(resp);
            if (oResp.responseMed != null)
            {
                return oResp;
            }
            else
            {
                throw new ArgumentException("No existe  usuario en la BD");
            }

        }

    }
}
