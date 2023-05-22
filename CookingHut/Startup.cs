using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CookingHut.Infra.CrossCutting.DependencyContainer;
using System.Linq;
using System.IO;
using System;

namespace CookingHut
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiConfigurations(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "CookingHut",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "CookingHut",
                        Version = "1.0"
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Map("/uploadImage", MapImageUploadMiddleware);

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("swagger/CookingHut/swagger.json", "Cooking Hut");
                    options.RoutePrefix = "";
                });
        }

        private void MapImageUploadMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var uploadedFile = context.Request.Form.Files.First();
                var fileExtension = uploadedFile.FileName.Split('.').Last();
                var filename = $"{DateTime.Now.Ticks.ToString()}.{fileExtension}";
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "RecipeImages", filename);

                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                await context.Response.WriteAsJsonAsync(filename);
            });
        }
    }
}