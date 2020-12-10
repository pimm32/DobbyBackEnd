using Dobby.Core.Models;
using Dobby.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Data
{
    public class DobbyDbContext: DbContext
    {
        public DbSet<Bericht> Berichten { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<GebruikerContact> GebruikerContacten { get; set; }
        public DbSet<Partij> Partijen { get; set; }
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Zet> Zetten { get; set; }

        public DobbyDbContext(DbContextOptions<DobbyDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new PartijConfiguration());
            builder
                .ApplyConfiguration(new ZetConfiguration());
            builder
                .ApplyConfiguration(new BerichtConfiguration());
            builder
                .ApplyConfiguration(new ChatConfiguration());
            builder
                .ApplyConfiguration(new GebruikerConfiguration());
            builder
                .ApplyConfiguration(new GebruikerContactConfiguration());
            builder
                .ApplyConfiguration(new SpelerConfiguration());
        }

    }
}
