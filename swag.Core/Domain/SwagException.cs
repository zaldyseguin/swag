using System;
using System.Collections.Generic;
using System.Text;

namespace swag.Core.Domain
{
    public class SwagException : Exception
    {
        public string ErrorCode { get; }
        public SwagException()
        {

        }

        public SwagException(string errorCode) : this(errorCode, null, null, null)
        {
        }

        public SwagException(string message, params object[] args)
            : this(null, null, message, args)
        {
        }

        public SwagException(string errorCode, string message, params object[] args)
            : this(errorCode, null, message, args)
        {
        }

        public SwagException(Exception innerException, string message, params object[] args)
            : this(string.Empty, innerException, message, args)
        {
        }

        public SwagException(string errorCode, Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
