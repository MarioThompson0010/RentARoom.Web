using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentARoom.Web.Services;
using RentARoom.Models;
using Microsoft.AspNetCore.Identity;
using AuthenticationTest.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using AuthenticationTest.Data;
using RentARoom.Web.Pages;

namespace RentARoom.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddHttpClient<IGetClients, GetClients>("myapi", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetConnectionString("LocalHostURI"));
            });
            //hey////////
            services.AddHttpClient<IGetReservations, GetReservations>("myapiRes", c =>
            {
                c.BaseAddress = new Uri("https://localhost:7050/");
            });
            services.AddDbContext<BlazorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnDBConnection")));



			/////////////
//			services.AddDefaultIdentity<IdentityUser>
//	(options =>
//	{
//		options.SignIn.RequireConfirmedAccount = true;
//		options.Password.RequireDigit = false;
//		options.Password.RequiredLength = 6;
//		options.Password.RequireNonAlphanumeric = false;
//		options.Password.RequireUppercase = false;
//		options.Password.RequireLowercase = false;
//	})
//.AddEntityFrameworkStores<AppDbContext>();
			//////////////////////

			//        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
			//.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			//        services.AddIdentity<AuthenticationTestUser, IdentityRole>(options =>
			//        {
			//            options.User.RequireUniqueEmail = false;
			//        })
			//.AddEntityFrameworkStores<AppDbContext>()
			//.AddDefaultTokenProviders();
			services.AddDefaultIdentity<IdentityUser>(options =>
            {

                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;


            }


			).AddEntityFrameworkStores<BlazorContext>();

            services.AddAuthentication("Identity.Application").AddCookie();
            services.AddControllersWithViews();

			//services.ConfigureApplicationCookie(options =>
			//{
			//    // Cookie settings
			//    options.Cookie.HttpOnly = true;
			//    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

			//    options.LoginPath = "/Identity/Account/Login";
			//    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
			//    options.SlidingExpiration = true;
			//});
			
			//services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
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
            //!!!!
            app.UseAuthentication();

            app.UseRouting();
            
            //!!!!
            app.UseAuthorization();

			//IHostBuilder hostBuilder = app.ConfigureServices((context, services) => {
			//	services.AddDbContext<AppDbContext>(options =>
			//		options.UseSqlServer(
			//			context.Configuration.GetConnectionString("EmployeeManagementWebContextConnection")));

			//	services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
			//		.AddEntityFrameworkStores<EmployeeManagementWebContext>();
			//});


			app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
