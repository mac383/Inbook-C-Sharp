using Fekra_ApiLayer.Controllers;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.services.chatGPT;
using Fekra_DataAccessLayer.models.chatGPT;
using Fekra_DataAccessLayer.models.firebase;
using Fekra_DataAccessLayer.Utils;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Initialize the database
cls_database.Initialize(builder.Configuration);

// configure firebase
builder.Services.Configure<md_FirebaseConfig>(builder.Configuration.GetSection("Firebase"));

// إضافة IHttpClientFactory
builder.Services.AddHttpClient();

// configure chat-gpt
builder.Services.Configure<md_ChatGptConfig>(builder.Configuration.GetSection("chat-3.5-turbo"));

// Add services to the container.
builder.Services.AddControllers();

// إعداد CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder => builder.WithOrigins("http://localhost:3000",
                                       "https://test-383.netlify.app",
                                       "http://192.168.1.105:3000",
                                       "https://console.inbook.tech",
                                       "https://dashboard.inbook.tech",
                                       "https://inbook.tech",
                                       "https://www.inbook.tech") // أضف المزيد من النطاقات هنا إذا لزم الأمر
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger to include token header
// إضافة خدمات Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // إضافة تعريف لـ Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token in the text input below.\nExample: \"Bearer 12345abcdef\"",
    });

    // تطبيق إعدادات الأمان لكل نقطة نهاية
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

// تطبيق سياسة CORS
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();