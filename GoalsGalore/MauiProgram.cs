using CommunityToolkit.Maui;
using GoalsGalore.ViewModels;
using GoalsGalore.ViewModels.MainViewModels;
using Microsoft.Extensions.Logging;
using PlatinumWMSSwiftUtilityLib.Common;
using PlatinumWMSSwiftUtilityLib.Interface;

using Telerik.Maui.Controls.Compatibility;

#if WINDOWS
using PlatinumWMSSwiftUtilityLib.Platforms.Windows;
#elif ANDROID

using PlatinumWMSSwiftUtilityLib.Platforms.Android;

#endif

namespace GoalsGalore;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit(options => { options.SetShouldEnableSnackbarOnWindows(true); })
               .UseTelerik()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("RobotoMono-Regular.ttf", "RobotoMono");
                   fonts.AddFont("telerikfontexamples.ttf", "TelerikFontExamples");
                   fonts.AddFont("telerikfont.ttf", "telerikfont");
                   fonts.AddFont("Segoe UI.otf", "SegoeUI");
                   fonts.AddFont("MaterialSymbols.ttf", "GoogleIcons");
               });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<ViewModelA>();
        builder.Services.AddTransient<ViewModelB>();
        builder.Services.AddTransient<ViewModelC>();

        builder.Services.AddSingleton<INotificationService, NotificationService>()
                        .AddSingleton<ISoundService, SoundService>();

        builder.Services.AddTransient<MainViewModel>()
                        .AddTransient<FilterPageViewModel>()
                        .AddTransient<ItemsViewModel>()
                        .AddTransient<TestCardPageViewModel>();
        return builder.Build();
    }
}