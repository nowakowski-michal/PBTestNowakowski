using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WebContext :DbContext
    {
        public DbSet<Student> Studenci { get; set; }
        public DbSet<Grupa> Grupy { get; set; } 
        public DbSet<Historia> Historia { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NowakowskiMPB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //nie było w poleceniu okreśłonych zachowań wiec dałem noaciton
            modelBuilder.Entity<Grupa>().HasMany(g => g.Students).WithOne(u => u.Grupa).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Grupa>().HasMany(g => g.Children).WithOne(u => u.Parent).OnDelete(DeleteBehavior.NoAction);
        }
    }

}

