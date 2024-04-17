using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Usuario;

namespace Examen.Application.Queries.Usuario
{
    public interface IUsuarioQueries
    {
   
        ResponseLogin GetResponseLogin(RequestLogin request);

        Task<ResponseUser> GetUsersbyfiltro(RequestUsuario request);

        Task<ResponseUser> GetUsers(int pageNumbre , int PageSize);

    }
}
