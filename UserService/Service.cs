namespace UserService {
    public class Service<T> : IService<T> where T : class {
        private readonly IService<T> _service;
        public Service(IService<T> service) {
            _service = service;
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _service.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await _service.GetAllAsync();
        }

        public async Task AddAsync(T entity) {
            await _service.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity) { 
            await _service.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id) { 
            await _service.DeleteAsync(id);
        }
    }
}
