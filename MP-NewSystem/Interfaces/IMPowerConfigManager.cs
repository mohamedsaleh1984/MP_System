using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP_NewSystem.Interfaces
{
    public interface IMPConfigManager
    {
        AppSettings GetAppSettings();
    }
}
