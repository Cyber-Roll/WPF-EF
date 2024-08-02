using Microsoft.EntityFrameworkCore;

namespace FirstDataGrid;

public partial class FamiliaContext : DbContext
{
    public FamiliaContext()
    {
    }

    public FamiliaContext(DbContextOptions<FamiliaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Deporte> Deportes { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Familia;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Actividad");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.IdSport).HasMaxLength(255);
        });

        modelBuilder.Entity<Deporte>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Deporte1)
                .HasMaxLength(255)
                .HasColumnName("Deporte");
            entity.Property(e => e.IdSport).HasMaxLength(255);
            entity.Property(e => e.Lugar).HasMaxLength(255);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Persona");

            entity.Property(e => e.Apellido).HasMaxLength(255);
            entity.Property(e => e.Fecnac).HasColumnType("datetime");
            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
