using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class MVCbibliotecaContext : DbContext
    {
        public MVCbibliotecaContext()
        {
        }

        public MVCbibliotecaContext(DbContextOptions<MVCbibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Coleccion> Coleccions { get; set; } = null!;
        public virtual DbSet<DetallePrestamo> DetallePrestamos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<EstadoDetalle> EstadoDetalles { get; set; } = null!;
        public virtual DbSet<HistoricoPrestamo> HistoricoPrestamos { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Perfil> Perfils { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<UbicacionBiblioteca> UbicacionBibliotecas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("autor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");
            });

            modelBuilder.Entity<Coleccion>(entity =>
            {
                entity.ToTable("coleccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdUbicacionBiblioteca).HasColumnName("idUbicacionBiblioteca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdUbicacionBibliotecaNavigation)
                    .WithMany(p => p.Coleccions)
                    .HasForeignKey(d => d.IdUbicacionBiblioteca)
                    .HasConstraintName("FK_coleccion_ubicacion_biblioteca");
            });

            modelBuilder.Entity<DetallePrestamo>(entity =>
            {
                entity.HasKey(e => new { e.IdPrestamo, e.IdLibro });

                entity.ToTable("detalle_prestamo");

                entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");

                entity.Property(e => e.IdLibro).HasColumnName("idLibro");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEstadoDetalle).HasColumnName("idEstadoDetalle");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.HasOne(d => d.IdEstadoDetalleNavigation)
                    .WithMany(p => p.DetallePrestamos)
                    .HasForeignKey(d => d.IdEstadoDetalle)
                    .HasConstraintName("FK_detalle_prestamo_estado_detalle");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.DetallePrestamos)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_prestamo_libro");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.DetallePrestamos)
                    .HasForeignKey(d => d.IdPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_prestamo_prestamo");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<EstadoDetalle>(entity =>
            {
                entity.ToTable("estado_detalle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descipcion)
                    .HasMaxLength(10)
                    .HasColumnName("descipcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<HistoricoPrestamo>(entity =>
            {
                entity.HasKey(e => new { e.IdPrestamo, e.IdEstado });

                entity.ToTable("historico_prestamo");

                entity.Property(e => e.IdPrestamo).HasColumnName("idPrestamo");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuarioRegistro).HasColumnName("idUsuarioRegistro");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.HistoricoPrestamos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_historico_prestamo_estado");

                entity.HasOne(d => d.IdPrestamoNavigation)
                    .WithMany(p => p.HistoricoPrestamos)
                    .HasForeignKey(d => d.IdPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_historico_prestamo_prestamo");

                entity.HasOne(d => d.IdUsuarioRegistroNavigation)
                    .WithMany(p => p.HistoricoPrestamos)
                    .HasForeignKey(d => d.IdUsuarioRegistro)
                    .HasConstraintName("FK_historico_prestamo_usuario");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("libro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaPublicacion");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdColeccion).HasColumnName("idColeccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PosicionColeccion).HasColumnName("posicionColeccion");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_libro_autor");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_libro_categoria");

                entity.HasOne(d => d.IdColeccionNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdColeccion)
                    .HasConstraintName("FK_libro_coleccion");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("menu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("perfil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasMany(d => d.IdMenus)
                    .WithMany(p => p.IdPerfils)
                    .UsingEntity<Dictionary<string, object>>(
                        "PerfilMenu",
                        l => l.HasOne<Menu>().WithMany().HasForeignKey("IdMenu").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_perfil_menu_menu"),
                        r => r.HasOne<Perfil>().WithMany().HasForeignKey("IdPerfil").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_perfil_menu_perfil"),
                        j =>
                        {
                            j.HasKey("IdPerfil", "IdMenu");

                            j.ToTable("perfil_menu");

                            j.IndexerProperty<int>("IdPerfil").HasColumnName("idPerfil");

                            j.IndexerProperty<int>("IdMenu").HasColumnName("idMenu");
                        });
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("prestamo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaTentativaDevolver)
                    .HasColumnType("date")
                    .HasColumnName("fechaTentativaDevolver");

                entity.Property(e => e.IdUsuarioSolicitaPrestamo).HasColumnName("idUsuarioSolicitaPrestamo");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.HasOne(d => d.IdUsuarioSolicitaPrestamoNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdUsuarioSolicitaPrestamo)
                    .HasConstraintName("FK_prestamo_usuario");
            });

            modelBuilder.Entity<UbicacionBiblioteca>(entity =>
            {
                entity.ToTable("ubicacion_biblioteca");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pabellon)
                    .HasMaxLength(10)
                    .HasColumnName("pabellon")
                    .IsFixedLength();

                entity.Property(e => e.Seccion)
                    .HasMaxLength(10)
                    .HasColumnName("seccion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(10)
                    .HasColumnName("apellidos")
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.Property(e => e.IdUbigeo).HasColumnName("idUbigeo");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NroTelefono1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nroTelefono1");

                entity.Property(e => e.NroTelefono2)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("nroTelefono2");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("referencia");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_usuario_perfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
