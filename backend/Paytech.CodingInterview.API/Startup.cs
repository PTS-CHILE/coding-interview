using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paytech.CodingInterview.API.Configuration;
using Paytech.CodingInterview.API.Data;
using Paytech.CodingInterview.API.Helpers;
using Paytech.CodingInterview.API.Services;
using Paytech.CodingInterview.API.Services.Interfaces;
using System;

namespace Paytech.CodingInterview.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(NotificationHandlerFilterAttribute));
            });

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .UseFilter(new AutomaticRetryAttribute() { Attempts = 0 })
                .UseSqlServerStorage(Configuration.GetConnectionString("CodingInterviewContext"), new SqlServerStorageOptions
                {
                    SchemaName = "Jobs"
                }));

            // Configuration
            services.AddSingleton(Configuration.GetSection("AppSettings").Get<AppSettings>());

            // Data
            services.AddDbContext<CodingInterviewContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CodingInterviewContext"), sqlOptions => sqlOptions.EnableRetryOnFailure());
            });
            //services.AddSingleton<IMongoRepository, MongoRepository>(p => new MongoRepository(Configuration.GetConnectionString("MongoDb")));

            // Services            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExternalProductService, ExternalProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors(config =>
            {
                config
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Hangfire configuration
            GlobalConfiguration
                .Configuration
                .UseActivator(new HangfireActivator(serviceProvider));

            app.UseHangfireServer();
            app.UseHangfireDashboard("/jobs");
            RecurringJob.AddOrUpdate<IExternalProductService>("CreateUpdateProductsJob", x => x.CreateUpdateProductsAsync(), "0 10 * * *", TimeZoneInfo.Local);            

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
