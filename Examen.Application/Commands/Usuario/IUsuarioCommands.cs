using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Application.Commands.Usuario
{
    public interface IUsuarioCommands
    {
        public Task<ResponseAddUsuario> AddUsuario(RequestAddUsuario user);
        public Task<ResponseAddUsuario> ModUsuario(RequestModUsuario user);
        public Task<ResponseAddUsuario> DelUsuario(string user);
    }
}
