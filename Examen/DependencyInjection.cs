using Examen.Application.Commands.Medicina;
using Examen.Application.Commands.Usuario;
using Examen.Application.Queries.Medicina;
using Examen.Application.Queries.Usuario;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.DependencyInjection;
///<summary>
///Inyeccion para la API
///</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioQueries, UsuarioQuery>();
        services.AddScoped<IUsuarioCommands, UsuarioCommands>();
        services.AddScoped<ICommandsMedicine, MedicinaCommands>();
        services.AddScoped<ImedicinaQueries, MedicinaQuery>();

        return services;
    }
}



