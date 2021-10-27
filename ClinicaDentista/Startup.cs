using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ClinicaDentista.Extensions;
using Data.Context;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace ClinicaDentista
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
            services.AddInjections();
            services.AddDbContext<ClinicaContext>();

            services.AddOData();
            
            services.AddControllers()
                .AddNewtonsoftJson(opt =>{
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.UseCamelCasing(true);
            });
            
            services.AddJwt(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicaDentista", Version = "v1" });
            });
            
            services.AddMvc(op => //Para funcionar o OData e Swagger juntos
            {
                foreach (var formatter in op.OutputFormatters.OfType<ODataOutputFormatter>().Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.mock-odata"));
                }

                foreach (var formatter in op.InputFormatters.OfType<ODataInputFormatter>().Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicaDentista v1"));
            }
            UpdateDatabase(app);
            
            app.UseHttpsRedirection();

            app.UseRouting();   
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.Select().Filter().OrderBy().Count().MaxTop(null);
                endpoints.EnableDependencyInjection();
                endpoints.MapControllers();
            });
        }
        
        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ClinicaContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
