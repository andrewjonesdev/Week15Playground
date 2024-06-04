

using Week15Playground.Data;
using Week15Playground.Data.Interfaces;
using Week15Playground.Models;
using Week15Playground.Models.Interfaces;
using Week15Playground.Services;
using Week15Playground.Services.Interfaces;

namespace Week11Playground
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IOnePieceService, OnePieceService>();
            builder.Services.AddSingleton<IOnePieceData, OnePieceData>();
            builder.Services.AddSingleton<IOnePieceApiSettings, OnePieceApiSettings>();
            builder.Services.Configure<OnePieceApiSettings>(settings => settings.BaseUrl = Environment.GetEnvironmentVariable("BaseUrl", EnvironmentVariableTarget.Process));

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
