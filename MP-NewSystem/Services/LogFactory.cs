using Microsoft.Extensions.DependencyInjection;
using MP_NewSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_NewSystem.Services
{
    public class LogFactory
    {
        private bool isCsv = false;
        private readonly ServiceProvider _serviceProvider;
        public LogFactory(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public LogWriter GetLogService()
        {
            if (isCsv)
                return _serviceProvider.GetRequiredService<CSVFileLogService>();
            return _serviceProvider.GetRequiredService<ConsoleLogService>();
        }
    }
}
