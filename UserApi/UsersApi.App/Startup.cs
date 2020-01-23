using UsersApi.Business.Interfaces;
using UsersApi.Business.Services;
using UsersApi.Data.Interfaces;
using UsersApi.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using UsersApi.Data.Entities;
using UsersApi.Business.Models;

namespace UsersApi.App
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TestDb")));

            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IUserBusiness, UserBusiness>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<UserEntity, User>().ReverseMap();
                mc.CreateMap<User, UserEntity>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
