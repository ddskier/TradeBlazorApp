
//This entire code was copied from ChatGPT 4.0, re Interaction 13.  From start to finish, after sending ir, per #13, my previous entire definition for Program.cs
using Microsoft.EntityFrameworkCore;
using TradeBlazorApp.Business_Classes;
using TradeBlazorApp.Components;
using TradeBlazorApp.Data_Classes;

var builder = WebApplication.CreateBuilder(args);

// Use builder.Configuration to access the Configuration properties ---Added via paste from ChatGPT Interaction 12
builder.Services.AddDbContext<ACCOUNTDBEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ACCOUNTDBConnectionString")));   //Replaceing per ChatCHTP 13, the connection string to point to mine.

// Use builder.Configuration to access the Configuration properties ---Added via paste from ChatGPT Interaction 12

builder.Services.AddDbContext<QUOTEDBEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QUOTEDBConnectionString")));  //Replacing manually, per ChatGPT to use my connection string to Quote table

builder.Services.AddScoped<IAccountService, AccountCurrent>();   //Added per ChatGPT Interaction 47
builder.Services.AddScoped<IStockService, StockService>();       //Added when working on BuyForm, from previous ChatGPT Interaction 47, knew I would need this.
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();