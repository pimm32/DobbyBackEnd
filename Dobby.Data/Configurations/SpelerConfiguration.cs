using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class SpelerConfiguration : IEntityTypeConfiguration<Speler>
    {
        public void Configure(EntityTypeBuilder<Speler> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.RatingAanBeginVanWedstrijd)
                .IsRequired();
            builder
                .HasOne(m => m.Partij)
                .WithMany(p => p.Spelers)
                .HasForeignKey(m => m.PartijId);
            builder
                .HasOne(m => m.Gebruiker)
                .WithMany(g => g.Spelers)
                .HasForeignKey(m => m.GebruikerId);

            builder
                .ToTable("Spelers");
        }
    }
}
