using Examen.Domain.Entities.Examen;
using Examen.Domain.Interfaces.Repositories.Examen;
using Examen.Domain.Interfaces.Repositories.Medicamentos;
using Examen.Infraestructure.Repositories;
using Examen.Infraestructure.Repositories.Medicamento;
using Examen.Infraestructure.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraEstructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        //Aqui van todo los de Interfaces y las bussines Rules y el repo y base de datos
        services.AddScoped<IExamRepositorio, UsuarioRepository>();
        services.AddScoped<IMedicamentos, MedicamentoRepository>();

        var cs = configuration["CONNECTION_STRING"];
        services.AddDbContext <ExamenContext>(
            (sp, options) =>
            {
                options.UseSqlServer(cs);
            });
        return services;
    }
}
