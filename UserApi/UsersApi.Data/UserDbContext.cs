using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Data.Entities;

namespace UsersApi.Data
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
            .HasIndex(a => a.Id)
            .IsUnique();

        }
    }
}
