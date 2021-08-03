using GemApi.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GemApi.Application.Common.Inteerfaces
{
    public class IApplicationDbContext
    {
        public DbSet<GemEvent> GemEvents { get; set; }
        public DbSet<GemEventCategory> GemCategories { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
