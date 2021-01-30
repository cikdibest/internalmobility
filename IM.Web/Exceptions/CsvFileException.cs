using System;

namespace IM.Web.Exceptions
{
    public class CsvFileException : Exception
    {
        public CsvFileException(string detail) : base($"Invalid conversion. {detail}")
        {

        }
    }
}
