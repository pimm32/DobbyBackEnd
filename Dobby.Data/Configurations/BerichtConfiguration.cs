using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class BerichtConfiguration: IEntityTypeConfiguration<Bericht>
    {
        public void Configure(EntityTypeBuilder<Bericht> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.Tekst)
                .IsRequired();
            builder
                .Property(m => m.AfzenderId)
                .IsRequired();
            builder
                .Property(m => m.Datum)
                .HasDefaultValue(new DateTime())
                .IsRequired();

            builder
                .ToTable("Berichten");
        }
    }
}
