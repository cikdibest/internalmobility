using IM.Web.Database.Entity;
using System.Threading.Tasks;

namespace IM.Web.Database.Repository.Contract
{
    public interface IBatchRepository
    {
        Task InsertBatch(BatchEntity entity);
    }
}
