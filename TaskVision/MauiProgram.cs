using Microsoft.Extensions.Logging;
using TaskVision.Services.Interfaces;
using TaskVision.Models.Calendar;
using TaskVision.Services.Implementation;

namespace TaskVision
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IGoogleCalendarAdapter, GoogleCalendarAdapter>();
            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
            builder.Services.AddSingleton<INoteDatabaseService>(
    new NoteDatabaseService(Path.Combine(FileSystem.AppDataDirectory, "notes.db")));


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
