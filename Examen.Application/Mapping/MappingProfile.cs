using AutoMapper;
using Examen.Application.DTOs.Login;
using Examen.Application.DTOs.Medicamento;
using Examen.Application.DTOs.Usuario;
using Examen.Domain.Entities.Examen;
using System.Net;


namespace Examen.Application.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            MapExamen();
        }


        private void MapExamen()
        {
            CreateMap<ResponseLogin, Users>();
            CreateMap<Users, ResponseLogin>();

            CreateMap<Users, ResponseUser>();
            CreateMap<ResponseUser, Users>();

            CreateMap<Users, RequestUsuario>();
            CreateMap<RequestUsuario, Users>();

            CreateMap<RespUser, Users>();
            CreateMap<Users, RespUser>();


            CreateMap<RequestAddUsuario, Users>();
            CreateMap<Users, RequestAddUsuario>();

            CreateMap<ResponseAddUsuario, Users>();
            CreateMap<Users, ResponseAddUsuario>();


            CreateMap<RequestModUsuario, Users>();
            CreateMap<Users, RequestModUsuario>();


            //Medicina            ;

            CreateMap<Med, ResponseMedicine>();
            CreateMap<ResponseMedicine, Med>();

            CreateMap<Med, RequestMedicine>();
            CreateMap<RequestMedicine, Med>();

            CreateMap<RMedicine, Med>();
            CreateMap<Med, RMedicine>();

            CreateMap<RMedicine, ResponseMedicamentos>();
            CreateMap<ResponseMedicamentos, RMedicine>();




            CreateMap<RequestAddMedicine, Med>();
            CreateMap<Med, RequestAddMedicine>();

            CreateMap<ResponseAddMedicine, Med>();
            CreateMap<Med, ResponseAddMedicine>();


            CreateMap<RequestModMedicine, Med>();
            CreateMap<Med, RequestModMedicine>();


            CreateMap<ResponseMedicamentos, ResponseMedicine>();
            CreateMap<ResponseMedicine, ResponseMedicamentos>();

        }
    }

    
}
