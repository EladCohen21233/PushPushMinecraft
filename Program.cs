var builder = WebApplication.CreateBuilder(args);

// קרא את הכתובת והפורט מתוך appsettings.json
builder.WebHost.UseUrls(builder.Configuration["Urls"]);

// הוסף את השירותים בקונפיגורציה
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
