using GPRSClient.Options;
using GPRSClient.Services.AccomodationService;
using GPRSClient.Services.FlightsService;
using GPRSClient.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add options
builder.Services.Configure<GRPCOptions>(builder.Configuration.GetSection("GRPCOptions"));

// Add services to the container.
builder.Services.AddScoped<IFlightsService, MockFlightsService>();
builder.Services.AddTransient<IAccomodationService, GRPCAccomodationService>();

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
