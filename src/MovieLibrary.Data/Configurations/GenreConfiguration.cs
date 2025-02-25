using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Data.Configurations;

public class GenreConfiguration : BaseEntityConfiguration<Genre>
{
    public override void Configure(EntityTypeBuilder<Genre> builder)
    {
        base.Configure(builder);

        builder.ToTable("Genres");

        builder.Property(g => g.Name)
            .HasMaxLength(24)
            .IsRequired();
    }
}