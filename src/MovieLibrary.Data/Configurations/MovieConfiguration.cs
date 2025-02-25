using MovieLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieLibrary.Data.Configurations;

public class MovieConfiguration : BaseEntityConfiguration<Movie>
{
    public override void Configure(EntityTypeBuilder<Movie> builder)
    {
        base.Configure(builder);

        builder.ToTable("Movies");

        builder.Property(m => m.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(m => m.Year)
            .HasColumnType("year");

        builder.Property(m => m.AverageRating)
            .HasColumnType("decimal(3, 2)");

        builder.HasOne<Genre>()
            .WithMany()
            .HasForeignKey(m => m.GenreId)
            .IsRequired();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Year_Range", "[Year] >= 1901 AND [Year] <= 2155 OR [Year] = 0000");
        });
    }
}