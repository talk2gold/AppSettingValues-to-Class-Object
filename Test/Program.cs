using Microsoft.Extensions.Configuration;
using Test.Settings;

var builder = WebApplication.CreateBuilder(args);

//01  pass conenection to database activities class
//02  executesql, query, sqry, 

//Assigning Appsetting values to the Class object
builder.Services.Configure<CompanySettings>(builder.Configuration.GetSection("Company"));
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGrid"));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.Configure<DbFormatSettings>(builder.Configuration.GetSection("Dbformat"));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
