using FluentValidation;
using FranksBar.Api.Validators;
using FranksBar.DataAccess;
using FranksBar.DataAccess.Setup;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddValidatorsFromAssemblyContaining<CreateBeerCommandValidator>();
        builder.Services.AddFranksBarShared();
        builder.Services.AddFranksBarDataAccess();
        builder.Services.AddEntityFrameworkSqlite();

        // this would be in other setup but added to get swagger showing
        builder.Services.AddDbContext<DBarContext>(
            options => options.UseSqlite("Data Source=:memory:"));

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
