namespace TradeBlazorApp.Data_Classes
{

    //Al of this code was auto-generated for this class, below, from ChatGPT interaction 12
    using Microsoft.EntityFrameworkCore;

    public class ACCOUNTDBEntities : DbContext
    {
        public ACCOUNTDBEntities(DbContextOptions<ACCOUNTDBEntities> options)
            : base(options)
        {
        }



        public DbSet<AccountProfile> ACCOUNTPROFILE { get; set; }

        //These lines I added, after separately creating model classes from table DDL, for the others tables in this database
        public DbSet<Order> ORDER { get; set; }

        public DbSet<Holding> HOLDING { get; set; }

        public DbSet<Account> ACCOUNT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the composite key for AccountProfile
            modelBuilder.Entity<AccountProfile>().HasKey(e => new { e.UserId, e.AccountId });
            modelBuilder.Entity<Account>().HasKey(e => new { e.ProfileUserId, e.AccountId });

        }

    }

}
