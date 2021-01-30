using IM.Web.Database.Context;
using IM.Web.Database.Entity;
using IM.Web.Database.Repository.Contract;
using System.Threading.Tasks;

namespace IM.Web.Database.Repository
{
    public class BatchRepository : IBatchRepository
    {
        private readonly IMDbContext dbContext;

        public BatchRepository(IMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertBatch(BatchEntity entity)
        {
            dbContext.Batches.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
