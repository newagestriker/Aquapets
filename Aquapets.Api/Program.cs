using Aquapets.Shared.Api.ActionFilterAttributes;
using Aquapets.Shared.Api.Middlewares;
using Aquapets.Shared.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    o=>o.CustomOperationIds(e=> $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}"));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddCors();
builder.Services.AddScoped<StringifyModelErrorsAttribute>();

builder.Services
       .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var appID = builder.Configuration["FirebaseAppID"];
        options.Authority = $"https://securetoken.google.com/{appID}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{appID}",
            ValidateAudience = true,
            ValidAudience = appID,
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["X-Access-Token"];
                return Task.CompletedTask;
            }
        };
    });
builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions => {
    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x=>x
.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin =>  true) // allow any origin
                .AllowCredentials()); // allow credentials);

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
