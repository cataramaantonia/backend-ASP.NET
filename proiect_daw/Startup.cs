using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using proiect_daw.Constants;
using proiect_daw.Data;
using proiect_daw.Entities;
using proiect_daw.Repositories;
using proiect_daw.Repositories.MovieRepository;
using proiect_daw.Seeders;
using proiect_daw.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_daw
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
            services.AddControllers();
            services.AddDbContext<ProiectContext>(options => options.UseSqlServer("Data Source=DESKTOP-KCFTLA3;Initial Catalog=ProiectDAW;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom secret key for auth")),
                    ValidateIssuerSigningKey = true
                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = Helpers.SessionTokenValidator.ValidateSessionToken
                };
            });

            // Add Identity
            services.AddIdentity<User, Role>(opt =>
            {
                //For user lockout
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.Zero;
                opt.Lockout.MaxFailedAccessAttempts = 10;
            })
                .AddEntityFrameworkStores<ProiectContext>()
                .AddDefaultTokenProviders();

            //services.AddTransient<IGenericRepository, GenericRepository>();
            //services.AddTransient<IMovieRepository, MovieRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<RoleSeeder>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoleType.Admin, policy => policy.RequireRole(UserRoleType.Admin));
                options.AddPolicy(UserRoleType.User, policy => policy.RequireRole(UserRoleType.User));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, RoleSeeder seed, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            try
            {
                seed.SeedRoles().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
