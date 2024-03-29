﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Lab01.Models
{
    public partial class testAPIContext : DbContext
    {
        public testAPIContext()
        {
        }

        public testAPIContext(DbContextOptions<testAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CrsDesc)
                    .HasMaxLength(150)
                    .HasColumnName("Crs_Desc");

                entity.Property(e => e.CrsName)
                    .HasMaxLength(50)
                    .HasColumnName("Crs_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}