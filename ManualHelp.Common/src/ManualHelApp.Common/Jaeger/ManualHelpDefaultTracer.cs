﻿using System.Reflection;
using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using OpenTracing;


namespace ManualHelp.Common.Jaeger
{
    public class ManualHelpDefaultTracer
    {
        public static ITracer Create()
            => new Tracer.Builder(Assembly.GetEntryAssembly().FullName)
                .WithReporter(new NoopReporter())
                .WithSampler(new ConstSampler(false))
                .Build();
    }
}
