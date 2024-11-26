using System.CodeDom;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Components;
using SystemForCoinCollectors.Components.Account;
using SystemForCoinCollectors.Controllers;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();


            // TESTS
            
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            UserController userController = new UserController(context);

            // userController.Delete("0553341f-9094-4e20-84fc-c6c7c3cc6f5d");
            // userController.Delete("94040f79-276c-404e-b374-2e5f6cab7607");
            
            // CreateTest(userController);          // PASSED
            string strId = "2c46061b-21c2-4001-bb78-73cf39d2fa63";

            // GetTest(userController, strId);      // PASSED
            EditTest(userController);
            // DeleteTest(userController, strId);   // PASSED
            
            // END TESTS


            app.Run();
        }

        static void CreateTest(UserController userController)
        {
            var user = new ApplicationUser
            {
                Name = "John",
                Surname = "Doe",
                Address = "Vysokoskolakov 20, 010 08 Zilina",
                UserName = "johndoe123",
                Email = "johndoe@example.com",
                EmailConfirmed = true
            };

            var user2 = new ApplicationUser
            {
                Name = "Sherlock",
                Surname = "Holmes",
                Address = "221B Baker Street",
                UserName = "sherlock",
                Email = "sherlockholmes@example.com",
                EmailConfirmed = true
            };

            userController.Create(user);
            userController.Create(user2);
        }

        static void GetTest(UserController userController, string id)
        {
            var userById = userController.Get(id);
            var user = (ApplicationUser?) userById.Value;

            if (user == null)
            {
                Console.WriteLine("User is null! Something went wrong!");
            }
            else
            {
                Console.WriteLine(user.Name + " " + user.Surname + " " + user.UserName);
            }
        }

        static void EditTest(UserController userController)
        {
            var newUserValues = new ApplicationUser
            {
                Name = "Jack",
                Surname = "Doe",
                Address = "Vysokoskolakov 20, 010 08 Zilina",
                UserName = "jackdoe123",
                Email = "jackdoe@example.com",
                EmailConfirmed = true
            };

            userController.Edit(newUserValues);
        }

        static void DeleteTest(UserController userController, string id)
        {
            userController.Delete(id);
        }

    }
}
