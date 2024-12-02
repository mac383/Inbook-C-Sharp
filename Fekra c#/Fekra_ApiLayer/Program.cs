using Fekra_DataAccessLayer.Utils;

var builder = WebApplication.CreateBuilder(args);

// Initialize the database
cls_database.Initialize(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// إعداد CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder => builder.WithOrigins("http://localhost:3000",
                                       "http://192.168.1.105:3000",
                                       "https://console.inbook.tech",
                                       "https://inbook.tech",
                                       "https://www.inbook.tech") // أضف المزيد من النطاقات هنا إذا لزم الأمر
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


//using Fekra_DataAccessLayer.Utils;

//var builder = WebApplication.CreateBuilder(args);

//cls_database.Initialize(builder.Configuration);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwaggerUI();
//    app.UseSwagger();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
