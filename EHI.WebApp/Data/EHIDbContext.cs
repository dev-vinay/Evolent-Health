using System.Data.Entity;

namespace EHI.WebApp.Data {
    public class EHIDbContext : DbContext {

        public EHIDbContext() : base("name=EHIDbContextConnectionString") {
        }

        public DbSet<Models.PatientContact> PatientContacts { get; set; }
    }
}
