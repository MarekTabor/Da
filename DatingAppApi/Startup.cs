using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingAppApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DatingAppApi
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
			services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			services.AddCors();
			services.AddScoped<IAuthRepository, AuthRepository>();
<<<<<<< HEAD:DatingAppApi/Startup.cs
			services.AddAuthorization();
			services.AddMvc();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
						.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
=======
>>>>>>> 29b99aadf1518e16950440e3fb4af042d59ecf1e:TwojaPara/DatingApp/Startup.cs
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
				app.UseExceptionHandler(builder =>
				{
					builder.Run(async context =>
					{
						context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

<<<<<<< HEAD:DatingAppApi/Startup.cs
						var error = context.Features.Get<IExceptionHandlerFeature>();
						if (error != null)
						{
							context.Response.AddApplicationError(error.Error.Message);
							await context.Response.WriteAsync(error.Error.Message);
						}
=======
			app.UseHttpsRedirection();
>>>>>>> 29b99aadf1518e16950440e3fb4af042d59ecf1e:TwojaPara/DatingApp/Startup.cs

					});
				});
			}
			app.UseRouting();

			app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}