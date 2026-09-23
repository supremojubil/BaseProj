using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Repository {
    public interface IReadRepositoryAsync<T, TKey> {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);  
    }
}
