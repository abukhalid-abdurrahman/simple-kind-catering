using Kind.Catering.CrossCuttingConcerns.Configs;
using Kind.Catering.Infrastructure.PostgresSqlRepository;
using Kind.Catering.Infrastructure.Repository;
using Kind.Catering.UseCase.CateringChangeByClient;
using Kind.Catering.UseCase.ClientChangeByCatering;
using Kind.Catering.UseCase.GetAllCaterings;
using Kind.Catering.UseCase.GetAllClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kind.Catering.Presentation.IoC
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientCateringChangeHistoryRepository, ClientCateringChangeHistoryRepository>();
            services.AddTransient<ICateringPointRepository, CateringPointRepository>();

            services.AddScoped<IGetAllCateringsUseCase, GetAllCateringsInteractor>();
            services.AddScoped<IGetAllClientsUseCase, GetAllClientsInteractor>();
            services.AddScoped<ICateringChangeByClientUseCase, CateringChangeByClientInteractor>();
            services.AddScoped<IClientChangeByCateringUseCase, ClientChangeByCateringInteractor>();
        }

        public static void RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CateringDbConfig>(configuration.GetSection("CateringDb"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<CateringDbConfig>>().Value);
        }
    }
}