using Application.Extensions;
using CrossCuttingConcerns.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddInfrastructureRegistration();
builder.Services.AddAuthenticationExtension(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseCors(opt =>
//                opt.WithOrigins("http://localhost:4200", "http://localhost:5278")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod()
//                   .AllowCredentials());
app.MapControllers();

app.Run();
