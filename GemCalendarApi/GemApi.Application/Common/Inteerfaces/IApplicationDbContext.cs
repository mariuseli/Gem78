using GemApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GemApi.Application.Common.Inteerfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<GemEvent> GemEvent { get; set; }
        public DbSet<GemEventCategory> GemCategory { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
