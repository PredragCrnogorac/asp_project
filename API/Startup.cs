using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.RoleCommands;
using Application.Commands.ExtraAddonsCommands;
using Application.Commands.UserCommands;
using Application.Commands.VehicleCommands;
using EFCommands.ExtraAddonCommands;
using EFCommands.ExtraAddonsCommands;
using EFCommands.RoleCommands;
using EFCommands.UserCommands;
using EFCommands.VehicleCommands;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EFCommands.BrandCommands;
using Application.Commands.BrandCommands;
using EFCommands.VehicleTypeCommands;
using Application.Commands.VehicleTypeCommands;
using EFCommands.LocationCommands;
using Application.Commands.LocationCommands;
using Application.Commands.RentCommands;
using EFCommands.RentCommands;
using Application.Commands.StatusCommands;
using EFCommands.StatusCommands;
using Application.Commands.CustomerCommands;
using EFCommands.CustomerCommands;
using Application.Interfaces;
using API.Email;
using Microsoft.AspNetCore.Http;
using API.Helpers;
using Application;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AIContext>();
            //dependency injection for roles
            services.AddTransient<IGetRoleCommand, EFGetRolesCommand>();
            services.AddTransient<IGetSingleRoleCommand, EFGetSingleRoleCommand>();
            services.AddTransient<IInsertRoleCommand, EFInsertRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EFUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            //dependency injection for users
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            services.AddTransient<IGetSingleUserCommand, EFGetSingleUserCommand>();
            services.AddTransient<IInsertUserCommand, EFInsertUserCommand>();
            services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            //dependency injection for vehicles
            services.AddTransient<IInsertVehicleCommand, EFInsertVehicleCommand>();
            services.AddTransient<IGetVehiclesCommand, EFGetVehiclesCommand>();
            services.AddTransient<IGetSIngleVehicleCommand, EFGetSingleVehicleCommand>();
            services.AddTransient<IDeleteVehicleCommand, EFDeleteVehicleCommand>();
            services.AddTransient<IUpdateVehicleCommand, EFUpdateVehicleCommand>();
            //dependency injection for extra addons
            services.AddTransient<IGetExtraAddonsCommand, EFGetExtraAddonsCommand>();
            services.AddTransient<IInsertExtraAddonCommand, EFInsertExtraAddonCommand>();
            services.AddTransient<IGetSingleExtraAddonCommand, EFGetSingleExtraAddonCommand>();
            services.AddTransient<IUpdateExtraAddonCommand, EFUpdateExtraAddonCommand>();
            services.AddTransient<IDeleteExtraAddonCommand, EFDeleteExtraAddonCommand>();
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
			//dependency injection for location
            services.AddTransient<IGetLocationsCommand, EFGetLocationsCommand>();
            services.AddTransient<IGetSingleLocationCommand, EFGetSIngleLocationCommand>();
            services.AddTransient<IInsertLocationCommand, EFInsertLocationCommand>();
            services.AddTransient<IDeleteLocationCommand, EFDeleteTransmissionCommand>();
            services.AddTransient<IUpdateLocationCommand, EFUpdateLocationCommand>();
			//dependency injection for rents
			services.AddTransient<IGetRentsCommand, EFGetRentsCommand>();
			services.AddTransient<IGetSIngleRentCommand, EFGetSingleRentCommand>();
			services.AddTransient<IInsertRentCommand, EFInsertRentCommand>();
			services.AddTransient<IDeleteRentCommand, EFDeleteRentCommand>();
			services.AddTransient<IUpdateRentCommand, EFUpdateRentCommand>();
			services.AddTransient<IStartRentCommand, EFStartRentCommand>();
			services.AddTransient<IFinishRentCommand, EFFinishRentCommand>();
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
			//loggin

			services.AddTransient<IGetLoggedUser, EFGetLoggedUserCommand>();
			//dependency for email
			var section = Configuration.GetSection("Email");
			var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["from"], section["password"]);
			services.AddSingleton<IEmailSender>(sender);
			//Login
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

			var key = Configuration.GetSection("Encryption")["key"];

			var enc = new Encryption(key);
			services.AddSingleton(enc);


			services.AddTransient(s =>
			{
				var http = s.GetRequiredService<IHttpContextAccessor>();
				var value = http.HttpContext.Request.Headers["Authorization"].ToString();
				var encryption = s.GetRequiredService<Encryption>();

				try
				{
					var decodedString = encryption.DecryptString(value);
					decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
					var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
					user.IsLogged = true;
					return user;
				}
				catch (Exception)
				{
					return new LoggedUser
					{
						IsLogged = false
					};
				}
			});
			//Swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "AI Rent a Car API", Version = "V1" });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "AI API V1");
			});
		}
    }
}
