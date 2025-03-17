using MP_NewSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP_NewSystem.Services
{
    public interface IApiResourceManager
    {
        Dictionary<string, ApiResource> GetApiResources();
    }
}
