using ChatMigration.Interfaces;
using ChatMigration.Services;
using Microsoft.Win32;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure HttpClient
builder.Services.AddHttpClient("SlackClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Slack:ApiBaseUrl"]);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["Slack:ApiToken"]}");
});

builder.Services.AddHttpClient("TeamsClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Teams:ApiBaseUrl"]);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["Teams:ApiToken"]}");
});

// Register application services
builder.Services.AddTransient<ISlackService, SlackService>();
builder.Services.AddTransient<ITeamsService, TeamsService>();
builder.Services.AddTransient<IChatHistoryMigrationService, ChatHistoryMigrationService>();

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
