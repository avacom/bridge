using Bridge.Configuration;
using Bridge.Interfaces;
using Bridge.Processor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bridge.Service
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
            var mvcBuilder = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var assemblies = Configuration.GetSection("ControllerAssemblies")?.Get<List<string>>()
                .Distinct()
                .Select(a => Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\{a}"))
                .ToList();

            if (assemblies != null)
            {
                foreach (var assembly in assemblies)
                {
                    mvcBuilder = mvcBuilder.AddApplicationPart(assembly);
                }
            }

            mvcBuilder = mvcBuilder.AddControllersAsServices();

            ProcessorCollection processorCollection = new ProcessorCollection(services.BuildServiceProvider());
            processorCollection.Initialize(Configuration);

            services.AddSingleton<IProcessorCollection>(processorCollection);

            var svc = services.BuildServiceProvider().GetServices<IProcessorCollection>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
