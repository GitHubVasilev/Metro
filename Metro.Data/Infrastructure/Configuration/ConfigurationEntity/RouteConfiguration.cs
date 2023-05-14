using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Metro.Data.Entities;

namespace Metro.Data.Infrastructure.Configuration.ConfigurationEntity
{
    /// <summary>
    /// Конфигурация для создания конфигураций модели
    /// </summary>
    internal class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        /// <summary>
        /// Создает конфигурацию для описания методанных для сопостовления сущности модели <see cref="Route"/> и сущности в БД
        /// </summary>
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType(nameof(Int32)).IsRequired().ValueGeneratedNever();
            builder.HasOne(m => m.StartStation);
            builder.HasOne(m => m.FinishStation);

            builder.Property(m => m.Length).IsRequired();
            builder.Property(m => m.Time).IsRequired();
        }
    }
}
