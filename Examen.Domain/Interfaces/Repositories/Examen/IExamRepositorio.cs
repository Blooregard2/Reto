using Examen.Domain.Entities.Examen;

namespace Examen.Domain.Interfaces.Repositories.Examen
{
    public interface IExamRepositorio
    {
       public  Users LogIn(string Usuario, string Pass);
        Task<List<Users>> GetUsers(Users request);

        Task<List<Users>> GetUsersAll(int PageNumber , int PageSize);

        public  Task<Users> AddUsuario(Users user);
        public  Task<Users> ModUsuario(Users user);
        public  Task<Users> DelUsuario(string user);


    }
}
