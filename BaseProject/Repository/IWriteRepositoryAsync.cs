using BaseProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Repository {
    public interface IWriteRepositoryAsync<TReturn, T, TKey> {
        Task<TReturn> AddToTheDatabase(T entity);
        Task<TReturn> UpdateTheDatabase(T entity);
        Task Delete(TKey id, CancellationInfo cancelInfo = null);
    }
}
