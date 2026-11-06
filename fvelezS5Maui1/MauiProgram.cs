using fvelezS5Maui1.Models;
using fvelezS5Maui1.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace fvelezS5Maui1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<PersonRepository>(
                s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
