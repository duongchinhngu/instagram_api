using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.AutoMapper;
using Instagram.Helpers.SortHelpers;
using Instagram.Models;
using Instagram.Services;
using Instagram.Services.IServices;
using Instagram.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Instagram
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region addScopeToConfig
        private void AddScopeToConfig(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostImageService, PostImageService>();
            services.AddScoped<ISortHelper, SortHelper>();
        }
        #endregion

        #region addswaggerToConfig
        private void AddSwaggerToConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Instagram API",
                        Version = "V1",
                        Description = "Instagram ASP.NET Core Web API",
                        TermsOfService = new Uri("https://www.thecodebuzz.com/resolved-failed-to-load-api-definition-undefined-swagger-v1-swagger-json/"),
                        Contact = new OpenApiContact
                        {
                            Name = "Duong Chinh Ngu",
                            Email = string.Empty,
                            Url = new Uri("https://www.thecodebuzz.com/resolved-failed-to-load-api-definition-undefined-swagger-v1-swagger-json/"),
                        },
                    });
            });
        }
        #endregion

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
                });
            });
            //
            AddScopeToConfig(services);
            //
            AddSwaggerToConfig(services);
            // mapper
            services.AddAutoMapper(typeof(Startup));
            //add db context
            services.AddDbContext<InstagramDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InstagramDBConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Instagram API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
