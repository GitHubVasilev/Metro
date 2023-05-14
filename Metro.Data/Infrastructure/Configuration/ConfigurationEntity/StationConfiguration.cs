using Metro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Metro.Data.Infrastructure.Configuration.ConfigurationEntity
{
    /// <summary>
    /// Конфигурация для создания конфигураций модели
    /// </summary>
    internal class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        /// <summary>
        /// Создает конфигурацию для описания методанных для сопостовления сущности модели <see cref="Branch"/> и сущности в БД
        /// </summary>
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable("Stations");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnType(nameof(Int32)).IsRequired().ValueGeneratedNever();
            //builder.HasKey(m => m.BranchId);
            //builder.Property(m => m.BranchId).HasColumnType(nameof(Int32));
            builder.HasOne(m => m.Branch);

            builder.Property(m => m.Name).HasMaxLength(64);
        }
    }
}
