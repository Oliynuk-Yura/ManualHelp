using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Response.Abstract
{
    public interface IDataResult<TData> : IResult
    {
        TData Data { get; set; }
    }
}
