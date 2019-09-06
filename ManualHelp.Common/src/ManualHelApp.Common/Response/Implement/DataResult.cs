using ManualHelp.Common.Response.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Response.Implement
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public TData Data { get; set; }
    }
}
