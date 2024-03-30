using Final_SophieTravelManagement.Domain.Entities;
using Final_SophieTravelManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Infrastructure.EF.Config
{
internal class WriteConfiguration :
    IEntityTypeConfiguration<TravelerCheckList>,
    IEntityTypeConfiguration<TravelerItem>
{
    public void Configure(EntityTypeBuilder<TravelerCheckList> builder)
    {
        builder.HasKey(x => x.Id);

        var destinationConverter =
            new ValueConverter<TravelerCheckListDestination, string>(
                x => x.ToString(), x => TravelerCheckListDestination.Create(x));

        var packingListNameConvertor =
            new ValueConverter<TravelerCheckListName, string>(
                x => x.Value, x => new TravelerCheckListName(x));

        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TravelerCheckListId(x));

        builder
            .Property(typeof(TravelerCheckListDestination), "_destination")
            .HasConversion(destinationConverter)
            .HasColumnName("Destination");

        builder
            .Property(typeof(TravelerCheckListName), "_name")
            .HasConversion(packingListNameConvertor)
            .HasColumnName("Name");

        builder.HasMany(typeof(TravelerItem), "_items");

        builder.ToTable("TravelerCheckList");
    }
    public void Configure(EntityTypeBuilder<TravelerItem> builder)
    {
        builder.Property<Guid>("Id");
        builder.Property(x => x.Name);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.IsTaken);
        builder.ToTable("TravelerItems");
    }
}
}
