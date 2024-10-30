using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class SensorCategoryEntityTypeConfiguration : IEntityTypeConfiguration<SensorCategory>
{
    public void Configure(EntityTypeBuilder<SensorCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnType("varchar(32)").IsRequired();



        #region Relations

        builder.HasMany(x => x.Sensors)
            .WithOne(x => x.SensorCategory)
            .HasForeignKey(x => x.SensorCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
    
}