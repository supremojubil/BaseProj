using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Repository {
    public interface IRepositoryAsync<TReturn, TIn, TKey> : IReadRepositoryAsync<TReturn, TKey>, IWriteRepositoryAsync<TReturn, TIn, TKey> {
    }
}
