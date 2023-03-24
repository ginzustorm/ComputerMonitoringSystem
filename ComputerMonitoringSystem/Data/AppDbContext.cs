using Microsoft.EntityFrameworkCore;
using ComputerMonitoringSystem.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace ComputerMonitoringSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PcMonitoringDatabase;Integrated Security=True
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PcMonitoringDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(options);
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureValue> FeatureValues { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueFeatureValue> IssueFeatureValues { get; set; }
        public DbSet<NormalFeatureValue> NormalFeatureValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Feature>()
                .HasMany(f => f.FeatureValues)
                .WithOne(fv => fv.Feature)
                .HasForeignKey(fv => fv.FeatureId);

            modelBuilder.Entity<Feature>()
                .HasMany(f => f.NormalFeatureValues)
                .WithOne(nfv => nfv.Feature)
                .HasForeignKey(nfv => nfv.FeatureId);

            modelBuilder.Entity<FeatureValue>()
                .HasOne(fv => fv.Feature)
                .WithMany(f => f.FeatureValues)
                .HasForeignKey(fv => fv.FeatureId);

            modelBuilder.Entity<NormalFeatureValue>()
                .HasOne(nfv => nfv.Feature)
                .WithMany(f => f.NormalFeatureValues)
                .HasForeignKey(nfv => nfv.FeatureId);

            modelBuilder.Entity<IssueFeatureValue>()
                .HasKey(iv => new { iv.IssueId, iv.FeatureValueId });

            modelBuilder.Entity<IssueFeatureValue>()
                .HasOne(iv => iv.Issue)
                .WithMany(i => i.IssueFeatureValues)
                .HasForeignKey(iv => iv.IssueId);

            modelBuilder.Entity<IssueFeatureValue>()
                .HasOne(iv => iv.FeatureValue)
                .WithMany()
                .HasForeignKey(iv => iv.FeatureValueId);
            // Настройте другие модели здесь, если нужно

            // Добавление начальных данных
            modelBuilder.Entity<Feature>().HasData(
                // Span features
                new Feature { Id = 1, Name = "TotalPcUsage" },
                new Feature { Id = 2, Name = "TotalTermUsage" },
                new Feature { Id = 3, Name = "TotalTimeFromLastClean" },
                new Feature { Id = 4, Name = "NoiseWhileWorking" },
                new Feature { Id = 5, Name = "UnnormalSoundsWhileWorking" },
                //CPU features
                new Feature { Id = 6, Name = "CpuOverheating" },
                new Feature { Id = 7, Name = "CpuVoltageLevel" },
                new Feature { Id = 8, Name = "CpuElecConsume" },
                new Feature { Id = 9, Name = "CpuFreqLowerStated" },
                //GPU features
                new Feature { Id = 10, Name = "GpuOverheating" },
                new Feature { Id = 11, Name = "GpuVoltageLevel" },
                new Feature { Id = 12, Name = "GpuElecConsume" },
                new Feature { Id = 13, Name = "GpuArtifactsWhileWorking" },
                //Motherboard features
                new Feature { Id = 14, Name = "MbVoltageLevel" },
                new Feature { Id = 15, Name = "MbElecConsume" },
                //Memory features
                new Feature { Id = 16, Name = "HddReadWriteSpeed" },
                new Feature { Id = 17, Name = "SsdReadWriteSpeed" },
                new Feature { Id = 18, Name = "HddBeatSectors" },
                //RAM features
                new Feature { Id = 19, Name = "RamDetection" },
                new Feature { Id = 20, Name = "RamFreqLowerStated" },
                //Other span features
                new Feature { Id = 21, Name = "CoolingVentSpeedLowerStated" },
                new Feature { Id = 22, Name = "UsbPortsMalfuncion" },
                //Power supply features
                new Feature { Id = 23, Name = "PsOverheating" },
                new Feature { Id = 24, Name = "PsWattLessStated" }
            );

            modelBuilder.Entity<FeatureValue>().HasData(
                //Span
                new FeatureValue { Id = 1, FeatureId = 1, Value = "[0, 5" },
                new FeatureValue { Id = 2, FeatureId = 1, Value = "[6, 12" },
                new FeatureValue { Id = 3, FeatureId = 2, Value = "[0, 5]" },
                new FeatureValue { Id = 4, FeatureId = 2, Value = "[6, 12]" },
                new FeatureValue { Id = 5, FeatureId = 3, Value = "[0, 150]" },
                new FeatureValue { Id = 6, FeatureId = 3, Value = "[151, 240]" },
                //Noise while working
                new FeatureValue { Id = 7, FeatureId = 4, Value = "Quite" },
                new FeatureValue { Id = 8, FeatureId = 4, Value = "Normal" },
                new FeatureValue { Id = 9, FeatureId = 4, Value = "Loud" },
                //Unnormal sounds while working
                new FeatureValue { Id = 10, FeatureId = 5, Value = "No" },
                new FeatureValue { Id = 11, FeatureId = 5, Value = "Motherboard signals" },
                new FeatureValue { Id = 12, FeatureId = 5, Value = "Loud cooler spin" },
                new FeatureValue { Id = 13, FeatureId = 5, Value = "Loud power supply cooler spin" },
                new FeatureValue { Id = 14, FeatureId = 5, Value = "Loud PC case cooler spin" },
                new FeatureValue { Id = 15, FeatureId = 5, Value = "Loud HDD cooler spin" }, //15
                                                                                             //CPU
                new FeatureValue { Id = 16, FeatureId = 6, Value = "Yes" },
                new FeatureValue { Id = 17, FeatureId = 6, Value = "No" },
                new FeatureValue { Id = 18, FeatureId = 7, Value = "Low" },
                new FeatureValue { Id = 19, FeatureId = 7, Value = "Fluctuation" },
                new FeatureValue { Id = 20, FeatureId = 7, Value = "Normal" },
                new FeatureValue { Id = 21, FeatureId = 8, Value = "Low" },
                new FeatureValue { Id = 22, FeatureId = 8, Value = "Normal" },
                new FeatureValue { Id = 23, FeatureId = 8, Value = "Higher than stated" },
                new FeatureValue { Id = 24, FeatureId = 9, Value = "Yes" },
                new FeatureValue { Id = 25, FeatureId = 9, Value = "No" }, //24
                                                                           //GPU
                new FeatureValue { Id = 26, FeatureId = 10, Value = "Yes" },
                new FeatureValue { Id = 27, FeatureId = 10, Value = "No" },
                new FeatureValue { Id = 28, FeatureId = 11, Value = "Low" },
                new FeatureValue { Id = 29, FeatureId = 11, Value = "Fluctuation" },
                new FeatureValue { Id = 30, FeatureId = 11, Value = "Normal" },
                new FeatureValue { Id = 31, FeatureId = 12, Value = "Low" },
                new FeatureValue { Id = 32, FeatureId = 12, Value = "Normal" },
                new FeatureValue { Id = 33, FeatureId = 12, Value = "Higher than stated" },
                new FeatureValue { Id = 34, FeatureId = 13, Value = "Yes" },
                new FeatureValue { Id = 35, FeatureId = 13, Value = "No" }, //33 
                                                                            //Motherboard
                new FeatureValue { Id = 36, FeatureId = 14, Value = "Low" },
                new FeatureValue { Id = 37, FeatureId = 14, Value = "Fluctuation" },
                new FeatureValue { Id = 38, FeatureId = 14, Value = "Normal" },
                new FeatureValue { Id = 39, FeatureId = 15, Value = "Low" },
                new FeatureValue { Id = 40, FeatureId = 15, Value = "Normal" },
                new FeatureValue { Id = 41, FeatureId = 15, Value = "Higher than stated" }, //39
                                                                                            //HDD--SSD
                new FeatureValue { Id = 42, FeatureId = 16, Value = "Lower than stated" },
                new FeatureValue { Id = 43, FeatureId = 16, Value = "Fluctuation" },
                new FeatureValue { Id = 44, FeatureId = 16, Value = "Normal" },
                new FeatureValue { Id = 45, FeatureId = 17, Value = "Lower than stated" },
                new FeatureValue { Id = 46, FeatureId = 17, Value = "Fluctuation" },
                new FeatureValue { Id = 47, FeatureId = 17, Value = "Normal" },
                new FeatureValue { Id = 48, FeatureId = 18, Value = "Yes" },
                new FeatureValue { Id = 49, FeatureId = 18, Value = "No" }, //46
                                                                            //RAM
                new FeatureValue { Id = 50, FeatureId = 19, Value = "System detects all connected RAM" },
                new FeatureValue { Id = 51, FeatureId = 19, Value = "System detects not all connected RAM" },
                new FeatureValue { Id = 52, FeatureId = 19, Value = "System doesn't decect any connected RAM" },
                new FeatureValue { Id = 53, FeatureId = 20, Value = "Yes" },
                new FeatureValue { Id = 54, FeatureId = 20, Value = "No" }, //50
                                                                            //Cooling--usbports
                new FeatureValue { Id = 55, FeatureId = 21, Value = "Yes" },
                new FeatureValue { Id = 56, FeatureId = 21, Value = "No" },
                new FeatureValue { Id = 57, FeatureId = 22, Value = "Back panel" },
                new FeatureValue { Id = 58, FeatureId = 22, Value = "Front panel" },
                new FeatureValue { Id = 59, FeatureId = 22, Value = "No malfunction" },
                //Power supply
                new FeatureValue { Id = 60, FeatureId = 23, Value = "Yes" },
                new FeatureValue { Id = 61, FeatureId = 23, Value = "No" },
                new FeatureValue { Id = 62, FeatureId = 24, Value = "Yes" },
                new FeatureValue { Id = 63, FeatureId = 24, Value = "No" }
            );

            modelBuilder.Entity<NormalFeatureValue>().HasData(
                //Span
                new NormalFeatureValue { Id = 1, FeatureId = 1, Value = "[0, 5" },
                new NormalFeatureValue { Id = 2, FeatureId = 2, Value = "[0, 5]" },
                new NormalFeatureValue { Id = 3, FeatureId = 3, Value = "[0, 150]" },
                //Noise while working
                new NormalFeatureValue { Id = 4, FeatureId = 4, Value = "Normal" },
                //Unnormal sounds while working
                new NormalFeatureValue { Id = 5, FeatureId = 5, Value = "None" },
                //CPU
                new NormalFeatureValue { Id = 6, FeatureId = 6, Value = "No" },
                new NormalFeatureValue { Id = 7, FeatureId = 7, Value = "Normal" },
                new NormalFeatureValue { Id = 8, FeatureId = 8, Value = "Normal" },
                new NormalFeatureValue { Id = 9, FeatureId = 9, Value = "No" },
                //GPU
                new NormalFeatureValue { Id = 10, FeatureId = 10, Value = "No" },
                new NormalFeatureValue { Id = 11, FeatureId = 11, Value = "Normal" },
                new NormalFeatureValue { Id = 12, FeatureId = 12, Value = "Normal" },
                new NormalFeatureValue { Id = 13, FeatureId = 13, Value = "No" },
                //Motherboard
                new NormalFeatureValue { Id = 14, FeatureId = 14, Value = "Normal" },
                new NormalFeatureValue { Id = 15, FeatureId = 15, Value = "Normal" },
                //HDD--SSD
                new NormalFeatureValue { Id = 16, FeatureId = 16, Value = "Normal" },
                new NormalFeatureValue { Id = 17, FeatureId = 17, Value = "Normal" },
                new NormalFeatureValue { Id = 18, FeatureId = 18, Value = "No" },
                //RAM
                new NormalFeatureValue { Id = 19, FeatureId = 19, Value = "System detects all connected RAM" },
                new NormalFeatureValue { Id = 20, FeatureId = 20, Value = "No" },
                //Cooling--usbports
                new NormalFeatureValue { Id = 21, FeatureId = 21, Value = "No" },
                new NormalFeatureValue { Id = 22, FeatureId = 22, Value = "No malfunction" },
                //Power supply
                new NormalFeatureValue { Id = 23, FeatureId = 23, Value = "No" },
            new NormalFeatureValue { Id = 24, FeatureId = 24, Value = "No" }
            );

            modelBuilder.Entity<Issue>().HasData(
                new Issue { Id = 1, Name = "CPU issue", Description = "Issue of the central processor. " },
                new Issue { Id = 2, Name = "GPU issue", Description = "Issue of the grapichs processor. " },
                new Issue { Id = 3, Name = "MB issue", Description = "Issue of the motherboard. " },
                new Issue { Id = 4, Name = "SSD issue", Description = "Issue of the solid state drive. " },
                new Issue { Id = 5, Name = "HDD issue", Description = "Issue of the hard disk drive. " },
                new Issue { Id = 6, Name = "Cooler issue", Description = "Issue of the cooling system. " },
                new Issue { Id = 7, Name = "PS issue", Description = "Issue of the power supply. " },
                new Issue { Id = 8, Name = "Common issue", Description = "Old PC / Long used term / Cleaned long ago" },
                new Issue { Id = 9, Name = "RAM issue", Description = "Issue of the RA memory" }
            );

            modelBuilder.Entity<IssueFeatureValue>().HasData(
                new IssueFeatureValue { Id = 1, IssueId = 8, FeatureValueId = 2 },
                new IssueFeatureValue { Id = 2, IssueId = 8, FeatureValueId = 4 },
                new IssueFeatureValue { Id = 3, IssueId = 8, FeatureValueId = 6 },
                //Noise while working
                new IssueFeatureValue { Id = 4, IssueId = 8, FeatureValueId = 7 },
                new IssueFeatureValue { Id = 5, IssueId = 8, FeatureValueId = 9 },
                //Unnormal sounds while working
                new IssueFeatureValue { Id = 6, IssueId = 3, FeatureValueId = 11 },
                new IssueFeatureValue { Id = 7, IssueId = 6, FeatureValueId = 12 },
                new IssueFeatureValue { Id = 8, IssueId = 7, FeatureValueId = 13 },
                new IssueFeatureValue { Id = 9, IssueId = 6, FeatureValueId = 14 },
                new IssueFeatureValue { Id = 10, IssueId = 5, FeatureValueId = 15 },
                //CPU
                new IssueFeatureValue { Id = 11, IssueId = 1, FeatureValueId = 16 },
                new IssueFeatureValue { Id = 12, IssueId = 1, FeatureValueId = 18 },
                new IssueFeatureValue { Id = 13, IssueId = 1, FeatureValueId = 19 },
                new IssueFeatureValue { Id = 14, IssueId = 1, FeatureValueId = 21 },
                new IssueFeatureValue { Id = 15, IssueId = 1, FeatureValueId = 23 },
                new IssueFeatureValue { Id = 16, IssueId = 1, FeatureValueId = 24 },
                //GPU
                new IssueFeatureValue { Id = 17, IssueId = 2, FeatureValueId = 26 },
                new IssueFeatureValue { Id = 18, IssueId = 2, FeatureValueId = 28 },
                new IssueFeatureValue { Id = 19, IssueId = 2, FeatureValueId = 29 },
                new IssueFeatureValue { Id = 20, IssueId = 2, FeatureValueId = 31 },
                new IssueFeatureValue { Id = 21, IssueId = 2, FeatureValueId = 33 },
                new IssueFeatureValue { Id = 22, IssueId = 2, FeatureValueId = 34 },
                //Motherboard
                new IssueFeatureValue { Id = 23, IssueId = 3, FeatureValueId = 36 },
                new IssueFeatureValue { Id = 24, IssueId = 3, FeatureValueId = 37 },
                new IssueFeatureValue { Id = 25, IssueId = 3, FeatureValueId = 39 },
                new IssueFeatureValue { Id = 26, IssueId = 3, FeatureValueId = 41 },
                //HDD--SSD
                new IssueFeatureValue { Id = 27, IssueId = 5, FeatureValueId = 42 },
                new IssueFeatureValue { Id = 28, IssueId = 5, FeatureValueId = 43 },
                new IssueFeatureValue { Id = 29, IssueId = 4, FeatureValueId = 45 },
                new IssueFeatureValue { Id = 30, IssueId = 4, FeatureValueId = 46 },
                new IssueFeatureValue { Id = 31, IssueId = 5, FeatureValueId = 48 },
                //RAM
                new IssueFeatureValue { Id = 32, IssueId = 9, FeatureValueId = 51 },
                new IssueFeatureValue { Id = 33, IssueId = 9, FeatureValueId = 52 },
                new IssueFeatureValue { Id = 34, IssueId = 9, FeatureValueId = 53 },
                //Cooling--usbports
                new IssueFeatureValue { Id = 35, IssueId = 6, FeatureValueId = 55 },
                new IssueFeatureValue { Id = 36, IssueId = 3, FeatureValueId = 57 },
                new IssueFeatureValue { Id = 37, IssueId = 3, FeatureValueId = 58 },
                //Power supply
                new IssueFeatureValue { Id = 38, IssueId = 7, FeatureValueId = 60 },
                new IssueFeatureValue { Id = 39, IssueId = 7, FeatureValueId = 62 }
            );
        }
        private static void SeedData(AppDbContext context)
        {

            context.SaveChanges();
        }
    }
}
