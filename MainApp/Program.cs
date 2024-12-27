using Business.Interfaces;
using Business.Services;
using MainApp.Dialogs;
using MainApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IMainMenuDialog, MainMenuDialog>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetRequiredService<IMainMenuDialog>();


mainMenu.ShowMenuOptions();