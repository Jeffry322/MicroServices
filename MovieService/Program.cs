using Microsoft.EntityFrameworkCore;
using MovieService.Abstractions;
using MovieService.Data;
using MovieService.Data.Repository;
using MovieService.Data.SeedDb;
using MovieService.SyncDataServices.Http;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ServiceDbContext>(opt => opt.UseInMemoryDatabase("InMemory"));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<IActorsDataClient, HttpActorDataClient>();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ServiceDbContext>();

    await DbSeed.SeedAsync(context, app.Logger);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
