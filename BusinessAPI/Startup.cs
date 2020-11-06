using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAPI.DataAccess;
using BusinessAPI.Domain.Config;
using BusinessAPI.Services;
using BusinessAPI.Services.Airport;
using BusinessAPI.Services.Bitcoin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BusinessAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("BusinessAPICorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IBitcoinService, BitcoinService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                { 
                    Version = "v1", Title = "Business API Documentation Portal", 
                    Description = "This is the API Documentation Portal for our Business consisting of APIs in Aviation, Software Development, Business, Trading, etc " 
                });
            });
            //services.AddCustomServices();
            services.Configure<AirportAPISettings>(options => Configuration.GetSection("AirportAPISettings").Bind(options));
            services.Configure<BitcoinAPISettings>(options => Configuration.GetSection("BitcoinAPISettings").Bind(options));

            

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
            app.UseCors("BusinessAPICorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "Business API Documentation Portal");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
