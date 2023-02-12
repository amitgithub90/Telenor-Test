var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(c =>
//c.BaseAddress = new Uri("https://localhost:<PORT NUMBER>/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
    {
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=AppointmentDtls}/{action=Index}/{id?}");
});
app.Run();
