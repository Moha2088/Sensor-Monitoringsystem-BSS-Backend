using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class EventLogEntityTypeConfiguration : IEntityTypeConfiguration<EventLog>
{
    public void Configure(EntityTypeBuilder<EventLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EventTime).HasColumnType("datetimeoffset");



        #region Relations

        builder.HasOne(x => x.State)
            .WithOne(x => x.EventLog);

        #endregion
    }
}