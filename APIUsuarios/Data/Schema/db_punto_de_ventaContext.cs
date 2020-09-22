using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Schema
{
    public partial class db_punto_de_ventaContext : DbContext
    {
        public db_punto_de_ventaContext()
        {
        }

        public db_punto_de_ventaContext(DbContextOptions<db_punto_de_ventaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatUsuario> CatUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=40.74.252.149;port=8082;Database=db_punto_de_venta;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("cat_usuario_pkey");

                entity.ToTable("cat_usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.ApMaterno)
                    .IsRequired()
                    .HasColumnName("ap_materno")
                    .HasMaxLength(255);

                entity.Property(e => e.ApPaterno)
                    .IsRequired()
                    .HasColumnName("ap_paterno")
                    .HasMaxLength(255);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
