using System;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Users.Domain;
using Users.Domain.Models;
using Users.Domain.Repositories;
using Users.Service;

namespace Users.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UsersDatabase")));


            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>();
            services.Configure<IdentityOptions>(options=>
                options.User.RequireUniqueEmail = true);

            var audienceSettings = Configuration.GetSection("Audience");
            services.Configure<Audience>(audienceSettings);
         
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceSettings["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceSettings["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceSettings["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "TestKey";
                })
                .AddJwtBearer("TestKey", x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = tokenValidationParameters;
                });
            services.AddAutoMapper(typeof(IUserService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                    
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
