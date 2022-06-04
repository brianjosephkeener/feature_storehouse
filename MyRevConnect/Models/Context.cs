using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRevConnect.Data.Models;

namespace MyRevConnect.Data.Models
{
    public class Context : DbContext
    {
        private readonly IConfiguration _config;
        public Context(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }
        public DbSet<timedEmail>? timedEmails { get; set; }
        public DbSet<Pixel>? pixels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_config["connectionString"], ServerVersion.AutoDetect("server=localhost;userid=root;password=Cokefloat1996!;port=3306;database=MyRevConnectDB;SslMode=Required"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<timedEmail>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
