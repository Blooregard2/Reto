using AutoMapper;
using System.Reflection;
using Examen.Application.Mapping;
namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    ///<summary>
    ///Automapper
    ///</summary>
    ///<param name="services"></param>
    ///<returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });
        return services;
    }

}

