using Examen.Domain.Entities.Examen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Domain.BussinesRules.Usuario
{
    public static class UsuarioRules
    {
        public static void ValidaNombre(Users oResponse)
        {
            if(oResponse == null)
            {
                throw new ArgumentException("#El Usuario no existe en la base");
            }
        }

        public static void ValidaPass(Users oResponse)
        {
            if (oResponse == null)
            {
                throw new ArgumentException("#La contraseña es incorrecta");
            }
        }

        public static void ValidaEstatusUser(Users oResponse)
        {
            if (oResponse.estatus == 0)
            {
                throw new ArgumentException("#El usuario no esta Vigente");
            }
        }



    }
}
