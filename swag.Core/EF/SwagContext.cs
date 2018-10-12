
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using swag.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace swag.Core.EF
{
   public  class SwagContext:DbContext
    {
        private readonly SqlSetting _settings;
        public DbSet<Cards> Cards { get; set;}   
        public SwagContext(DbContextOptions<SwagContext> options, IOptions<SqlSetting> settings) :base(options)
        {
            _settings = settings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();

                return;
            }
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cardBuilder = modelBuilder.Entity<Cards>();
            cardBuilder.HasKey(x => x.Id);

        }
    }
}
