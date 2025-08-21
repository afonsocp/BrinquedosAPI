using Microsoft.EntityFrameworkCore;
using BrinquedosAPI.Models;

namespace BrinquedosAPI.Data
{
    public class BrinquedosContext : DbContext
    {
        public BrinquedosContext(DbContextOptions<BrinquedosContext> options) : base(options)
        {
        }

        public DbSet<Brinquedo> TDS_TB_Brinquedos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brinquedo>().ToTable("TDS_TB_Brinquedos");
        }
    }
}