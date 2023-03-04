using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Repository.Helpers;
using Repository.RepositoryItem;
using Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sieve.Services;

namespace Repository.Configurations
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}

