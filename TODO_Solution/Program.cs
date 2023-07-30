
using MongoDB.Bson;
using TODO_Solution.Model;
using TODO_Solution.Repository;
using TODO_Solution.Services;

namespace TODO_Solution
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<TodoDataBaseSettings>(builder.Configuration.GetSection("TODOStoreDatabase"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register TodoDataBaseSettings
           
            builder.Services.AddScoped<IDatabaseSettings, TodoDataBaseSettings>();

            builder.Services.AddScoped<ITodoDataStorage, InMemoryTodoDataStorage>();

            builder.Services.AddScoped<ITodoService, TodoService>();

            builder.Services.AddControllers();
            var app = builder.Build();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });

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