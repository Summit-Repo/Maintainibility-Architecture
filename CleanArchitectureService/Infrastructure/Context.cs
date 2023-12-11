using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
       : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable(nameof(Users));
            modelBuilder.Entity<Product>().ToTable(nameof(Products));
            base.OnModelCreating(modelBuilder);
        }

    }

}