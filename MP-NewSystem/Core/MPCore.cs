using Microsoft.Extensions.DependencyInjection;
using MP_NewSystem.ApiClient;
using MP_NewSystem.Helper;
using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using MP_NewSystem.Services;
using MP_NewSystem.SystemModes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Console;

namespace MP_NewSystem.Core
{

    /// <summary>
    /// The main driver of the application
    /// </summary>
    public class MPCore
    {
        private readonly ServiceProvider _serviceProvider = null;

        public MPCore()
        {
            _serviceProvider = new ServiceCollection()
                                        .AddSingleton<ICSVReader, CSVReaderService>()
                                        .AddSingleton<IValidation, ValidationService>()
                                        .AddSingleton<IMPConfigManager, MPConfigManager>()
                                        .AddSingleton<IApiResourceManager, ApiResourceManager>()
                                        .AddSingleton<IBikeApiClient, BikeApiClient>()
                                        .AddSingleton<IOperations, OperationsServices>()
                                        .AddSingleton<LogWriter, CSVFileLogService>()
                                        .AddSingleton<LogWriter, ConsoleLogService>()
                                       .AddTransient<LogFactory>()
                                        .BuildServiceProvider();

        }
        /// <summary>
        /// Entry point of the system...
        /// </summary>
        /// <param name="args"></param>
        public void Start(string[] args)
        {
            var _validation = _serviceProvider.GetService<IValidation>();
            var _csvReader = _serviceProvider.GetService<ICSVReader>();
            var _bikeClient = _serviceProvider.GetService<IBikeApiClient>();
            var _ILogWriter = _serviceProvider.GetService<LogWriter>();
            var _operations = _serviceProvider.GetService<IOperations>();

            CustomValidationResult validationResult = _validation.CheckUserParameters(args);
            if (!validationResult.HasError)
            {
                Dictionary<string, SystemOperator> mapper = ModeMapper(_bikeClient, _csvReader, _ILogWriter, _operations);
                mapper[GlobalAppSettings.AppMode].Operate();
            }
            else
            {
                WriteLine(validationResult.ErrorMessage);
            }
        }



        private Dictionary<string, SystemOperator> ModeMapper(IBikeApiClient _bikeClient, ICSVReader _csvReader, LogWriter _ILogWriter, IOperations _operations)
        {
            Dictionary<string, SystemOperator> mapper = new Dictionary<string, SystemOperator>
            {
                { "morning", new MorningOperator(_bikeClient, _csvReader, _ILogWriter, _operations) },
                { "afternoon", new AfternoonOperator(_bikeClient, _csvReader, _ILogWriter, _operations) },
                { "evening", new EveningOperator(_bikeClient, _csvReader, _ILogWriter, _operations) }
            };

            return mapper;
        }
    }
}
