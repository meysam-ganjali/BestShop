using BestShop.Query.Boostrapper;
using ShopManagment.Configuration;
using SliderManagment.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();


#region Best Shop Services

string connectionStr = builder.Configuration.GetConnectionString("BestShopConnection");
ShopManagmentBootstapper.Configure(builder.Services, connectionStr);
SliderManagmentBootstrapper.Configure(builder.Services, connectionStr);
DiscountManagmentBootstapper.Configure(builder.Services, connectionStr);
InventoryManagmentBootstrapper.Configure(builder.Services, connectionStr);

BestShop_Bootstrapper.Configure(builder.Services);

#endregion



#region Pip Lines

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapDefaultControllerRoute();
app.MapRazorPages();


app.Run();


#endregion