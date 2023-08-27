using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebMvcTelefonRehberi.BLManager.Abstract;
using WebMvcTelefonRehberi.BLManager.Concrete;
using WebMvcTelefonRehberi.Domain;

namespace WebMvcTelefonRehberi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            int a = 5;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BaseeDbContext>(options => options.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=TelRehber;User Id=postgres;Password=123;"));


            // AutoMapper Entegrasyonu
            services.AddAutoMapper(typeof(Startup));


            // DAL Katmanindaki Servislerin Register Edilmesi
            //services.AddScoped<IBransRepository,BransRepository>();
            // services.AddScoped<IKullanicilarRepository, KullanicilarRepsitory>();
            // services.AddScoped<IOgrencilerRepository, OgrencilerRepository>();
            // services.AddScoped<IOgretmenlerRepository, OgretmenlerRepository>();
            // services.AddScoped<IPlanRepository, PlanRepository>();
            // services.AddScoped<ISinifRepository, SinifRepository>();
            // services.AddScoped<IYoklamaRepository, YoklamaRepository>();


            //Manager siniflarinin register edilmesi 

            services.AddScoped<IKisiManager, KisiManager>();


            #region Cookie Base Authentication Ayarlari
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Kullanici/Giris"; //Giris Sayfasi
                    x.LogoutPath = "/Kullanici/Cikis"; // Cikis 
                    x.AccessDeniedPath = "/Kullanici/YetkiHatasi";
                    x.Cookie.HttpOnly = true;
                    x.Cookie.Name = "BilgeAdam";
                    x.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    x.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Cookie'nin ömrünü belirler.
                });
            #endregion




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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
