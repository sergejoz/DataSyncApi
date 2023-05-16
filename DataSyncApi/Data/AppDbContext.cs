using DataSyncApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DataSyncApi.Data
{
	public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dataset> Datasets { get; set; }

        
    }
}

