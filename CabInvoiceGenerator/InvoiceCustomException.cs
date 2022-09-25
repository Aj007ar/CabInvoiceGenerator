using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceCustomException : Exception
    {
        public string message;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME
        }
        public ExceptionType exceptionType;
        public InvoiceCustomException(ExceptionType type, string message) : base(message)
        {
            this.exceptionType = type;
        }
    }
}
