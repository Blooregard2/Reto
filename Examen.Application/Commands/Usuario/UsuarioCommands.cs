using AutoMapper;
using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Commands.Usuario
{
    public class UsuarioCommands : IUsuarioCommands
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioCommands> _Logger;
        private IExamRepositorio _examRepositorio;

        public UsuarioCommands(IMapper mapper , ILogger<UsuarioCommands> logger , IExamRepositorio examRepositorio)
        {
            _mapper = mapper;
            _Logger = logger;
            _examRepositorio = examRepositorio;
        }

        public async Task<ResponseAddUsuario> AddUsuario(RequestAddUsuario request)
        {
            ResponseAddUsuario oResp = new ResponseAddUsuario();
            Users oRequest = _mapper.Map<RequestAddUsuario, Users>(request);
            var resp = await _examRepositorio.AddUsuario(oRequest);
            oResp = _mapper.Map<Users, ResponseAddUsuario>(resp);
            if (oResp != null)
            {
                oResp.result = true;
                return oResp;
            }else
            {
                throw new ArgumentException("Error en el Servicio");
            }

        }

        public async Task<ResponseAddUsuario> ModUsuario(RequestModUsuario request)
        {
            ResponseAddUsuario oResp = new ResponseAddUsuario();
            Users oRequest = _mapper.Map<RequestModUsuario, Users>(request);
            var resp = await _examRepositorio.ModUsuario(oRequest);
            oResp = _mapper.Map<Users, ResponseAddUsuario>(resp);
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

        public async Task<ResponseAddUsuario> DelUsuario(string request)
        {
            ResponseAddUsuario oResp = new ResponseAddUsuario();            
            var resp = await _examRepositorio.DelUsuario(request);
            oResp = _mapper.Map<Users, ResponseAddUsuario>(resp);
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
