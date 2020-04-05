using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreCMS
{
    public class Startup
    {

        //COMMENT-Confg.
        public IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //COMMENT-DbContext
            //services.AddDbContext<CoreCMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //COMMENT-Dapper Connections
            services.AddOptions();
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));

            //COMMENT-RazorPages Services
            services.AddRazorPages();

            //COMMENT-Disable iis auth
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            //COMMENT-Using static files
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //COMMENT-Endpoints to Razor Pages
                endpoints.MapRazorPages();
            });
        }
    }
}
