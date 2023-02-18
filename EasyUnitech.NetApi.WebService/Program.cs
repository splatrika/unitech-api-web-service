using EasyUnitech.NetApi.Interfaces;
using EasyUnitech.NetApi.Services;
using EasyUnitech.NetApi.WebService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<HttpClient>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IKeysAccessor, KeysAccessor>();
builder.Services.AddScoped<IAuthorizedHttpClient, AuthorizedHttpClient>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
