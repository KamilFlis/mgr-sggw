using JwtAuthApp.Configuration;
using JwtAuthApp.Domain.Exceptions;
using JwtAuthApp.Persitence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddServices(builder.Configuration);
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>();



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
