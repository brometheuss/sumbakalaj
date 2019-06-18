using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Api.Helpers;
using BusinessLogic.Commands;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<EfContext>();
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetManufacturerCommand, EfGetManufacturerCommand>();
            services.AddTransient<IGetManufacturersCommand, EfGetManufacturersCommand>();
            services.AddTransient<IAddManufacturerCommand, EfAddManufacturerCommand>();
            services.AddTransient<IEditManufacturerCommand, EfEditManufacturerCommand>();
            services.AddTransient<IDeleteManufacturerCommand, EfDeleteManufacturerCommand>();
            services.AddTransient<IGetModelCommand, EfGetModelCommand>();
            services.AddTransient<IGetModelsCommand, EfGetModelsCommand>();
            services.AddTransient<IAddModelCommand, EfAddModelCommand>();
            services.AddTransient<IEditModelCommand, EfEditModelCommand>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
            services.AddTransient<IGetPostCommand, EfGetPostCommand>();
            services.AddTransient<IGetPostsCommand, EfGetPostsCommand>();
            services.AddTransient<IAddPostCommand, EfAddPostCommand>();
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IGetFeatureCommand, EfGetFeatureCommand>();
            services.AddTransient<IGetFeaturesCommand, EfGetFeaturesCommand>();
            services.AddTransient<IAddFeatureCommand, EfAddFeatureCommand>();
            services.AddTransient<IEditFeatureCommand, EfEditFeatureCommand>();
            services.AddTransient<IDeleteFeatureCommand, EfDeleteFeatureCommand>();
            services.AddTransient<IGetPostFeaturesCommand, EfGetPostFeaturesCommand>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //encryption
            var key = Configuration.GetSection("Encryption")["key"];
            var enc = new Encryption(key);

            services.AddSingleton(enc);

            services.AddTransient<LoggedUser>(s =>
            {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decryptedString = encryption.DecryptString(value);
                    decryptedString = decryptedString.Replace("\f", "");
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decryptedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser {
                        IsLogged = false
                    };
                }
            });


            //email sender
            var section = Configuration.GetSection("Email");
            var sender = new EmailSender(Int32.Parse(section["port"]), section["fromaddress"], section["password"], section["host"]);
            services.AddSingleton<IEmailSender>(sender);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Sumbakalaj API", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
