using AutoMapper;
using Examen.Application.Commands.Usuario;
using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Examen.Domain.Interfaces.Repositories.Medicamentos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Commands.Medicina
{
    public class MedicinaCommands : ICommandsMedicine
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioCommands> _Logger;
        private readonly IMedicamentos _MedicineCommands;

        public MedicinaCommands(IMapper mapper, ILogger<UsuarioCommands> logger, IMedicamentos examRepositorio)
        {
            _mapper = mapper;
            _Logger = logger;
            _MedicineCommands = examRepositorio;
        }

        public async Task<ResponseAddMedicine> AddMedicina(RequestAddMedicine request)
        {
            ResponseAddMedicine oResp = new ResponseAddMedicine();
            Med oRequest = _mapper.Map<RequestAddMedicine, Med>(request);
            var resp = await _MedicineCommands.AddMedicine(oRequest);
            oResp = _mapper.Map<Med, ResponseAddMedicine>(resp);
            if (oResp != null)
            {
                oResp.result = true;
                return oResp;
            }
            else
            {
                throw new ArgumentException("Error en el Servicio");
            }

        }

        public async Task<ResponseAddMedicine> ModMedicina(RequestModMedicine request)
        {
            ResponseAddMedicine oResp = new ResponseAddMedicine();
            Med oRequest = _mapper.Map<RequestModMedicine, Med>(request);
            var resp = await _MedicineCommands.ModMedicine(oRequest);
            oResp = _mapper.Map<Med, ResponseAddMedicine>(resp);
            if (oResp != null)
            {
                oResp.result = true;
                return oResp;
            }
            else
            {
                throw new ArgumentException("Error en el Servicio");
            }

        }

        public async Task<ResponseAddMedicine> DelMedicina(string request)
        {
            ResponseAddMedicine oResp = new ResponseAddMedicine();
            var resp = await _MedicineCommands.DelMedicine(request);
            oResp = _mapper.Map<Med, ResponseAddMedicine>(resp);
            if (oResp != null)
            {
                oResp.result = true;
                return oResp;
            }
            else
            {
                throw new ArgumentException("Error en el Servicio");
            }

        }
    }
}
