using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondMouse.Models;
using Microsoft.EntityFrameworkCore;

namespace SecondMouse
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
            services.AddDbContext<ServicesContext>(opt =>
                opt.UseInMemoryDatabase("Services"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SecondMouse", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecondMouse v1"));
            }

            var scope = app.ApplicationServices.CreateScope();
            var servicesContext = scope.ServiceProvider.GetService<ServicesContext>();
            AddData(servicesContext);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddData(ServicesContext servicesContext)
        {
            var service = new Models.Services
            {
                Id = 1,
                state = "NH",
                county = "Merrimack",
                eFile = true,
                RON = true,
                RIN = false,
                otherService = true,
                otherService2 = false
            };
            servicesContext.Services.Add(service);
            service = new Models.Services
            {
                Id = 2,
                state = "NH",
                county = "Strafford",
                eFile = true,
                RON = false,
                RIN = true,
                otherService = true,
                otherService2 = false
            };
            servicesContext.Services.Add(service);
            service = new Models.Services
            {
                Id = 3,
                state = "FL",
                county = "Orange",
                eFile = true,
                RON = false,
                RIN = false,
                otherService = true,
                otherService2 = true
            };
            servicesContext.Services.Add(service);
            service = new Models.Services
            {
                Id = 4,
                state = "FL",
                county = "Brevard",
                eFile = false,
                RON = false,
                RIN = true,
                otherService = true,
                otherService2 = true
            };
            servicesContext.Services.Add(service);
            service = new Models.Services
            {
                Id = 5,
                state = "TX",
                county = "Harris",
                eFile = false,
                RON = true,
                RIN = false,
                otherService = false,
                otherService2 = true
            };
            servicesContext.Services.Add(service);
            service = new Models.Services
            {
                Id = 6,
                state = "TX",
                county = "Austin",
                eFile = false,
                RON = false,
                RIN = true,
                otherService = true,
                otherService2 = false
            };
            servicesContext.Services.Add(service);

            servicesContext.SaveChanges();

            var signingService = new Models.SigningServices
            {
                Id = 1,
                name = "Joe Signing Service",
                email = "jsign@gmail.com",
                address = "23 Main Street",
                city = "Concord",
                state = "NH"
            };
            servicesContext.SigningServices.Add(signingService);
            signingService = new Models.SigningServices
            {
                Id = 2,
                name = "Other Signing Service",
                email = "other@gmail.com",
                address = "23 Main Street",
                city = "Concord",
                state = "NH"
            };
            servicesContext.SigningServices.Add(signingService);
            signingService = new Models.SigningServices
            {
                Id = 3,
                name = "The Best Signing Service",
                email = "bestsign@gmail.com",
                address = "321 Alligator Drive",
                city = "Orlando",
                state = "FL"
            };
            servicesContext.SigningServices.Add(signingService);
            signingService = new Models.SigningServices
            {
                Id = 4,
                name = "A Different Signing Service",
                email = "different@gmail.com",
                address = "456 Willow Way",
                city = "Tampa",
                state = "FL"
            };
            servicesContext.SigningServices.Add(signingService);
            servicesContext.SaveChanges();
                
        }
    }
}
