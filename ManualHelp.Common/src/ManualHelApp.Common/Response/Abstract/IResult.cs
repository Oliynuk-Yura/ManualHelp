using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Response.Abstract
{
    public interface IResult
    {
         bool Sucssess { get; set; }
         string Message { get; set; }
    }
}
