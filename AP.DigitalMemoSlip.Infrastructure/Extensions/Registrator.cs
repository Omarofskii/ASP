using AP.DigitalMemoSlip.Application.Interfaces;
using AP.DigitalMemoSlip.Infrastructure.Contexts;
using AP.DigitalMemoSlip.Infrastructure.Repositories;
using AP.DigitalMemoSlip.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DigitalMemoSlip.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            return services;
        }
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<DigitalMemoSlipContext>(options =>
                        options.UseSqlServer("name=ConnectionStrings:DigitalMemoSlipDatabase"));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IConsignersRepository, ConsignersRepository>();
            services.AddScoped<IBrokersRepository, BrokersRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            return services;
        }
    }
}
