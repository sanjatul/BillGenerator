using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BillGenerator.Models;

public partial class BillerDemoDbContext : DbContext
{
   
    public BillerDemoDbContext(DbContextOptions<BillerDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Biller> Billers { get; set; }

    public virtual DbSet<BillerAssignment> BillerAssignments { get; set; }

    public virtual DbSet<BillerConfiguration> BillerConfigurations { get; set; }

    public virtual DbSet<BillerFormDataset> BillerFormDatasets { get; set; }

    public virtual DbSet<BillerFormDatasetField> BillerFormDatasetFields { get; set; }

    public virtual DbSet<BillerFormDatasetFieldValue> BillerFormDatasetFieldValues { get; set; }

    public virtual DbSet<BillerFormDatasetMappingField> BillerFormDatasetMappingFields { get; set; }

    public virtual DbSet<BillerFormFieldType> BillerFormFieldTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile($"appsettings.json")
           .Build();
            var config = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(config ?? string.Empty, ServerVersion.AutoDetect(config));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Biller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("billers")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillType)
                .HasMaxLength(45)
                .HasColumnName("bill_type");
            entity.Property(e => e.Code)
                .HasMaxLength(45)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Metadata).HasColumnName("metadata");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BillerAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("biller_assignments")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillerId).HasColumnName("biller_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<BillerConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_configuration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillerId).HasColumnName("biller_id");
            entity.Property(e => e.Configuration).HasColumnName("configuration");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Purpose)
                .HasMaxLength(255)
                .HasColumnName("purpose");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<BillerFormDataset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_form_datasets");

            entity.HasIndex(e => e.BillerId, "biller_form_datasets_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillerId).HasColumnName("biller_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DatasetName)
                .HasMaxLength(500)
                .HasColumnName("dataset_name");
            entity.Property(e => e.UniqueId)
                .HasMaxLength(100)
                .HasColumnName("unique_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Biller).WithMany(p => p.BillerFormDatasets)
                .HasForeignKey(d => d.BillerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("biller_form_datasets_FK");
        });

        modelBuilder.Entity<BillerFormDatasetField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_form_dataset_fields");

            entity.HasIndex(e => e.DatasetId, "biller_form_dataset_fields_FK");

            entity.HasIndex(e => e.FieldTypeId, "biller_form_dataset_fields_FK_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DatasetId).HasColumnName("dataset_id");
            entity.Property(e => e.FieldName)
                .HasMaxLength(100)
                .HasColumnName("field_name");
            entity.Property(e => e.FieldOrder).HasColumnName("field_order");
            entity.Property(e => e.FieldTypeId).HasColumnName("field_type_id");
            entity.Property(e => e.FriendlyFieldName)
                .HasMaxLength(100)
                .HasColumnName("friendly_field_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsMandatory).HasColumnName("is_mandatory");
            entity.Property(e => e.MaxLength).HasColumnName("max_length");
            entity.Property(e => e.MaxValue)
                .HasPrecision(16, 4)
                .HasColumnName("max_value");
            entity.Property(e => e.MinValue)
                .HasPrecision(16, 4)
                .HasColumnName("min_value");
            entity.Property(e => e.Regex).HasColumnName("regex");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Dataset).WithMany(p => p.BillerFormDatasetFields)
                .HasForeignKey(d => d.DatasetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("biller_form_dataset_fields_FK");

            entity.HasOne(d => d.FieldType).WithMany(p => p.BillerFormDatasetFields)
                .HasForeignKey(d => d.FieldTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("biller_form_dataset_fields_FK_1");
        });

        modelBuilder.Entity<BillerFormDatasetFieldValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_form_dataset_field_values");

            entity.HasIndex(e => e.DatasetFieldId, "biller_form_field_values_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DatasetFieldId).HasColumnName("dataset_field_id");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.Text)
                .HasMaxLength(500)
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .HasColumnName("value");

            entity.HasOne(d => d.DatasetField).WithMany(p => p.BillerFormDatasetFieldValues)
                .HasForeignKey(d => d.DatasetFieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("biller_form_field_values_FK");
        });

        modelBuilder.Entity<BillerFormDatasetMappingField>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_form_dataset_mapping_fields");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BillerId).HasColumnName("biller_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.MappingFieldName)
                .HasMaxLength(500)
                .HasColumnName("mapping_field_name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<BillerFormFieldType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("biller_form_field_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
