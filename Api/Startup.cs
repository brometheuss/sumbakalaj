using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Commands;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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


            //email sender
            /*var section = Configuration.GetSection("Email");
            var sender = new EmailSender(Int32.Parse(section["port"]), section["from"], section["pass"], section["host"]);
            services.AddSingleton<IEmailSender>(sender);*/
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
        }
    }
}
