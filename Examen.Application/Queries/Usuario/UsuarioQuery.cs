using AutoMapper;
using Azure;
using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Microsoft.Extensions.Logging;


namespace Examen.Application.Queries.Usuario
{
    public class UsuarioQuery : IUsuarioQueries
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioQuery> _logger;
        private readonly IExamRepositorio _examRepositorio;        
        public UsuarioQuery(IMapper mapper , ILogger<UsuarioQuery> logger, IExamRepositorio examRepositorio)
        {
            _mapper = mapper;
            _logger = logger;
            _examRepositorio = examRepositorio;            
        }
        public ResponseLogin GetResponseLogin(RequestLogin request)
        {
            
            var resp =  _examRepositorio.LogIn(request.email, request.pass);
            ResponseLogin oResp = _mapper.Map<Users, ResponseLogin>(resp);
            
            return oResp;
        }


        public async Task<ResponseUser> GetUsersbyfiltro(RequestUsuario request)
        {
            ResponseUser oResp = new ResponseUser();
            Users oRequestUser = _mapper.Map<RequestUsuario, Users>(request);
            var resp = await _examRepositorio.GetUsers(oRequestUser);
            oResp.responseUsers = _mapper.Map<List<RespUser>>(resp);
            if(oResp.responseUsers != null)
            {
                return oResp;
            }else
            {
                throw new ArgumentException("No existe  usuario en la BD");
            }
            
        }


        public async Task<ResponseUser> GetUsers(int pageNumber, int PageSize)
        {
            ResponseUser oResp = new ResponseUser();            
            var resp = await _examRepositorio.GetUsersAll(pageNumber ,PageSize);
            oResp.responseUsers = _mapper.Map<List<RespUser>>(resp);
            if (oResp.responseUsers != null)
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
