using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace MP_NewSystem.Services
{
    public class ValidationService : IValidation
    {
        private ICSVReader _csvReader;
        private readonly IMPConfigManager _mpowerConfig;
        private List<string> _apiClients;  
        private List<string> _appModes;  

        public ValidationService(ICSVReader cSVReader, IMPConfigManager mPowerConfigManager)
        {
            _csvReader = cSVReader;
            _mpowerConfig = mPowerConfigManager;
            _apiClients = new List<string>();
            _appModes = new List<string>();

            SeedParams();
        }

        public CustomValidationResult CheckUserParameters(string[] args)
        {
            if (args.Length != 2)
            {
                string errorMessage = "Invalid Parameters...\nPlease enter system parameters as follow ApiClientName(mp|CitiBike) AppMode(Morning|Evening|Afternoon) \n example: MPower Morning";

                return new CustomValidationResult()
                {
                    ErrorMessage = errorMessage,
                    HasError = true
                };
            }

            string ApiClient = args[0].ToLower();
            var api_result = _apiClients.Where(x => x.Equals(ApiClient)).FirstOrDefault();
            if (api_result == null)
            {
                return new CustomValidationResult()
                {
                    ErrorMessage = "Invalid ApiClientName Parameter.",
                    HasError = true
                };
            }

            string AppMode = args[1].ToLower();
            var mode_result = _appModes.Where(x => x.Equals(AppMode)).FirstOrDefault();
            if (mode_result == null)
            {
                return new CustomValidationResult()
                {
                    ErrorMessage = "Invalid System Mode Parameter.",
                    HasError = true
                };
            }

            GlobalAppSettings.ApiName = ApiClient;
            GlobalAppSettings.AppMode = AppMode;

            return new CustomValidationResult()
            {
                ErrorMessage = "",
                HasError = false
            };
        }
        
        public void SeedParams()
        {
            ApiResource[] apiResources = _mpowerConfig.GetAppSettings().ApiResources;
            List<string> clinetNames = apiResources.ToList().Select(x => x.Source.ToLower()).ToList();
            _apiClients.AddRange(clinetNames);

            List<string> strings = new List<string>() {
                "morning",
                "evening",
            };
            _appModes.AddRange(strings);
        }

    }
}
