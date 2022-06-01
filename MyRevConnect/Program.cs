using MyRevConnect.Data.Models;
using Microsoft.OpenApi.Models;
using MyRevConnect.API;
using System.Timers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
{
    //option
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

TimedChecker.MethodCheck();
app.Run();

class TimedChecker
{
    public static System.Timers.Timer aTmr = new System.Timers.Timer(60000);

    public static void MethodCheck()
    {
        aTmr.Elapsed += ATmr_Elapsed;
        aTmr.Enabled = true;
        aTmr.AutoReset = true;
        aTmr.Start();
    }
    public static async void ATmr_Elapsed(object sender, ElapsedEventArgs e)
    {
        string url = @"https://localhost:7145/api/timedemail/checkstatus";
        using var client = new HttpClient();
        var result = await client.GetAsync(url);
    }
}
