using System;
using System.Collections.Generic;
using System.Text;

namespace ManualHelp.Common.Types
{
    public class ManualHelpException : Exception
    {
        public string Code { get; }

        public ManualHelpException()
        {
        }

        public ManualHelpException(string code)
        {
            Code = code;
        }

        public ManualHelpException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public ManualHelpException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public ManualHelpException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ManualHelpException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}