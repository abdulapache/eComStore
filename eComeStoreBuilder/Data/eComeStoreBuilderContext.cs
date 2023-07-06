using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eComeStoreBuilder.Models;

namespace eComeStoreBuilder.Data
{
    public class eComeStoreBuilderContext : DbContext
    {
        public eComeStoreBuilderContext (DbContextOptions<eComeStoreBuilderContext> options)
            : base(options)
        {
        }

        public DbSet<eComeStoreBuilder.Models.StoreRequestQue> StoreRequestQue { get; set; } = default!;

        public DbSet<eComeStoreBuilder.Models.WebsiteType> WebsiteType { get; set; } = default!;
    }
}
