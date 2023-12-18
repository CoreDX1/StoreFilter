using StoreFilter.Application.Extensions;
using StoreFilter.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

var Configure = builder.Configuration;
builder.Services.AddInjectionInfrastructure(Configure);
builder.Services.AddInjectionApplication(Configure);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

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

app.MapControllers();

app.Run();
