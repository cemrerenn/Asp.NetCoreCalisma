using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

namespace AgriculturePresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IServiceService,ServiceManager>();
            builder.Services.AddScoped<IServiceDal, EfServiceDal>();
            builder.Services.AddDbContext<AgricultureContext>();
            builder.Services.AddScoped<ITeamService, TeamManager>();
            builder.Services.AddScoped<ITeamDal, EfTeamDal>();
            builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
            builder.Services.AddScoped<IAnnouoncementDal, EfAnnouncementDal>();
            builder.Services.AddScoped<IImageService, ImageManager>();
            builder.Services.AddScoped<IImageDal, EfImageDal>();
            builder.Services.AddScoped<IAdressService, AdressManager>();
            builder.Services.AddScoped<IAdressDal, EfAdressDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, EfContactDal>();
			builder.Services.AddScoped<ISocialMedyaService, SocialMedyaManager>();
			builder.Services.AddScoped<ISocialMedyaDal, EfSocialMedyaDal>();
			builder.Services.AddScoped<IAboutService, AboutManager>();
			builder.Services.AddScoped<IAboutDal, EfAboutDal>();
			builder.Services.AddScoped<IAdminService, AdminManager>();
			builder.Services.AddScoped<IAdminDal, EfAdminDal>();

            builder.Services.AddDbContext<AgricultureContext>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddMvc();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => 
                { 
                    x.LoginPath = "/Login/Index/";
                });


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();//olmazsa sayfalar uyarý veriyor.
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}