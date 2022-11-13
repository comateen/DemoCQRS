using DemoCQRS_MVC.CQRS.Dispatcher;
using DemoCQRS_MVC.CQRS.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddSingleton<IQueryDispatcher, QueryDispatcher>();

//je coince sur les handlers
//j'ai trouvé une méthode qui utilise un nuget qui ajoute un scan au builder.services mais je suis pas fan
//https://www.nuget.org/packages/Scrutor pour enregistrer tous les query et command handlers
//builder.Services.Scan(selector =>
//{
//    selector.FromCallingAssembly()
//            .AddClasses(filter =>
//            {
//                filter.AssignableTo(typeof(IQueryHandler<,>));
//            })
//            .AsImplementedInterfaces()
//            .WithSingletonLifetime();
//});
//builder.Services.Scan(selector =>
//{
//    selector.FromCallingAssembly()
//            .AddClasses(filter =>
//            {
//                filter.AssignableTo(typeof(ICommandHandler<,>));
//            })
//            .AsImplementedInterfaces()
//            .WithSingletonLifetime();
//});

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
