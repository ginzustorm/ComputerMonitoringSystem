﻿// <auto-generated />
using ComputerMonitoringSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComputerMonitoringSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComputerMonitoringSystem.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TotalPcUsage"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TotalTermUsage"
                        },
                        new
                        {
                            Id = 3,
                            Name = "TotalTimeFromLastClean"
                        },
                        new
                        {
                            Id = 4,
                            Name = "NoiseWhileWorking"
                        },
                        new
                        {
                            Id = 5,
                            Name = "UnnormalSoundsWhileWorking"
                        },
                        new
                        {
                            Id = 6,
                            Name = "CpuOverheating"
                        },
                        new
                        {
                            Id = 7,
                            Name = "CpuVoltageLevel"
                        },
                        new
                        {
                            Id = 8,
                            Name = "CpuElecConsume"
                        },
                        new
                        {
                            Id = 9,
                            Name = "CpuFreqLowerStated"
                        },
                        new
                        {
                            Id = 10,
                            Name = "GpuOverheating"
                        },
                        new
                        {
                            Id = 11,
                            Name = "GpuVoltageLevel"
                        },
                        new
                        {
                            Id = 12,
                            Name = "GpuElecConsume"
                        },
                        new
                        {
                            Id = 13,
                            Name = "GpuArtifactsWhileWorking"
                        },
                        new
                        {
                            Id = 14,
                            Name = "MbVoltageLevel"
                        },
                        new
                        {
                            Id = 15,
                            Name = "MbElecConsume"
                        },
                        new
                        {
                            Id = 16,
                            Name = "HddReadWriteSpeed"
                        },
                        new
                        {
                            Id = 17,
                            Name = "SsdReadWriteSpeed"
                        },
                        new
                        {
                            Id = 18,
                            Name = "HddBeatSectors"
                        },
                        new
                        {
                            Id = 19,
                            Name = "RamDetection"
                        },
                        new
                        {
                            Id = 20,
                            Name = "RamFreqLowerStated"
                        },
                        new
                        {
                            Id = 21,
                            Name = "CoolingVentSpeedLowerStated"
                        },
                        new
                        {
                            Id = 22,
                            Name = "UsbPortsMalfuncion"
                        },
                        new
                        {
                            Id = 23,
                            Name = "PsOverheating"
                        },
                        new
                        {
                            Id = 24,
                            Name = "PsWattLessStated"
                        });
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.FeatureValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureValues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FeatureId = 1,
                            Value = "[0, 5"
                        },
                        new
                        {
                            Id = 2,
                            FeatureId = 1,
                            Value = "[6, 12"
                        },
                        new
                        {
                            Id = 3,
                            FeatureId = 2,
                            Value = "[0, 5]"
                        },
                        new
                        {
                            Id = 4,
                            FeatureId = 2,
                            Value = "[6, 12]"
                        },
                        new
                        {
                            Id = 5,
                            FeatureId = 3,
                            Value = "[0, 150]"
                        },
                        new
                        {
                            Id = 6,
                            FeatureId = 3,
                            Value = "[151, 240]"
                        },
                        new
                        {
                            Id = 7,
                            FeatureId = 4,
                            Value = "Quite"
                        },
                        new
                        {
                            Id = 8,
                            FeatureId = 4,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 9,
                            FeatureId = 4,
                            Value = "Loud"
                        },
                        new
                        {
                            Id = 10,
                            FeatureId = 5,
                            Value = "No"
                        },
                        new
                        {
                            Id = 11,
                            FeatureId = 5,
                            Value = "Motherboard signals"
                        },
                        new
                        {
                            Id = 12,
                            FeatureId = 5,
                            Value = "Loud cooler spin"
                        },
                        new
                        {
                            Id = 13,
                            FeatureId = 5,
                            Value = "Loud power supply cooler spin"
                        },
                        new
                        {
                            Id = 14,
                            FeatureId = 5,
                            Value = "Loud PC case cooler spin"
                        },
                        new
                        {
                            Id = 15,
                            FeatureId = 5,
                            Value = "Loud HDD cooler spin"
                        },
                        new
                        {
                            Id = 16,
                            FeatureId = 6,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 17,
                            FeatureId = 6,
                            Value = "No"
                        },
                        new
                        {
                            Id = 18,
                            FeatureId = 7,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 19,
                            FeatureId = 7,
                            Value = "Fluctuation"
                        },
                        new
                        {
                            Id = 20,
                            FeatureId = 7,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 21,
                            FeatureId = 8,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 22,
                            FeatureId = 8,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 23,
                            FeatureId = 8,
                            Value = "Higher than stated"
                        },
                        new
                        {
                            Id = 24,
                            FeatureId = 9,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 25,
                            FeatureId = 9,
                            Value = "No"
                        },
                        new
                        {
                            Id = 26,
                            FeatureId = 10,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 27,
                            FeatureId = 10,
                            Value = "No"
                        },
                        new
                        {
                            Id = 28,
                            FeatureId = 11,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 29,
                            FeatureId = 11,
                            Value = "Fluctuation"
                        },
                        new
                        {
                            Id = 30,
                            FeatureId = 11,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 31,
                            FeatureId = 12,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 32,
                            FeatureId = 12,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 33,
                            FeatureId = 12,
                            Value = "Higher than stated"
                        },
                        new
                        {
                            Id = 34,
                            FeatureId = 13,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 35,
                            FeatureId = 13,
                            Value = "No"
                        },
                        new
                        {
                            Id = 36,
                            FeatureId = 14,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 37,
                            FeatureId = 14,
                            Value = "Fluctuation"
                        },
                        new
                        {
                            Id = 38,
                            FeatureId = 14,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 39,
                            FeatureId = 15,
                            Value = "Low"
                        },
                        new
                        {
                            Id = 40,
                            FeatureId = 15,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 41,
                            FeatureId = 15,
                            Value = "Higher than stated"
                        },
                        new
                        {
                            Id = 42,
                            FeatureId = 16,
                            Value = "Lower than stated"
                        },
                        new
                        {
                            Id = 43,
                            FeatureId = 16,
                            Value = "Fluctuation"
                        },
                        new
                        {
                            Id = 44,
                            FeatureId = 16,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 45,
                            FeatureId = 17,
                            Value = "Lower than stated"
                        },
                        new
                        {
                            Id = 46,
                            FeatureId = 17,
                            Value = "Fluctuation"
                        },
                        new
                        {
                            Id = 47,
                            FeatureId = 17,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 48,
                            FeatureId = 18,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 49,
                            FeatureId = 18,
                            Value = "No"
                        },
                        new
                        {
                            Id = 50,
                            FeatureId = 19,
                            Value = "System detects all connected RAM"
                        },
                        new
                        {
                            Id = 51,
                            FeatureId = 19,
                            Value = "System detects not all connected RAM"
                        },
                        new
                        {
                            Id = 52,
                            FeatureId = 19,
                            Value = "System doesn't decect any connected RAM"
                        },
                        new
                        {
                            Id = 53,
                            FeatureId = 20,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 54,
                            FeatureId = 20,
                            Value = "No"
                        },
                        new
                        {
                            Id = 55,
                            FeatureId = 21,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 56,
                            FeatureId = 21,
                            Value = "No"
                        },
                        new
                        {
                            Id = 57,
                            FeatureId = 22,
                            Value = "Back panel"
                        },
                        new
                        {
                            Id = 58,
                            FeatureId = 22,
                            Value = "Front panel"
                        },
                        new
                        {
                            Id = 59,
                            FeatureId = 22,
                            Value = "No malfunction"
                        },
                        new
                        {
                            Id = 60,
                            FeatureId = 23,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 61,
                            FeatureId = 23,
                            Value = "No"
                        },
                        new
                        {
                            Id = 62,
                            FeatureId = 24,
                            Value = "Yes"
                        },
                        new
                        {
                            Id = 63,
                            FeatureId = 24,
                            Value = "No"
                        });
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Issue of the central processor. ",
                            Name = "CPU issue"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Issue of the grapichs processor. ",
                            Name = "GPU issue"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Issue of the motherboard. ",
                            Name = "MB issue"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Issue of the solid state drive. ",
                            Name = "SSD issue"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Issue of the hard disk drive. ",
                            Name = "HDD issue"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Issue of the cooling system. ",
                            Name = "Cooler issue"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Issue of the power supply. ",
                            Name = "PS issue"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Old PC / Long used term / Cleaned long ago",
                            Name = "Common issue"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Issue of the RA memory",
                            Name = "RAM issue"
                        });
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.IssueFeatureValue", b =>
                {
                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureValueId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IssueId", "FeatureValueId");

                    b.HasIndex("FeatureValueId");

                    b.ToTable("IssueFeatureValues");

                    b.HasData(
                        new
                        {
                            IssueId = 8,
                            FeatureValueId = 2,
                            Id = 1
                        },
                        new
                        {
                            IssueId = 8,
                            FeatureValueId = 4,
                            Id = 2
                        },
                        new
                        {
                            IssueId = 8,
                            FeatureValueId = 6,
                            Id = 3
                        },
                        new
                        {
                            IssueId = 8,
                            FeatureValueId = 7,
                            Id = 4
                        },
                        new
                        {
                            IssueId = 8,
                            FeatureValueId = 9,
                            Id = 5
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 11,
                            Id = 6
                        },
                        new
                        {
                            IssueId = 6,
                            FeatureValueId = 12,
                            Id = 7
                        },
                        new
                        {
                            IssueId = 7,
                            FeatureValueId = 13,
                            Id = 8
                        },
                        new
                        {
                            IssueId = 6,
                            FeatureValueId = 14,
                            Id = 9
                        },
                        new
                        {
                            IssueId = 5,
                            FeatureValueId = 15,
                            Id = 10
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 16,
                            Id = 11
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 18,
                            Id = 12
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 19,
                            Id = 13
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 21,
                            Id = 14
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 23,
                            Id = 15
                        },
                        new
                        {
                            IssueId = 1,
                            FeatureValueId = 24,
                            Id = 16
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 26,
                            Id = 17
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 28,
                            Id = 18
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 29,
                            Id = 19
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 31,
                            Id = 20
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 33,
                            Id = 21
                        },
                        new
                        {
                            IssueId = 2,
                            FeatureValueId = 34,
                            Id = 22
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 36,
                            Id = 23
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 37,
                            Id = 24
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 39,
                            Id = 25
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 41,
                            Id = 26
                        },
                        new
                        {
                            IssueId = 5,
                            FeatureValueId = 42,
                            Id = 27
                        },
                        new
                        {
                            IssueId = 5,
                            FeatureValueId = 43,
                            Id = 28
                        },
                        new
                        {
                            IssueId = 4,
                            FeatureValueId = 45,
                            Id = 29
                        },
                        new
                        {
                            IssueId = 4,
                            FeatureValueId = 46,
                            Id = 30
                        },
                        new
                        {
                            IssueId = 5,
                            FeatureValueId = 48,
                            Id = 31
                        },
                        new
                        {
                            IssueId = 9,
                            FeatureValueId = 51,
                            Id = 32
                        },
                        new
                        {
                            IssueId = 9,
                            FeatureValueId = 52,
                            Id = 33
                        },
                        new
                        {
                            IssueId = 9,
                            FeatureValueId = 53,
                            Id = 34
                        },
                        new
                        {
                            IssueId = 6,
                            FeatureValueId = 55,
                            Id = 35
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 57,
                            Id = 36
                        },
                        new
                        {
                            IssueId = 3,
                            FeatureValueId = 58,
                            Id = 37
                        },
                        new
                        {
                            IssueId = 7,
                            FeatureValueId = 60,
                            Id = 38
                        },
                        new
                        {
                            IssueId = 7,
                            FeatureValueId = 62,
                            Id = 39
                        });
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.NormalFeatureValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("NormalFeatureValues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FeatureId = 1,
                            Value = "[0, 5"
                        },
                        new
                        {
                            Id = 2,
                            FeatureId = 2,
                            Value = "[0, 5]"
                        },
                        new
                        {
                            Id = 3,
                            FeatureId = 3,
                            Value = "[0, 150]"
                        },
                        new
                        {
                            Id = 4,
                            FeatureId = 4,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 5,
                            FeatureId = 5,
                            Value = "None"
                        },
                        new
                        {
                            Id = 6,
                            FeatureId = 6,
                            Value = "No"
                        },
                        new
                        {
                            Id = 7,
                            FeatureId = 7,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 8,
                            FeatureId = 8,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 9,
                            FeatureId = 9,
                            Value = "No"
                        },
                        new
                        {
                            Id = 10,
                            FeatureId = 10,
                            Value = "No"
                        },
                        new
                        {
                            Id = 11,
                            FeatureId = 11,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 12,
                            FeatureId = 12,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 13,
                            FeatureId = 13,
                            Value = "No"
                        },
                        new
                        {
                            Id = 14,
                            FeatureId = 14,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 15,
                            FeatureId = 15,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 16,
                            FeatureId = 16,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 17,
                            FeatureId = 17,
                            Value = "Normal"
                        },
                        new
                        {
                            Id = 18,
                            FeatureId = 18,
                            Value = "No"
                        },
                        new
                        {
                            Id = 19,
                            FeatureId = 19,
                            Value = "System detects all connected RAM"
                        },
                        new
                        {
                            Id = 20,
                            FeatureId = 20,
                            Value = "No"
                        },
                        new
                        {
                            Id = 21,
                            FeatureId = 21,
                            Value = "No"
                        },
                        new
                        {
                            Id = 22,
                            FeatureId = 22,
                            Value = "No malfunction"
                        },
                        new
                        {
                            Id = 23,
                            FeatureId = 23,
                            Value = "No"
                        },
                        new
                        {
                            Id = 24,
                            FeatureId = 24,
                            Value = "No"
                        });
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.FeatureValue", b =>
                {
                    b.HasOne("ComputerMonitoringSystem.Models.Feature", "Feature")
                        .WithMany("FeatureValues")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.IssueFeatureValue", b =>
                {
                    b.HasOne("ComputerMonitoringSystem.Models.FeatureValue", "FeatureValue")
                        .WithMany()
                        .HasForeignKey("FeatureValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerMonitoringSystem.Models.Issue", "Issue")
                        .WithMany("IssueFeatureValues")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerMonitoringSystem.Models.NormalFeatureValue", b =>
                {
                    b.HasOne("ComputerMonitoringSystem.Models.Feature", "Feature")
                        .WithMany("NormalFeatureValues")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
