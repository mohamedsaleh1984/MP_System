using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System.Collections.Generic;

namespace MP_NewSystem.Services
{
    public class ApiResourceManager : IApiResourceManager
    {
        private readonly IMPConfigManager _configManager;
        
        public ApiResourceManager(IMPConfigManager ConfigManager)
        {
            _configManager = ConfigManager;
        }
        public Dictionary<string, ApiResource> GetApiResources()
        {
            AppSettings appSettings = _configManager.GetAppSettings();
            Dictionary<string, ApiResource> directory = new Dictionary<string, ApiResource>();

            foreach (var apiSet in appSettings.ApiResources)
            {
                directory.Add(apiSet.Source, apiSet);
            }
            return directory;
        }
    }
}
