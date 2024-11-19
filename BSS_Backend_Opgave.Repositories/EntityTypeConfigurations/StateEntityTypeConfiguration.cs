using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class StateEntityTypeConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StateType).HasColumnType("varchar(32)");


        #region Indexes

        builder.HasIndex(x => x.StateType);        

        #endregion
        

        #region Relations

        builder.HasOne(x => x.EventLog)
            .WithOne(x => x.State)
            .HasForeignKey<State>(x => x.EventLogId);

        #endregion
    }
}