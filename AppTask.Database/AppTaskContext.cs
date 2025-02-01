using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Database
{
    public class AppTaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskModel.SubTaskModel> SubTasks { get; set; }

        //public AppTaskContext()
        //{
        //    //Database.Migrate();
        //    InitializeDatabaseAsync();
        //}

        //public async Task InitializeDatabaseAsync()
        //{
        //    await Database.MigrateAsync();
        //}

        public AppTaskContext(DbContextOptions<AppTaskContext> options)
        : base(options)
        {
            Database.MigrateAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Caminho do banco de dados usando Environment.SpecialFolder.LocalApplicationData
            //var databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "apptask.db");
            
            //optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskModel.SubTaskModel>().HasKey(x => x.Id);
        }
    }
}
