using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class PartijConfiguration: IEntityTypeConfiguration<Partij>
    {
        public void Configure(EntityTypeBuilder<Partij> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.SpeeltempoMinuten)
                .IsRequired();
            builder
                .Property(m => m.SpeeltempoFisherSeconden)
                .IsRequired();

            builder
                .Property(m => m.Uitslag)
                .HasDefaultValue("0");
           
            builder
                .ToTable("Partijen");
        }
    }
}
