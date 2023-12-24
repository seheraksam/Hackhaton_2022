using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Hackathon.DAL.Contexts;
using Hackathon.Entities.Concrete;
using Hackathon.DAL.Interface;
using Hackathon.Entities.Interface;
using Hackathon.DAL.Concrete.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json.Serialization;
using Hackathon.DAL.Concrete.Seeders;
using System.Drawing.Drawing2D;
using Hackathon.BLL.Service;
using Hackathon.BLL.Manager;

namespace Hackathon.WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("RemoteConnection") ?? throw new InvalidOperationException("Connection string not found.");


            builder.WebHost.ConfigureAppConfiguration(conf =>
            {
                conf.AddJsonFile("materialTypes.json",false);
            });
            builder.Services.AddDbContext<HackathonDbContext>(options =>
                options.UseSqlServer(connectionString),ServiceLifetime.Transient,ServiceLifetime.Transient);

                                                builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<HackathonDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddTransient<MaterialTypeSeeder>();
            builder.Services.AddTransient<UserRepository>();
            builder.Services.AddTransient<SessionRepository>();
            builder.Services.AddTransient<ITransactionService,TransactionManager>();
            builder.Services.AddTransient<ISessionService, SessionManager>();
            builder.Services.AddTransient<IRecyclerService,RecyclerManager>();
            var app = builder.Build();
            var materialTypes = app.Configuration.GetSection("MaterialTypes").Get<IEnumerable<MaterialType>>();
            var seeder = app.Services.GetRequiredService<MaterialTypeSeeder>();
            seeder.DbContext.Database.Migrate();
            seeder.Seed(materialTypes);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}