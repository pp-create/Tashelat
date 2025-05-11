using DAL.Entities;
using DAL.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
  
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> User { get; set; }
        public DbSet<MassagerUesrs> MassagerUesrs { get; set; }
        public DbSet<Request> Requestes { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<Services> side { get; set; }
        public DbSet<Questions> Circlecs { get; set; }
        public DbSet<BookFile> BookFiles { get; set; }
        public DbSet<Homepage> Homepage { get; set; }     
        public DbSet<About> About { get; set; }    public DbSet<Contact> Contact { get; set; }
        public DbSet<Reading> Readings { get; set; }      public DbSet<Repliescostomer> Repliescostomer { get; set; }


        public DbSet<FuntionUsre> FuntionUsre { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}