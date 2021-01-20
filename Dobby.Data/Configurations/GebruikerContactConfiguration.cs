using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class GebruikerContactConfiguration : IEntityTypeConfiguration<GebruikerContact>
    {
        public void Configure(EntityTypeBuilder<GebruikerContact> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .HasIndex(m => new { m.GebruikerId, m.ContactId })
                .IsUnique();

            builder
                .HasOne(m => m.Gebruiker)
                .WithMany(a => a.Contacten)
                .HasForeignKey(m => m.GebruikerId);

            builder
                .ToTable("GebruikerContacten");
        }
    }
}
