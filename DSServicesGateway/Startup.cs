using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using DSServicesGateway.Authentication;
using DSServicesGateway.Extensions;
using DSServicesGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace DSServicesGateway
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
            services.AddOcelot();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = SSOAuthHandler.AuthenticationScheme;
                options.DefaultChallengeScheme = SSOAuthHandler.AuthenticationScheme;
            }).AddSSOAuth(options => {});
            services.AddSingleton<ISSOAuthenticationService, SSOAuthenticationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            var configuration = new OcelotPipelineConfiguration
            {
                PreAuthorisationMiddleware = async (context, next) =>
                {
                    var stopwatch = Stopwatch.StartNew();
                    await next.Invoke();
                    context.DownstreamResponse.Headers.Add(new Header("Timing", new[] { stopwatch.ElapsedMilliseconds.ToString() }));
                },
            };

            app.UseOcelot(configuration).Wait();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
