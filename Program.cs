using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repo.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


                     builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AquaCulture API",
                    Description = "AquaCulture  REST-API by Asp.net Core C#",
                    TermsOfService = new Uri("https://softnet.co.tz"),
                    Contact = new OpenApiContact
                    {
                        Name = "Abdulwahid S Masoud",
                        Email = "amasoud@softnet.co.tz",
                        Url = new Uri("https://softnet.co.tz"),
                    },

                });

});

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

    app.UseSwagger( c=>{
                c.SerializeAsV2 = true;
            });

              app.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
