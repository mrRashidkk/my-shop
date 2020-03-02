using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;
using Stripe;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using FluentValidation;
using MyShop.Application.Cart;
using MyShop.UI.ValidationContexts;

namespace MyShop.UI
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
            services.AddHttpContextAccessor();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDBContext>();

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/Accounts/Login";
            });

            services.AddAuthorization(options => 
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
                //options.AddPolicy("Manager", policy => policy.RequireClaim("Role", "Manager"));
                options.AddPolicy("Manager", policy => 
                    policy.RequireAssertion(context => 
                        context.User.HasClaim("Role", "Manager") || context.User.HasClaim("Role", "Admin")));
            });

            services
                .AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AuthorizePage("/Admin/ConfigureUsers", "Admin");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(Startup).Assembly));

            services.AddSession(options => 
            {
                options.Cookie.Name = "Cart";
                options.Cookie.MaxAge = TimeSpan.FromMinutes(20);
            });            

            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            var stripeService = new PaymentIntentService();
            var stripeOptions = new PaymentIntentCreateOptions
            {
                Amount = 1099,
                Currency = "usd",
            };
            stripeService.Create(stripeOptions);

            services.AddApplicationServices();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
