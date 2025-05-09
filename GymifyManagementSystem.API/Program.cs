
using GymifyManagementSystem.BLL.Managers;
using GymifyManagementSystem.DAL.Database;
using GymifyManagementSystem.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace GymifyManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<GymifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            builder.Services.AddScoped<IAdminManager, AdminManager>();
            builder.Services.AddScoped<IAdminsRepository, AdminsRepository>();

            builder.Services.AddScoped<IArticleManager, ArticleManager>();
            builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();

            builder.Services.AddScoped<INutritionistManager, NutritionistManager>();
            builder.Services.AddScoped<INutritionistRepository,NutritionistRepository>();

            builder.Services.AddScoped<IOrderManager, OrderManager>();
            builder.Services.AddScoped<IOrderRepository,OrderRepository>();

            builder.Services.AddScoped<IProductManager, Productmanager>();
            builder.Services.AddScoped<IProductsRepository,ProductsRepository>();

            builder.Services.AddScoped<ITrainerManager, TrainerManager>();
            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
