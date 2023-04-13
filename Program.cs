using System.Net;
using mailSender_api.Infra.Services;
using mailSender_api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MailSenderApi", Version = "v1" });
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MailSenderApi v1"));
app.UseMiddleware(typeof(ErrorMiddleware));
app.MapControllers();

app.Run();