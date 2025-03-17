using Microsoft.Extensions.Configuration;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System.IO;

namespace MP_NewSystem.Services
{
    public class MPConfigManager: IMPConfigManager
    {
        public AppSettings GetAppSettings()
        {
            AppSettings _appSettings = new AppSettings();
            var configuration = GetConfiguration();
            configuration.Bind(_appSettings);
            return _appSettings;
        }
        private IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            return builder.Build();
        }

    }
}
