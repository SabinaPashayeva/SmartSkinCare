using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartSkinCare.BusinessLogic;
using SmartSkinCare.BusinessLogic.Abstractions;
using SmartSkinCare.BusinessLogic.Authentication;
using SmartSkinCare.BusinessLogic.Services;
using SmartSkinCare.BusinessLogic.SkinAnalyser;
using SmartSkinCare.DataAccessLayer;
using SmartSkinCare.DataAccessLayer.Abstractions;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DI
{
    public static class ServiceRegistratorExtension
    {
        public static IServiceCollection AddServiceRegistrator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("SkinCareDb")));

            services.AddIdentity<ApplicationUser, IdentityRole>(o => o.Password.RequireNonAlphanumeric = false)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthenticationSettings.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = AuthenticationSettings.AUDIENCE,
                    ValidateLifetime = true,

                    IssuerSigningKey = AuthenticationSettings.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddAutoMapper();
            services.AddHttpContextAccessor();

            services.AddScoped<IAuthorizationService, UserAuthorizationService>();
            services.AddScoped<ICreamRepository, CreamRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHumidityRepository, HumidityRepository>();
            services.AddScoped<IOilinessRepository, OilinessRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICreamService, CreamService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<ISkinHumidityService, SkinHumidityService>();
            services.AddScoped<ISkinOilinessService, SkinOilinessService>();
            services.AddScoped<UserContext>();
            services.AddScoped<ISkinAnalyser, SkinAnalyser>();
            services.AddScoped<IRecommendationService, RecommendationService>();

            return services;
        }
    }
}
