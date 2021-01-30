using System;

namespace IM.Web.Exceptions
{
    public class PropertySetException : Exception
    {
        public PropertySetException(string errorDetail)
            : base($"Property Set Exception occured {errorDetail}")
        {

        }
    }
}
