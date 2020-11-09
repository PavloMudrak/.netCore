using BusinessLayer.Interfaces;
using DataLayer.Context;
using DataLayer.DbDataInit;

namespace BusinessLayer.Implementations
{
    public class SampleDataRepository: ISampleDataRepository
    {
        private EfDbContext _dbContext;

        public SampleDataRepository(EfDbContext context)
        {
            _dbContext = context;
        }

        public void RunSampleData()
        {
            SampleData.InitData(_dbContext);
        }
    }
}
