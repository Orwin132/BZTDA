using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NardSmena.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Bnard> Bnard { get; set; }
        public DbSet<BnardStr> BnardStr { get; set; }
        public DbSet<BnardStr_Sproper> BnardStr_Sproper { get; set; }
        public DbSet<Brab> Brab { get; set; }
        public DbSet<BRab_Korr> BRab_Korr { get; set; }
        public DbSet<Kerna> Kerna { get; set; }
        public DbSet<KorUch> KorUch { get; set; }
        public DbSet<MsFndVr> MsFndVr { get; set; }
        public DbSet<Nach> Nach { get; set; }
        public DbSet<Nard> Nard { get; set; }
        public DbSet<NardStr> NardStr { get; set; }
        public DbSet<NardStr_Sproper> NardStr_Sproper { get; set; }
        public DbSet<OtpVred> OtpVred { get; set; }
        public DbSet<PROFF> PROFF { get; set; }
        public DbSet<RKalend> RKalend { get; set; }
        public DbSet<ShifrDet> ShifrDet { get; set; }
        public DbSet<SprDet> SprDet { get; set; }
        public DbSet<SPRMETAL> SPRMETAL { get; set; }
        public DbSet<Sproper> Sproper { get; set; }
        public DbSet<SPRRAB> SPRRAB { get; set; }
        public DbSet<Sravnenie> Sravnenie { get; set; }
        public DbSet<Tabel> Tabel { get; set; }
        public DbSet<TARIF> TARIF { get; set; }
        public DbSet<UchDet> UchDet { get; set; }
        public DbSet<RoleAssignmentViewModel> RoleAssignments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("dbo");
        }
    }
}
