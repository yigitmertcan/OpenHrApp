using Hangfire;
using HrApp.Contexts;
using HrApp.Interfaces.ApplicationServices;
using HrApp.Interfaces.Repositories;
using HrApp.Interfaces.Services;
using HrApp.Mappings;
using HrApp.Models;
using HrApp.Repositories;
using HrApp.Services;
using HrApp.Services.ApplicationServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Serilog;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mssql connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HrDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentityCore<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores <HrDBContext> ();


//Redis connection
IConfiguration configuration = builder.Configuration;
var redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

builder.Services.AddControllers()
    .AddOData(opt =>
        opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count()
        .AddRouteComponents("api/odata", GetEdmModel(builder.Services)));


//ApplicationServices
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

// Serilog yapýlandýrmasýný appsettings.json dosyasýndan okuyoruz
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)  // appsettings.json'dan okuma
    .CreateLogger();

builder.Host.UseSerilog();  // Serilog kullanýmý

// Hangfire'ýn kullanýlacaðý veri deposunu yapýlandýrýn (örneðin, SQL Server):
builder.Services.AddHangfire(configuration =>
    configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));

// Hangfire'ý Dependency Injection (DI) konteynýrýna ekleyin
builder.Services.AddHangfireServer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]))
    };
});

//Repositiories
builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddTransient<IDepartmanRepository, DepartmanRepository>();
builder.Services.AddTransient<IEmployerRepository, EmployerRepository>();
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddTransient<IPerformanceReviewRepository, PerformanceReviewRepository>();
builder.Services.AddTransient<IRecruitmentRepository, RecruitmentRepository>();
builder.Services.AddTransient<ISalaryRepository, SalaryRepository>();
builder.Services.AddTransient<ITrainingRepository, TrainingRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Services
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddTransient<IAttendanceService, AttendanceService>();
builder.Services.AddTransient<IDepartmanService, DepartmanService>();
builder.Services.AddTransient<IEmployerService, EmployerService>();
builder.Services.AddTransient<IJobService, JobService>();
builder.Services.AddTransient<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddTransient<IPerformanceReviewService, PerformanceReviewService>();
builder.Services.AddTransient<IRecruitmentService, RecruitmentService>();
builder.Services.AddTransient<ISalaryService, SalaryService>();
builder.Services.AddTransient<ITrainingService, TrainingService>();
builder.Services.AddTransient<IUserService, UserService>();

//AutoMappers
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseHangfireDashboard();
// Diðer middleware'lerinizi ekleyin


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard("/hangfire").AllowAnonymous();
});

app.Run();

IEdmModel GetEdmModel(IServiceCollection services)
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<JobModel>("Jobs");
    return builder.GetEdmModel();
}
