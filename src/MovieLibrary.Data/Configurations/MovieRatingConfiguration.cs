using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLibrary.Core.Models;

namespace MovieLibrary.Data.Configurations;

public class MovieRatingConfiguration : BaseEntityConfiguration<MovieRating>
{
    public override void Configure(EntityTypeBuilder<MovieRating> builder)
    {
        base.Configure(builder);

        builder.ToTable("MovieRatings");

        builder.HasOne<Movie>()
            .WithMany(m => m.MovieRatings)
            .HasForeignKey(mr => mr.MovieId)
            .IsRequired();

        builder.Property(mr => mr.Rate)
            .IsRequired();

        builder.HasIndex(mr => new { mr.UserId, mr.MovieId })
            .IsUnique();
    }
}