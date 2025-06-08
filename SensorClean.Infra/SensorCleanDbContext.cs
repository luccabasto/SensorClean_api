using Microsoft.EntityFrameworkCore;
using SensorClean.Domain.Models;

public class SensorCleanDbContext : DbContext
{
    public SensorCleanDbContext(DbContextOptions<SensorCleanDbContext> options) : base(options) { }

    public DbSet<SchoolModel> Escolas { get; set; }
    public DbSet<SensorModel> Sensores { get; set; }
    public DbSet<ReadingModel> Leituras { get; set; }
    public DbSet<AlertModel> Alertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Escola
        modelBuilder.Entity<SchoolModel>(entity =>
        {
            entity.ToTable("GL_ESCOLA");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("NOME");
            entity.Property(e => e.City).HasColumnName("CIDADE");
            entity.Property(e => e.State).HasColumnName("ESTADO");
            entity.Property(e => e.IsActive).HasColumnName("ATIVO");
        });

        // Sensor
        modelBuilder.Entity<SensorModel>(entity =>
        {
            entity.ToTable("GL_SENSOR");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdSchool).HasColumnName("IDESCOLA");
            entity.Property(e => e.Localization).HasColumnName("LOCALIZACAO");
            entity.Property(e => e.IsActive).HasColumnName("ATIVO");
            entity.Property(e => e.TypeSensor).HasColumnName("TIPO");
            entity.Property(e => e.Description).HasColumnName("DESCRICAO");

            entity.HasOne(e => e.School)
                .WithMany(e => e.Sensor)
                .HasForeignKey(e => e.IdSchool);
        });

        // Leitura
        modelBuilder.Entity<ReadingModel>(entity =>
        {
            entity.ToTable("GL_LEITURA");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdSensor).HasColumnName("IDSENSOR");
            entity.Property(e => e.Temperature).HasColumnName("TEMPERATURA");
            entity.Property(e => e.Humidity).HasColumnName("UMIDADE");
            entity.Property(e => e.Timestamp).HasColumnName("TIMESTAMP_LEITURA");

            entity.HasOne(e => e.Sensor)
                .WithMany(e => e.Reading)
                .HasForeignKey(e => e.IdSensor);
        });

        // Alerta
        modelBuilder.Entity<AlertModel>(entity =>
        {
            entity.ToTable("GL_ALERTA");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ReadingId).HasColumnName("IDLEITURA");
            entity.Property(e => e.Type).HasColumnName("TIPO");
            entity.Property(e => e.Mensager).HasColumnName("MENSAGEM");
            entity.Property(e => e.Level).HasColumnName("NIVEL");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Timestamp).HasColumnName("TIMESTAMP_ALERTA");

            entity.HasOne(e => e.Reading)
                .WithMany(e => e.Alerts)
                .HasForeignKey(e => e.ReadingId);
        });
    }
}
