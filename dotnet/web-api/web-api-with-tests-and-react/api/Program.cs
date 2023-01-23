using api;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var x = new TestStructure(1, "Test", new WeatherForecast { });

var f = default(WeatherForecast);
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(f));
var a = default(TestStructure);
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(a));


int x = 0;

float t = (float)x;





app.Run();


