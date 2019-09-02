﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Messages.Abstract
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
