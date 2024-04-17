using Examen.Domain.BussinesRules.Usuario;
using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infraestructure.Repositories.Usuario
{
    public class UsuarioRepository : IExamRepositorio 
    { 

        private readonly ExamenContext _dbContext;
        public UsuarioRepository(ExamenContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Users LogIn(string Usuario, string Pass)
        {
            Users? oResponse = new Users();
            try
            {
                oResponse =  _dbContext.Usuarios.FirstOrDefault(u => u.usuario == Usuario);
                UsuarioRules.ValidaNombre(oResponse);
                oResponse =  _dbContext.Usuarios.FirstOrDefault(u => u.password == Pass);
                UsuarioRules.ValidaPass(oResponse);
                UsuarioRules.ValidaEstatusUser(oResponse);

                return oResponse;
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public async Task<List<Users>> GetUsers(Users request)
        {
            List<Users>? oResponse = [];
            try
            {                              
                oResponse = await _dbContext.Usuarios.Where(src => src == request).ToListAsync();                            
                return oResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public async Task<List<Users>> GetUsersAll(int PageNumber , int PageSize)
        {
            List<Users>? oResponse = [];
            try
            {
                oResponse = await _dbContext.Usuarios
                    .Skip((PageNumber -1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
                return oResponse;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public async Task<Users> AddUsuario(Users user)
        {
            Users oResponse = new Users();
            await _dbContext.Usuarios.AddAsync(user);
            var iRes = _dbContext.SaveChanges();
            if(iRes != null)
            {
                return oResponse;
            }else
            {
                throw new ArgumentException("#No se agrego el registro");
            }

            
        }

        public async Task<Users> ModUsuario(Users user)
        {
            Users oResponse = new Users();
            Users? Usuario = null;
            Usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(src => src.idusuario == user.idusuario);            
            if (Usuario != null)
            {
                Usuario.nombre = user.nombre;
                Usuario.usuario = user.usuario;
                Usuario.password = user.password;
                Usuario.idPerfil = user.idPerfil;
                Usuario.estatus = user.estatus;                
                Usuario.fechacreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                var iRes = await _dbContext.SaveChangesAsync();
                oResponse.idusuario = user.idusuario;
                if (iRes == 0 ) { throw new ArgumentException("#No se Actualizo el registro"); }
                
            }
            else
            {
                throw new ArgumentException("#No existe ese Usuario");
            }

            return oResponse;
        }

        public async Task<Users> DelUsuario(string user)
        {
            Users oResponse = new Users();
            var oReqBase = await _dbContext.Usuarios.FirstOrDefaultAsync(src => src.idusuario == Convert.ToInt16(user));
            if (oReqBase != null)            {
                _dbContext.Usuarios.Remove(oReqBase);
                var iRes = _dbContext.SaveChanges();
                if (iRes == null) { throw new ArgumentException("#No se Elimino el registro"); }
            }
            else
            {
                throw new ArgumentException("#No existe ese Usuario");
            }

            return oResponse;
        }



    }
}
