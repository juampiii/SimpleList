using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Infraestructure.Persistence;
using SimpleList.Infraestructure.Repositories;

namespace SimpleList.Infraestructure
{
    public static class InfraestructureServicesRegistration
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ListsDBContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepository<>));
            services.AddScoped<IListRepositoryAsync, ListRepositoryAsync>();

            return services;
        }
    }
}
