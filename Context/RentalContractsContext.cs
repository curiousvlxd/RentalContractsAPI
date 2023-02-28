using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using RentalContractsAPI.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace RentalContractsAPI.Context;

public partial class RentalContractsContext : DbContext
{
    public RentalContractsContext()
    {
    }

    public RentalContractsContext(DbContextOptions<RentalContractsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

    public virtual DbSet<ProductionPremise> ProductionPremises { get; set; }

    public virtual DbSet<TechnologyEquipmentType> TechnologyEquipmentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentPlacementContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Equipmen__C90D340964F19D7A");

            entity.ToTable("EquipmentPlacementContract");

            entity.Property(e => e.ContractId)
                .ValueGeneratedNever()
                .HasColumnName("ContractID")
                .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ProductionPremise>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Producti__A25C5AA6013D0B85");

            entity.Property(e => e.Code).ValueGeneratedNever();
            
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Ukrainian_CP1251_CI_AS")
                .HasColumnType("nvarchar");

            entity.Property(e => e.RegulatoryArea).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TechnologyEquipmentType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Technolo__A25C5AA641CFED7E");

            entity.ToTable("TechnologyEquipmentType");

            entity.Property(e => e.Code).ValueGeneratedNever();
            
            entity.Property(e => e.Area).HasColumnType("decimal(10, 2)");
            
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Ukrainian_CP1251_CI_AS")
                .HasColumnType("nvarchar");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
