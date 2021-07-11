using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CustomerApi.Data.Repository;
using CustomerApi.Services.Query;
using MediatR;
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
using Pokezon.CustomerApi.Data.Database;
using Pokezon.CustomerApi.Services.Command;
using Pokezon.CustomerApi.Services.Services;
using Pokezon.CustomerAPi.Services.Command;
using Pokezon.CustomerAPi.Services.Services;
using Pokezon.Data.Repository;
using Pokezon.Domain.Entities;
using Pokezon.Services.Query;

namespace Pokezon.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
            }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.Api", Version = "v1" });
            });

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 443;
            });

            bool.TryParse(Configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);

            if (!useInMemory)
            {
                services.AddDbContext<CustomerContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("CustomerContext"));
                });
            }
            else
            {
                services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            }

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IRequestHandler<GetCustomersQuery, List<Customer>>, GetCustomersQueryHandler>();
            services.AddTransient<IRequestHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdQueryHanlder>();
            services.AddTransient<IRequestHandler<UpdateCustomerCommand, Customer>, UpdateCustomerCommandHandler>();

            services.AddTransient<IUpdateCustomerServices, UpdateCustomerServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
