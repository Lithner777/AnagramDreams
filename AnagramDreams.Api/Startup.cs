using AnagramDreams.DataAccess;
using AnagramDreams.DataAccess.Services;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Linq;

namespace AnagramDreams.Api
{
    public class Startup
    {
        private readonly Serilog.ILogger logger = Log.Logger.ForContext<Startup>();

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            Configuration = config;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.Information("AnagramDreams.Api starting...");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetSection("AzureAd")["Authority"];
                    options.Audience = Configuration.GetSection("AzureAd")["ClientId"];
                });

            SetupDb(services);

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IWordService, WordService>(); // Basic DI

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnagramDreams.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetupDb(IServiceCollection services)
        {
            var connectionString = string.Empty;
            var configurationBuilder = new ConfigurationBuilder();

            if (Environment.IsDevelopment())
            {
                logger.Information("Environment is {Environment}, using Azure Db.", Environment.EnvironmentName);
                configurationBuilder.AddAzureKeyVault(
                    new Uri("https://anagramdreamskeyvault.vault.azure.net/"),
                    new DefaultAzureCredential()); // key vault setup

                var configuration = configurationBuilder.Build();
                connectionString = configuration.GetChildren().First(c => c.Key == "AnagramDreamsDbConnectionString").Value;
            }
            else
            {
                connectionString = Configuration.GetConnectionString("AnagramDreamsDbConnectionString"); // appsetting for local env
            }

            services.AddDbContext<AnagramDreamsDbContext>(options =>
            options.UseSqlServer(connectionString));
        }
    }
}
