using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using IBasSupportApp.Services;   

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration["CosmosDb:ConnectionString"];
string dbName = builder.Configuration["CosmosDb:DatabaseName"];
string container = builder.Configuration["CosmosDb:ContainerName"];

builder.Services.AddSingleton(new CosmosDbService(connString, dbName, container));

// Test Cosmos-forbindelse
try
{
    var testService = new IBasSupportApp.Services.CosmosDbService(connString, dbName, container);
    Console.WriteLine("✅ CosmosDB connection created successfully.");

  
    var testData = testService.GetAllMessagesAsync().Result;
    Console.WriteLine($"✅ Fetched {testData?.Count()} documents from CosmosDB.");
}
catch (Exception ex)
{
    Console.WriteLine("❌ CosmosDB connection failed: " + ex.Message);
}
// test slut

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();