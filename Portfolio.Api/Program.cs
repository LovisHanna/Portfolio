using MongoDB.Driver;
using Portfolio.Api;
using Portfolio.Api.DTOs;
using Portfolio.RepositoryPattern;
using Portfolio.RepositoryPattern.InMemory;
using Portfolio.RepositoryPattern.MongoDB;
using Portfolio.RepositoryPattern.Shared;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IRepository<Book>, InMemoryRepository<Book>>();
builder.Services.AddSingleton<IRepository<Book>, MongoRepository<Book>>();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString")));

//Adding handlers through medaitR
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpClient<IClient, ArtDB>();

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
