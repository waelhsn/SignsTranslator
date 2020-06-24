using Microsoft.EntityFrameworkCore;
using SignsTranslator.Models;

namespace SignsTranslator.Models
{
    public class SignsContext:DbContext
    {
        public SignsContext(DbContextOptions<SignsContext> options) : base(options)
        {
        }

        public DbSet<Signs> AllSigns { get; set; } = null;

        public DbSet<SignsLayouts> SignsLayouts { get; set; } = null;
        public DbSet<DashBoard> DashBoard { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<SignsLayouts>()
                .HasKey(sl => sl.SignId);
            model.Entity<SignsApprovers>()
                .HasAlternateKey(sl => sl.ApproverID);
        }


        public DbSet<SignsTranslator.Models.SignsApprovers> SignsApprovers { get; set; }

    }
}
