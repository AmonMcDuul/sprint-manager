using Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SprintManagerDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

////SignalR
//builder.Services.AddSignalR()
//    .AddJsonProtocol(options =>
//    {
//        options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//    }
//);
//builder.Services.AddSingleton<HubConnection>(provider => {
//    var hubUrl = "https://localhost:7299/signalr"; // Replace with your SignalR hub URL
//    return new HubConnectionBuilder()
//        .WithUrl(hubUrl)
//        .Build();
//});
//builder.Services.AddSingleton<ISprintStateManager, SprintStateManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder =>
    {
        // this should be configured on the host. See App service > CORS. Values set here must only be used for localhost.
        builder.AllowAnyMethod().AllowAnyHeader().WithOrigins(
            "http://localhost:4200", "http://localhost:4201")
        .AllowCredentials();
    });
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapHub<SenWHub>("/signalr");

app.Run();
