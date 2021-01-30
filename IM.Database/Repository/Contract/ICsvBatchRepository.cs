using System;
using System.Collections.Generic;
using System.Text;

namespace IM.Database.Repository.Contract
{
    public interface ICsvBatchRepository
    {
        void InsertCsvBatch(string content);
    }
}
