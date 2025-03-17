using MP_NewSystem.Interfaces;
using MP_NewSystem.Models;
using MP_NewSystem.Services;

namespace MP_NewSystem.SystemModes
{
    public abstract class SystemOperator
    {
        protected readonly IBikeApiClient _BikeApiClient;
        protected readonly ICSVReader _csvReader;
        protected readonly LogWriter _logWriter;
        protected readonly IOperations _operations;

        public SystemOperator(IBikeApiClient bikeApiClient,
                            ICSVReader csvReader,
                            LogWriter logWriter, 
                            IOperations operations)
        {
            _BikeApiClient = bikeApiClient;
            _csvReader = csvReader;
            _logWriter = logWriter;
            _operations = operations;
        }
        public abstract void Operate();
 
    }
}
