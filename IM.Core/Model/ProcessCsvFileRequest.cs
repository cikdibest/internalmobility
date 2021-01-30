using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Core.Model
{
    public class ProcessCsvFileRequest
    {
        public int BatchSize { get; set; }
        public string Path { get; set; }
    }
}
