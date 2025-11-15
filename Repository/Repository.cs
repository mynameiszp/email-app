
using Amazon.DynamoDBv2.DataModel;

namespace EmailApp.Repository
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDynamoDBContext _context;

        public Repository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.SaveAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.ScanAsync<T>((IEnumerable<ScanCondition>)null).GetRemainingAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _context.LoadAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.SaveAsync(entity);
        }
    }
}