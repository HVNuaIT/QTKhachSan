using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QTKhachSan.Application.Request;
using QTKhachSan.Application.Responsetory;
using QTKhachSan.Application.Validation;
using QTKhachSan.Application.ViewModel;
using QTKhachSan.Domain.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<PhongRequest,PhongResponse>();
builder.Services.AddTransient<PhieuDatRequest, PhieuDatResponse>();
builder.Services.AddTransient<IValidator<PhongVM>, PhongValidation>();
builder.Services.AddDbContext<QTKhachSanDb>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("db")));

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PhongValidation>());
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
