using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaslManagementinfrastructure.service;
using TaslManagementinfratstructure;
using TaslManagementinfratstructure.respository;


namespace TaskManagmentApplication.service
{
 public static class  serviceManagement
        {
            // static => i dont want to inilize using new in every time so make it static 
            //scope + helper => scope Igeneric repo + nongeneric repo
            public static IServiceCollection infrastructureConfiguration(this IServiceCollection services, IConfiguration config) // we inject the configuration cuz we need connection string that in app setting that in config //
                                                                                                                                  // Iconfiguration is the built in interface and registered in .net 
            {
                //services.AddTransient // dont have saving process dont need to save the process like send email 
                //services.AddScoped // used in the process need to save  like https request 
                // services.AddSingleton // in the orocess that running when the application  is running 
                /* services.AddScoped(typeof(IGenericRespository<>),typeof(genericRepository<>));
                services.AddScoped<IcategoryRespository, categoryRespository>();  // register the categoryRepository 
                services.AddScoped<IproductRespository, productRepository>(); //register the categoryrespository 
                services.AddScoped<IPhotoRespository, PhotoRespoitory>();////register the photorespository */

                // register the unit work that have all register all the interface instead of write each register here as the box or bag include all registers we need 
                // apply unit of work
                services.AddScoped<IUnitOfWork,UnitOfWork>();
               
            services.AddSingleton<IRedisCache,RedisCacheService>();
            services.AddScoped<IAuthService,authService>();
              services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters{

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = config["jwt:issurer"],
                    ValidAudience = config["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jwt:key")) }; 

                    
                });



                      


            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

                return services;
            }
        }
    }


