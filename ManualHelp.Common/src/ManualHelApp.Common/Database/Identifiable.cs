using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Database
{
    public class Identifiable
    {
        public Guid Id { get; set; }

        public Identifiable()
        {
            Id = new Guid();
        }
    }
}
