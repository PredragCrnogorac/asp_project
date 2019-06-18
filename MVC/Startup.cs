using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.BrandCommands;
using Application.Commands.CustomerCommands;
using Application.Commands.ExtraAddonsCommands;
using Application.Commands.LocationCommands;
using Application.Commands.RentCommands;
using Application.Commands.RoleCommands;
using Application.Commands.StatusCommands;
using Application.Commands.UserCommands;
using Application.Commands.VehicleCommands;
using Application.Commands.VehicleTypeCommands;
using Application.Interfaces;
using EFCommands.BrandCommands;
using EFCommands.CustomerCommands;
using EFCommands.ExtraAddonCommands;
using EFCommands.ExtraAddonsCommands;
using EFCommands.LocationCommands;
using EFCommands.RentCommands;
using EFCommands.RoleCommands;
using EFCommands.StatusCommands;
using EFCommands.UserCommands;
using EFCommands.VehicleCommands;
using EFCommands.VehicleTypeCommands;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.Email;

namespace MVC
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
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddDbContext<AIContext>();
			services.AddTransient<IGetBrandsCommand, EFGetBrandsCommand>();
			services.AddTransient<IGetSingleBrandCommand, EFGetSingleBrandCommand>();
			services.AddTransient<IInsertBrandCommand, EFInsertBrandCommand>();
			services.AddTransient<IUpdateBrandCommand, EFUpdateBrandCommand>();
			//dependency injection for users
			services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
			services.AddTransient<IGetSingleUserCommand, EFGetSingleUserCommand>();
			services.AddTransient<IInsertUserCommand, EFInsertUserCommand>();
			services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
			services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
			//dependency injection for rents
			services.AddTransient<IGetRentsCommand, EFGetRentsCommand>();
			services.AddTransient<IGetSIngleRentCommand, EFGetSingleRentCommand>();
			services.AddTransient<IInsertRentCommand, EFInsertRentCommand>();
			services.AddTransient<IDeleteRentCommand, EFDeleteRentCommand>();
			services.AddTransient<IUpdateRentCommand, EFUpdateRentCommand>();
			services.AddTransient<IStartRentCommand, EFStartRentCommand>();
			//dependency injection for extra addons
			services.AddTransient<IGetExtraAddonsCommand, EFGetExtraAddonsCommand>();
			services.AddTransient<IInsertExtraAddonCommand, EFInsertExtraAddonCommand>();
			services.AddTransient<IGetSingleExtraAddonCommand, EFGetSingleExtraAddonCommand>();
			services.AddTransient<IUpdateExtraAddonCommand, EFUpdateExtraAddonCommand>();
			services.AddTransient<IDeleteExtraAddonCommand, EFDeleteExtraAddonCommand>();
			//dependency injection for location
			services.AddTransient<IGetLocationsCommand, EFGetLocationsCommand>();
			services.AddTransient<IGetSingleLocationCommand, EFGetSIngleLocationCommand>();
			services.AddTransient<IInsertLocationCommand, EFInsertLocationCommand>();
			services.AddTransient<IDeleteLocationCommand, EFDeleteTransmissionCommand>();
			services.AddTransient<IUpdateLocationCommand, EFUpdateLocationCommand>();
			//dependency injection for statuses
			services.AddTransient<IGetStatusesCommand, EFGetStatusesCommand>();
			services.AddTransient<IGetSingleStatusCommand, EFGetSingleStatusCommand>();
			services.AddTransient<IInsertStatusCommand, EFInsertStatusCommand>();
			services.AddTransient<IDeleteStatusCommand, EFDeleteStatusCommand>();
			services.AddTransient<IUpdateStatusCommand, EFUpdateStatusCommand>();
			//dependency injection for customers
			services.AddTransient<IGetCustomersCommand, EFGetCustomersCommand>();
			services.AddTransient<IGetSingleCustomerCommand, EFGetSingleCustomerCommand>();
			services.AddTransient<IInsertCustomerCommand, EFInsertCustomerCommand>();
			services.AddTransient<IUpdateCustomerCommand, EFUpdateCustomerCommand>();
			services.AddTransient<IDeleteCustomerCommand, EFDeleteCustomerCommand>();
			//dependency injection for vehicles
			services.AddTransient<IInsertVehicleCommand, EFInsertVehicleCommand>();
			services.AddTransient<IGetVehiclesCommand, EFGetVehiclesCommand>();
			services.AddTransient<IGetSIngleVehicleCommand, EFGetSingleVehicleCommand>();
			services.AddTransient<IDeleteVehicleCommand, EFDeleteVehicleCommand>();
			services.AddTransient<IUpdateVehicleCommand, EFUpdateVehicleCommand>();
			//dependency injection for brands
			services.AddTransient<IGetBrandsCommand, EFGetBrandsCommand>();
			services.AddTransient<IInsertBrandCommand, EFInsertBrandCommand>();
			services.AddTransient<IGetSingleBrandCommand, EFGetSingleBrandCommand>();
			services.AddTransient<IDeleteBrandCommand, EFDeleteBrandCommand>();
			services.AddTransient<IUpdateBrandCommand, EFUpdateBrandCommand>();
			//dependency injection for vehicle types
			services.AddTransient<IGetVehicleTypesCommand, EFGetVehicleTypesCommand>();
			services.AddTransient<IGetSIngleVehicleTypeCommand, EFGetSIngleVehicleTypeCommand>();
			services.AddTransient<IInsertVehicleTypeCommand, EFInsertVehicleTypeCommand>();
			services.AddTransient<IDeleteVehicleTypeCommand, EFDeleteVehicleTypeCommand>();
			services.AddTransient<IUpdateVehicleTypeCommand, EFUpdateVehicleTypeCommand>();
			//roles
			services.AddTransient<IGetRoleCommand, EFGetRolesCommand>();
			//email sender singleton
			//dependency for email
			var section = Configuration.GetSection("Email");
			var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["from"], section["password"]);
			services.AddSingleton<IEmailSender>(sender);
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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
