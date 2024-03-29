﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common
{
    public class StartupInitializer : IStartupInitializer
    {
        private readonly ISet<IInitializer> _initializers = new HashSet<IInitializer>();

        public void AddInitializer(IInitializer initializer)
            => _initializers.Add(initializer);

        public async Task InitializeAsync()
            => await Task.WhenAll(_initializers.Select(i => i.InitializeAsync()));
    }
}
