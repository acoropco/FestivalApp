using AutoMapper;
using FestivalApp.API.Filters;
using FestivalApp.API.Helpers;
using FestivalApp.API.MappingProfiles;
using FestivalApp.Core.Commands.AddFestival;
using FestivalApp.Core.Helpers;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Core.Providers;
using FestivalApp.Core.Validators;
using FestivalApp.Domain.Entities;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Infrastructure.Data;
using FestivalApp.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;

namespace FestivalApp.API.Extensions
{
    public static class FestivalServicesExtensions
    {
        public static void SetIdentityDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 4;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.SignIn.RequireConfirmedEmail = true;
            })
            .AddDefaultTokenProviders();

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            services.TryAddSingleton<ISystemClock, SystemClock>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        public static void SetFestivalServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Email Sender configuration
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            services.AddSingleton(emailConfig);
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailMessageProvider, EmailMessageProvider>();

            // AutoMapper configuration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            // Register ExceptionFilter
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            // Register MediatR and its providers
            services.AddMediatR(typeof(AddFestivalCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<ICommandProvider, CommandProvider>();
            services.AddTransient<IQueryProvider, QueryProvider>();
            services.AddValidatorsFromAssemblyContaining<AddFestivalCommandValidator>();


            services.AddScoped<IFestivalRepository, FestivalRepository>();
        }
    }
}
