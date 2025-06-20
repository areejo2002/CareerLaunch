using CareerLaunchpad.Interfaces;
using CareerLaunchpad.Interfaces.CareerLaunchpad.Services;
using CareerLaunchpad.Models;
using CareerLaunchpad.Repositories;
using CareerLaunchpad.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using QuestPDF.Infrastructure;

namespace CareerLaunchpad
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //  ›⁄Ì·  —ŒÌ’ QuestPDF «·„Ã«‰Ì (Community)
            QuestPDF.Settings.License = LicenseType.Community;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                }));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Configure Identity with Roles support
            builder.Services.AddDefaultIdentity<Person>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add repositories & services
            builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
            builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            builder.Services.AddSingleton<IAIResume, AIResume>();
            builder.Services.AddSingleton<IAIPortfolio, AIPortfolio>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IContactRequestsRepository, ContactRequestsRepository>();

            // Add Semantic Kernel to DI
            var openAiKey = builder.Configuration["OpenAI:Key"];
            builder.Services.AddSingleton<Kernel>(sp =>
            {
                var kernelBuilder = Kernel.CreateBuilder();
                kernelBuilder.AddOpenAIChatCompletion("gpt-4", openAiKey);
                return kernelBuilder.Build();
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // óóó Seed default roles & admin user óóó
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<Person>>();

                // ≈‰‘«¡ «·√œÊ«—
                string[] roles = { "User", "Admin" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

                // ≈⁄œ«œ Õ”«» «·√œ„‰
                var adminEmail = "arreej219@gmail.com";  // €Ì¯—Ì ≈·Ï «·≈Ì„Ì· «·–Ì  —ÌœÌÂ
                var adminPassword = "203#Aa521";     // €Ì¯—Ì ≈·Ï «·»«”Ê—œ «·–Ì  —ÌœÌÂ
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    adminUser = new Person
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true,
                        FirstName = "System",
                        LastName = "Admin"
                    };
                    var result = await userManager.CreateAsync(adminUser, adminPassword);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create admin user: " +
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

                // —»ÿ «·„” Œœ„ »œÊ— Admin
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}