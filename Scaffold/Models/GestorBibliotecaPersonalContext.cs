using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GbpAcceso> GbpAccesos { get; set; }

    public virtual DbSet<GbpUsuario> GbpUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("CadenaConexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GbpAcceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("gbp_acceso_pkey");

            entity.ToTable("gbp_acceso", "gbp_operacional");

            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.CodigoAcceso)
                .HasColumnType("character varying")
                .HasColumnName("codigo_acceso");
            entity.Property(e => e.DescripcionAcceso)
                .HasColumnType("character varying")
                .HasColumnName("descripcion_acceso");
        });

        modelBuilder.Entity<GbpUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("gbp_usuarios_pkey");

            entity.ToTable("gbp_usuarios", "gbp_operacional");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApellidosUsuario)
                .HasColumnType("character varying")
                .HasColumnName("apellidos_usuario");
            entity.Property(e => e.ClaveUsuario)
                .HasColumnType("character varying")
                .HasColumnName("clave_usuario");
            entity.Property(e => e.DniUsuario)
                .HasColumnType("character varying")
                .HasColumnName("dni_usuario");
            entity.Property(e => e.EmailUsuario)
                .HasColumnType("character varying")
                .HasColumnName("email_usuario");
            entity.Property(e => e.EstaBloqueadoUsuario).HasColumnName("estaBloqueado_usuario");
            entity.Property(e => e.FchAltaUsuario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_alta_usuario");
            entity.Property(e => e.FchBajaUsuario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_baja_usuario");
            entity.Property(e => e.FchFinBloqueoUsuario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_fin_bloqueo_usuario");
            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.NombreUsuario)
                .HasColumnType("character varying")
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.TlfUsuario)
                .HasColumnType("character varying")
                .HasColumnName("tlf_usuario");

            entity.HasOne(d => d.IdAccesoNavigation).WithMany(p => p.GbpUsuarios)
                .HasForeignKey(d => d.IdAcceso)
                .HasConstraintName("id_acceso_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
