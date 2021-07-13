using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMangmentSystem.Models;
namespace UserMangmentSystem.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> op )
            : base(op)
        {
                
        }
        // Add All The Objects That Reprsent Tables Here 
        //          Type | Table Name
        public DbSet <User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
