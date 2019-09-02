using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
