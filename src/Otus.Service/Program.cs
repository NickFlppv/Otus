using AutoMapper;
using Otus.Service.Infrastructure;
using Otus.Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(configure =>
{
    configure.AddProfiles(new Profile[]
    {
        new PostgresMappingProfile(),
        new RequestsMappingProfile(),
        new ResponsesMappingProfile()
    });
});

builder.Services.AddNpgsql(builder.Configuration);
builder.Services.AddDataAccess();
builder.Services.AddLogic();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();