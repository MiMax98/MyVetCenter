using Microsoft.EntityFrameworkCore;
using VetCenter.Models;

namespace VetCenter.Data
{
    public class VetCenterContext : DbContext
    {
        public VetCenterContext(DbContextOptions<VetCenterContext> options) : base(options)
        {
        }

        public VetCenterContext()
        {

        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
    }
}
