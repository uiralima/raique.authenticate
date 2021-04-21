using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raique.Authenticate.Common.Config;
using Raique.Authenticate.Common.Contracts;
using Raique.Authenticate.Common.Controllers;
using Raique.Database.SqlServer.Contracts;
using Raique.Microservices.Authenticate.Infra.SqlServer;
using Raique.Microservices.Authenticate.Protocols;

namespace AspNetCore.Api
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

            services.AddSingleton<IDatabaseConfig, SqlServerConnection>();
            services.AddSingleton<ITokenRepository, TokenRepositoryImpl>();
            services.AddSingleton<IUserRepository, UserRepositoryImpl>();
            services.AddSingleton<IAppRepository, AppRepossitoryImpl>();
            services.AddScoped<ICreateAppControler, CreateAppControllerImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
