﻿using ManualHelp.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Handlers.Abstract
{
    public interface IHandler
    {
        IHandler Handle(Func<Task> handle);
        IHandler OnSuccess(Func<Task> onSuccess);
        IHandler OnError(Func<Exception, Task> onError, bool rethrow = false);
        IHandler OnCustomError(Func<ManualHelpException, Task> onCustomError, bool rethrow = false);
        IHandler Always(Func<Task> always);
        Task ExecuteAsync();
    }
}
