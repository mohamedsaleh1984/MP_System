using System;
using System.Collections.Generic;
using System.Text;

namespace MP_NewSystem.Models
{
    public class ApiResult
    {
        public ApiResult() { }
        public bool Successful { get; set; }
        public string ErrorMessage { get; set; }
        public Root root { get; set; }
    }
}
