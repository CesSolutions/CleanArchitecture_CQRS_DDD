﻿using Final_SophieTravelManagement.Domain.Factories;
using Final_SophieTravelManagement.Domain.Policies;
using Final_SophieTravelManagement.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Final_SophieTravelManagement.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ITravelerCheckListFactory, TravelerCheckListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(ITravelerItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<ITravelerItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
