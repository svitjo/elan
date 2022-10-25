using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElanWaveBookStore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElanWaveBookStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } //returns first obj

        public DbSet<User> Users { get; set; }

    }
}
