using APIApplication.Data;
using APIApplication.Middleware;
using APIApplication.Policy;
using APIApplication.Services;
using APIApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Security.AccessControl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Config the connection
builder.Services.AddDbContext<NoteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));

//Config JWT Token authenticate
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)
            ),
            ValidateIssuerSigningKey = true

        };
});

//builder.Services.AddAuthorization(options =>
//{
//    var accessRoles = new
//    {
//        AccessNoteRead   = "Read:Note",
//        AccessNoteCreate = "Create:Note",
//        AccessNoteUpdate = "Update:Note",
//        AccessNoteDelete = "Delete:Note",

//        AccessUserRead   = "Read:User",
//        AccessUserCreate = "Create:User",
//        AccessUserUpdate = "Update:User",
//        AccessUserDelete = "Delete:User"
//    };

//    foreach (var prop in accessRoles.GetType().GetProperties())
//    {
//        string key = prop.Name;
//        var value = prop.GetValue(accessRoles).ToString()!;
//        //Console.WriteLine($"{key}: {value}");
//        string[] parts = value.Split(':');
//        options.AddPolicy(key, policy =>
//            policy.Requirements.Add(new DynamicRoleRequirement(parts[0], parts[1]))
//        );

//    }
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueDev", builder =>
        builder
        .WithOrigins("http://localhost:5173")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});


//Bind the services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IAuthorizationHandler, DynamicRoleHandler>();

var app = builder.Build();

app.UseMiddleware<MyCustomMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseCors("AllowVueDev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
