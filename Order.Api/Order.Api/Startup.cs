using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
using Pokezon.Data.Repository;
using Pokezon.Domain;
using Pokezon.OrderApi.Data.Database;
using Pokezon.OrderApi.Data.Repository;
using Pokezon.OrderApi.Domain;
using Pokezon.OrderApi.Services;
using Pokezon.OrderApi.Services.Command;
using Pokezon.OrderApi.Services.Services;
using Pokezon.Services.Query;
using Popkezon.Data.Repository;

namespace Pokezon.OrderApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokezon.Api", Version = "v1" });
            });

            bool.TryParse(Configuration["BaseServiceSettings:UseInMemoryDatabase"], out var useInMemory);

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            if (!useInMemory)
            {
                services.AddDbContext<OrderContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("OrderContext"));
                    options.EnableSensitiveDataLogging(true);
                });
            }
            else
            {
                services.AddDbContext<OrderContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.EnableSensitiveDataLogging(true);
                });
            }

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddTransient<IPokemonServices, PokemonServices>();
            services.AddTransient<IPokemonRepository, PokemonRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IRequestHandler<CreatePaymentCommand, Order>, CreatePaymentCommandHandler>();
            services.AddTransient<IRequestHandler<CreatePokemonCommand, Pokemon>, CreatePokemonCommandHandler>();
            services.AddTransient<IRequestHandler<GetOrdersQuery, List<Order>>, GetOrdersQueryHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.Api v1"));
            }

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
