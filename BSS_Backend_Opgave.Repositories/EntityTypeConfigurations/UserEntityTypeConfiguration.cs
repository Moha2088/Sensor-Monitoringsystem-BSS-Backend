using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Models.User>
{
    public void Configure(EntityTypeBuilder<Models.User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnType("varchar(32)");
        builder.Property(x => x.Password).HasColumnType("varchar(32)");
        builder.Property(x => x.Email).HasColumnType("varchar(32)");



        #region Relations

        builder.HasOne<Organisation>()
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.OrganisationId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion
    }
}
