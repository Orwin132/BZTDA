using System.Data.Entity;

namespace NardSmena.Models
{
    public class ModelsDbContext : DbContext
    {

        public ModelsDbContext() : base("DefaultConnection") { }

        public DbSet<Bnard> Bnards { get; set; }
        public DbSet<BnardStr> BnardStrs { get; set; }
        public DbSet<BnardStr_Sproper> BnardStr_Spropers { get; set; }
        public DbSet<Brab> Brabs { get; set; }
        public DbSet<BRab_Korr> BRab_Korrs { get; set; }
        public DbSet<Kerna> Kernas { get; set; }
        public DbSet<KorUch> KorUches { get; set; }
        public DbSet<MsFndVr> MsFndVrs { get; set; }
        public DbSet<Nach> Naches { get; set; }
        public DbSet<NardStr> NardStrs { get; set; }
        public DbSet<NardStr_Sproper> NardStr_Spropers { get; set; }
        public DbSet<OtpVred> OtpVreds { get; set; }
        public DbSet<PROFF> PROFFs { get; set; }
        public DbSet<RKalend> RKalends { get; set; }
        public DbSet<ShifrDet> ShifrDets { get; set; }
        public DbSet<SprDet> SprDets { get; set; }
        public DbSet<SPRMETAL> SPRMETALs { get; set; }
        public DbSet<Sproper> sPropers { get; set; }
        public DbSet<SPRRAB> SPRRABs { get; set; }
        public DbSet<Sravnenie> Sravnenies { get; set; }
        public DbSet<Tabel> Tabels { get; set; }
        public DbSet<TARIF> TARIFs { get; set; }
        public DbSet<UchDet> UchDets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
