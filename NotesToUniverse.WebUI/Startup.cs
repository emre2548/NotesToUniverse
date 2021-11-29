using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NotesToUniverse.Business.Abstract;
using NotesToUniverse.Business.Concrete;
using NotesToUniverse.DataAccess.Abstract;
using NotesToUniverse.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using NotesToUniverse.WebUI.Identity;

namespace NotesToUniverse.WebUI
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
            //services.AddRazorPages();

            #region Identity DB connection setting

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NoteToUniverse;Trusted_Connection=true"));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            #region Identity Login Settings

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                //options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            });
            #endregion

            #region Cookie Settings

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.SameSite = SameSiteMode.Strict; // prevent cross-site attacks

                options.LoginPath = "/Account/Login";  // login page
                options.LogoutPath = "/Account/Logout"; // Logout page
                options.AccessDeniedPath = "/Account/AccessDenied"; // Access Denied page
                options.SlidingExpiration = true;
            });

            #endregion

            services.AddScoped<INoteDal, EfCoreNoteDal>();
            services.AddScoped<INoteService, NoteManager>();

            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Create database
                //using (var context = new DatabaseContext())
                //{
                //    //context.Database.EnsureCreated();
                //    //context.Database.Migrate();
                //}

                // create fake data
                SeedDatabase.Seed();
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
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    "note",
                    "note/{category?}",
                    new { controller = "Note", action = "List" });

                endpoints.MapControllerRoute(
                    "createnote",
                    "admin/createnote",
                    new { controller = "Admin", action = "CreateNote" });
            });

            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait(); // add DB role and admin user

        }
    }
}
