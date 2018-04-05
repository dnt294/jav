using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jav.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using jav.Services.CRUDServices;
using jav.Entities;

namespace jav
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
            services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration["ConnectionStrings:DefaultConnection"]));
            ConfigureDataServices(services);

            services.AddMvc();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();
        }

        public void ConfigureDataServices(IServiceCollection services)
        {
            services.AddTransient<ICRUDService<Lesson>, LessonService>();
        }
    }
}
