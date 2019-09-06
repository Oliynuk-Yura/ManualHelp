using ManualHelp.Common.Response.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Response.Implement
{
    public class Result : IResult
    {
        public bool Sucssess { get; set; }
        public string Message { get; set; }
    }
}
