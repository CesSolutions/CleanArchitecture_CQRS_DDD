using Final_SophieTravelManagement.Application.Services;
using Final_SophieTravelManagement.Domain.Respositories;
using Final_SophieTravelManagement.Infrastructure.EF.Contexts;
using Final_SophieTravelManagement.Infrastructure.EF.Options;
using Final_SophieTravelManagement.Infrastructure.EF.Repositories;
using Final_SophieTravelManagement.Infrastructure.EF.Services;
using Final_SophieTravelManagement.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITravelerCheckListRepository, TravelerCheckListRepository>();
            services.AddScoped<ITravelerCheckListReadService, TravelerCheckListReader>();

            // Get from API appsettings.json
            var options = configuration.GetOptions<DataBaseOptions>("ConnectionStrings:TravelerConnectionString");

            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
