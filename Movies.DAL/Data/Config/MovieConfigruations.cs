using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Data.Config
{
    public class MovieConfigruations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(M => M.Title)
                    .IsRequired()
                    .HasMaxLength(250);

            builder.Property(M=>M.StoryLine)
                   .HasMaxLength(2500);

            builder.HasOne(M => M.Genre)
                   .WithMany();
                   //.HasForeignKey(nameof(Movie.GenreId));
        }
    }
}
