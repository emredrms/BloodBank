using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.InheritException
{
    public class FenomenException : Exception
    {
        public ExceptionType ExceptionType { get; set; }
        public string DetailMessage { get; set; }



        public FenomenException(ExceptionType exceptionType, string detailMessage)
        {
            this.ExceptionType = exceptionType;
            this.DetailMessage = detailMessage;
        }

    }
}
