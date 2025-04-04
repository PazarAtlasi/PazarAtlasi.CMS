using System;
using System.Threading.Tasks;
using PazarAtlasi.CMS.Domain.Entities;

namespace PazarAtlasi.CMS.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}