using Microsoft.AspNetCore.Identity;
using YummyFood.API.Extensions;
using YummyFood.Application;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Infrastructure;
using YummyFood.Infrastructure.Persistance;

namespace YummyFood.API
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services, ILoggingBuilder Logging)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            services.AddYummyFoodApplicationDependencyInjection();
            services.AddYummyFoodInfrastructureDependencyInjection(configRoot);

            services.AddIdentity<UserApp, IdentityRole<long>>()
                .AddEntityFrameworkStores<YummyFoodDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<Random>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager =
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();

                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                        roleManager.CreateAsync(new IdentityRole<long>(role)).Wait();
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<UserApp>>();

                string phoneNumber = "+998900246136";
                string password = "Admin01!";

                if (userManager.FindByPhoneNumberAsync(phoneNumber).Result == null)
                {
                    var user = new UserApp()
                    {
                        UserName = "Admin",
                        FullName = "Admin",
                        PhoneNumber = "+998777777777",
                        Password = password,
                        ProfilePhoto = "https://ih1.redbubble.net/image.2955130987.9629/raf,360x360,075,t,fafafa:ca443f4786.jpg",
                        Role = "Admin",
                        Cart = new List<long>(),
                        Favorite = new List<long>(),
                        Birth = DateTimeOffset.UtcNow.ToString(),
                        Gender = "No"
                    };

                    userManager.CreateAsync(user, password).Wait();

                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            app.Run();
        }
    }
}
