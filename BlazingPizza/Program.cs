using System.Globalization;
using BlazingPizza.Data;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// REGISTER SERVICES
// ----------------------------------------------------
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register your custom services
builder.Services.AddSingleton<PizzaService>();
builder.Services.AddSingleton<OfficeService>();
builder.Services.AddSingleton<UserService>();

// Optional: builder.Services.AddLocalization();

var app = builder.Build();

// ----------------------------------------------------
// SET GLOBAL CULTURE (en-PH)
// ----------------------------------------------------
var cultureInfo = new CultureInfo("en-PH");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// ----------------------------------------------------
// MIDDLEWARE
// ----------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();