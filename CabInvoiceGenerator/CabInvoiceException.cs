using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Custom Exception
        /// </summary>
        public ExceptionType exceptionType;

        /// <summary>
        /// Enum for Custom Exception
        /// </summary>
        public enum ExceptionType
        {
            INVALID_TIME,
            INVALID_DISTANCE,
            NULL_RIDES
        }

        /// <summary> 
        ///Parameterized constructor for CabInvoiceCustomException
        /// </summary>
        /// <param name="exceptionType"></param>
        /// <param name="message"></param>
        public CabInvoiceException(ExceptionType exceptionType,string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }

    }
}
