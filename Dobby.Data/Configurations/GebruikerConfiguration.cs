using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.Gebruikersnaam)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Rating)
                .HasDefaultValue(1200);

            builder
                .ToTable("Gebruikers");
        }
    }
}
