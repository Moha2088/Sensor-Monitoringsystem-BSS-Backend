

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BSS_Backend_Opgave.Models;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class SensorEntityTypeConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnType("varchar(32)");
        builder.Property(x => x.Location).HasColumnType("varchar(32)");
        builder.Property(x => x.Name).HasColumnType("varchar(32)");



        #region Relations

        builder.HasOne(x => x.Organisation)
            .WithMany(x => x.Sensor)
            .HasForeignKey(x => x.OrganisationId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}