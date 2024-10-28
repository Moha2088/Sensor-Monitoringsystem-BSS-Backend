using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations
{
    public class OrganisationEntityTypeConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(32)");



            #region Relations

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Organisation)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Sensor)
                .WithOne(x => x.Organisation)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
