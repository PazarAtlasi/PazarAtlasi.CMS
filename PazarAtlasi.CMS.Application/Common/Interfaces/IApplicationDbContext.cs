using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}