using BugRod.Lib.NetworkConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BugRod.Ui
{
    public static class MauiProgram
    {
        private static readonly string CurrentEnvironment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

        public static MauiApp CreateMauiApp()
        {
            var config = SetupConfiguration(new ConfigurationBuilder()).Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddHttpClient<ConnectionClient>();
            builder.Services.AddTransient<IConnectionClient, ConnectionClient>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static IConfigurationBuilder SetupConfiguration(IConfigurationBuilder configBuilder)
        {
            configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configBuilder.AddJsonFile($"appsettings.{CurrentEnvironment}.json", optional: true);
            configBuilder.AddEnvironmentVariables();
            return configBuilder;
        }
    }
}
