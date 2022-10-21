using CompanyEmployee.ActionFilters;
using CompanyEmployee.Contracts;
using CompanyEmployee.Entities.Context;
using CompanyEmployee.Entities.DataTransferObjects;
using CompanyEmployee.Extensions;
using CompanyEmployee.LoggerService;
using CompanyEmployee.Repositories.Data_Shaping;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;

}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters()
  .AddCustomCSVFormatter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureLoggerService();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
builder.Services.AddScoped<ValidateEmployeeForCompanyExistsAttribute>();
builder.Services.AddScoped<ValidateCompanyExistsAttribute>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureRepositoryManager();

builder.Services.AddDbContext<RepositoryContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("CEDb")));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

var logger = scope.ServiceProvider.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.ConfigureExceptionHandler(logger);

app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
