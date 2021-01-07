using Dobby.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data.Configurations
{
    public class ZetConfiguration: IEntityTypeConfiguration<Zet>
    {
       public void Configure(EntityTypeBuilder<Zet> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.BeginVeld)
                .IsRequired();
            builder
                .Property(m => m.EindVeld)
                .IsRequired();
            builder
                .Property(m => m.StandNaZet)
                .IsRequired();
            builder
                .HasOne(m => m.Partij)
                .WithMany(a => a.Zetten)
                .HasForeignKey(m => m.PartijId);
            builder
                .ToTable("Zetten");
        }
    }
}
