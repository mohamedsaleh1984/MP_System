using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using MP_NewSystem.Services;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MP_NewSystem.ApiClient
{
    /// <summary>
    /// Bike Api Client
    /// </summary>
    public class BikeApiClient: IBikeApiClient
    {
        private readonly IApiResourceManager _apiResourceManager;
        private WebClient _wc;
        public BikeApiClient(IApiResourceManager apiResourceManager)
        {
            _apiResourceManager = apiResourceManager;
        }

        /// <summary>
        /// Get Station Information
        /// </summary>
        /// <returns></returns>
        public ApiResult GetStationInformation()
        {
            ApiResource type = _apiResourceManager.GetApiResources()[GlobalAppSettings.ApiName];
            ApiResult apiResult = new();
            try
            {
                using (_wc = new WebClient())
                {
                    var json = _wc.DownloadString(type.StationInfo);
                    var result = JsonConvert.DeserializeObject<Root>(json);
                    apiResult.root = result;
                    apiResult.Successful = true;
                    apiResult.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                apiResult.Successful = false;
                apiResult.ErrorMessage = ex.Message;
                return apiResult;
            }
            return apiResult;
        }

        /// <summary>
        /// Get Bike Station Status
        /// </summary>
        /// <returns></returns>
        public ApiResult GetStationStatus()
        {
            ApiResource type = _apiResourceManager.GetApiResources()[GlobalAppSettings.ApiName];
            ApiResult apiResult = new ApiResult();
            try
            {
                using (_wc = new ())
                {
                    var json = _wc.DownloadString(type.StationStatus);
                    var result = JsonConvert.DeserializeObject<Root>(json);
                    apiResult.root = result;
                    apiResult.Successful = true;
                    apiResult.ErrorMessage = "";
                }
            }
            catch (Exception ex)
            {
                apiResult.Successful = false;
                apiResult.ErrorMessage = ex.Message;
                return apiResult;
            }
            return apiResult;
        }
    }
}
