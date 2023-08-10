using Book_Store.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Persistence.Contracts
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
    }
}
