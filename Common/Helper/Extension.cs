using Common.InheritException;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class Extension
    {

        public static FenomenException adjustException(this Exception exception, ExceptionType exceptionType, string detailMessage)
        {
            FenomenException fenomenException = new FenomenException(exceptionType, detailMessage);

            return fenomenException;
        }

        public static void toExceptionLog(this Exception exception, string filePath)
        {
            TextWriterTraceListener t = new TextWriterTraceListener(filePath);
            t.WriteLine("Message : " + exception.Message);
            t.WriteLine("Inner Excepiton : " + exception.InnerException);
            t.Flush();
        }

    }
}
