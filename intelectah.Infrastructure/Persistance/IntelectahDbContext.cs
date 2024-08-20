﻿using intelectah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace intelectah.Infrastructure.Persistance
{
    public class IntelectahDbContext(DbContextOptions<IntelectahDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
