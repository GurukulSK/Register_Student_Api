using Microsoft.EntityFrameworkCore;

namespace Student_Registration.DbContexts
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext (DbContextOptions<RegistrationDbContext> options) :base(options) { }
        public DbSet<Model.Gatepass> Gatepass { get; set; }
        public DbSet<Model.Student_data> students { get; set; } 
        public DbSet<Model.SpecialEntryModel> specialmodel { get; set; } 
        public DbSet<Model.areaModel> area { get; set; } 
        public DbSet<Model.PlaceModel> place { get; set; } 
        public DbSet<Model.ReasonModel> reasons { get; set; }
        public DbSet<Model.SabhaModel> sabha { get; set; } 
        public DbSet<Model.SevaList> seva { get; set; } 
        public DbSet<Model.OtpModel> otp { get; set; } 
    }

}
