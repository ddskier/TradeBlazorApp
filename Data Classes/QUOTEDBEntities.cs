﻿using Microsoft.EntityFrameworkCore;

namespace TradeBlazorApp.Data_Classes
{
    //This code generated by ChatGTP Interaction 22, and pasted here!

    public class QUOTEDBEntities : DbContext
    {
        public QUOTEDBEntities(DbContextOptions<QUOTEDBEntities> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Quote> Quotes { get; set; }
        // Other DbSets...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the composite key for AccountProfile
            modelBuilder.Entity<Quote>().HasKey(e => new { e.QuoteId, e.Symbol });
            

        }
    }

}
