using Autofac;
using DI_Autofac_Test.Eventhandler;
using DI_Autofac_Test.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DI_Autofac_Test
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
			services.AddRazorPages();

			services.AddSingleton(typeof(IEventPublisherService), typeof(EventPublisherService));

			// DI for EventHandlers
			Type genericHandlerType = typeof(IEventHandler<>);
			foreach (Type implementationType in genericHandlerType.GetTypesWithGenericInterfacesInAssemblies(AppDomain.CurrentDomain.GetAssemblies()))
			{
				Type interfaceType = implementationType.GetGenericInterfaceType(genericHandlerType);
				services.AddSingleton(interfaceType, implementationType);
			}

		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
				.AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces();

			IContainer container = null;
			builder.Register(c => container).AsSelf();
			builder.RegisterBuildCallback(c => container = c);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
