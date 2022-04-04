using Microsoft.EntityFrameworkCore;
using RegDetails.Model;

namespace RegDetails.Data
{

    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<RegistrationModel> registerData { get; set; }
        public DbSet<AttachmentModel> fileAttachment { get; set; }
        public DbSet<UserModel> AdminLogin { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationModel>().ToTable("candidatedetails");
            modelBuilder.Entity<AttachmentModel>().ToTable("attachments");
            modelBuilder.Entity<UserModel>().ToTable("userlogin");
        }

    }
}

