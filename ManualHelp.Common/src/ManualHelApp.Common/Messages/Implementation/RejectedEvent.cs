﻿using ManualHelp.Common.Messages.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Messages.Implementation
{
    public class RejectedEvent : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public RejectedEvent(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }

        public static IRejectedEvent For(string name)
            => new RejectedEvent($"There was an error when executing: " +
                                 $"{name}", $"{name}_error");
    }

}
