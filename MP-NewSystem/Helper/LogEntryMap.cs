using CsvHelper.Configuration;
using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_NewSystem.Helper
{
    public sealed class LogEntryMap : ClassMap<LogEntry>
    {
        public LogEntryMap()
        {
            Map(m => m.ID).Index(0);
            Map(m => m.Team).Index(1);
            Map(m => m.Employee).Index(2);
            Map(m => m.Role).Index(3);
            Map(m => m.StartedOn).Index(4);
            Map(m => m.Message).Index(5);
        }
    }
}
