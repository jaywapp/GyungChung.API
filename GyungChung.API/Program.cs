
using GyungChung.API.Models;
using GyungChung.API.Services;
using MongoDB.Driver;

namespace GyungChung.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MongoDB 설정 불러오기
            var mongoSettings = builder.Configuration.GetSection("MongoDb");
            var connectionString = mongoSettings["ConnectionString"];
            var databaseName = mongoSettings["DatabaseName"];

            // MongoClient 등록
            builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));

            // Database 등록
            builder.Services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(databaseName);
            });

            // Generic MongoService 등록
            builder.Services.AddScoped<MongoService<Member>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new MongoService<Member>(db, "Members");
            });

            builder.Services.AddScoped<MongoService<Location>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new MongoService<Location>(db, "Locations");
            });

            builder.Services.AddScoped<MongoService<Schedule>>(sp =>
            {
                var db = sp.GetRequiredService<IMongoDatabase>();
                return new MongoService<Schedule>(db, "Schedules");
            });


            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
