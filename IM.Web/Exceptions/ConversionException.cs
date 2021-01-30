using System;

namespace IM.Web.Exceptions
{
    public class ConversionException : Exception
    {
        public ConversionException(string errorDetail)
            : base($"Invalid conversion. {errorDetail}")
        {
        }
    }
}
