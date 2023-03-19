using EventAPI.Services;
using EventAPI.Services.Interfaces;
using EventAPI.Validators;
using Microsoft.OpenApi.Models;
using FluentValidation;
using System.Reflection;
using EventAPI.Features.Event;
using EventAPI.Exception_Filtres;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                          });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Events API",
        Description = "ASP.NET Core Web API для управления событиями",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<ISpaceService, SpaceService>();
builder.Services.AddSingleton<IEventDatabaseService, EventDatabaseService>();
builder.Services.AddScoped<IValidator<IEvent>, EventValidator>();
builder.Services.AddMvc(o => o.Filters.Add(new ScExeptionFilter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
