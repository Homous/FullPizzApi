﻿using FullPizzApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FullPizzApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

       public DbSet<Pizza> Pizzas { get; set; }
      public DbSet<User> Users { get; set; }

    }
}
