using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Repositories;

using Dapper.Contrib.Extensions;
using TecNM.Proyecto.Api.DataAccess;
using TecNM.Proyecto.Api.DataAccess.Interfaces;


using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IGameCategoryRepository, InMemoryGameCategoryRepository>();
//builder.Services.AddSingleton<IGameCategoryRepository, GameCategoryRepository>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<IBrandRepository,BrandRepository>();
builder.Services.AddScoped<IGameCategoryRepository,GameCategoryRepository>();
builder.Services.AddScoped<IGameCategoryService,GameCategoryService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IGameService,GameService>();
builder.Services.AddScoped<IGameRepository,GameRepository>();
builder.Services.AddScoped<IOrderDetailsService,OrderDetailsService>();
builder.Services.AddScoped<IOrderDetailsRepository,OrderDetailsRepository>();
builder.Services.AddScoped<IOrderGameService,OrderGameService>();
builder.Services.AddScoped<IOrderGameRepository,OrderGameRepository>();

builder.Services.AddScoped<IDbContext, DbContext>();

SqlMapperExtensions.TableNameMapper = entityType =>{

    var name = entityType.ToString();
    if(name.Contains("TecNM.Proyecto.Core.Entities."))
        name = name.Replace("TecNM.Proyecto.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};





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
