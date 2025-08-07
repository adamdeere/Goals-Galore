using CommunityToolkit.Maui;
using GoalsGalore.ViewModels;
using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;

namespace GoalsGalore;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .UseTelerik()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("RobotoMono-Regular.ttf", "RobotoMono");
                   fonts.AddFont("telerikfontexamples.ttf", "TelerikFontExamples");
                   fonts.AddFont("telerikfont.ttf", "telerikfont");
                   fonts.AddFont("Segoe UI.otf", "SegoeUI");
               });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<MainViewModel>();
        return builder.Build();
    }
}