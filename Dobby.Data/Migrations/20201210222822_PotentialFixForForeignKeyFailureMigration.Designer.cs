﻿// <auto-generated />
using System;
using Dobby.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dobby.Data.Migrations
{
    [DbContext(typeof(DobbyDbContext))]
    [Migration("20201210222822_PotentialFixForForeignKeyFailureMigration")]
    partial class PotentialFixForForeignKeyFailureMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dobby.Core.Models.Bericht", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AfzenderId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AfzenderId");

                    b.HasIndex("ChatId");

                    b.ToTable("Berichten");
                });

            modelBuilder.Entity("Dobby.Core.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PartijId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartijId")
                        .IsUnique();

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Dobby.Core.Models.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gebruikersnaam")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1200);

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("Dobby.Core.Models.GebruikerContact", b =>
                {
                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.HasKey("GebruikerId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("GebruikerContacten");
                });

            modelBuilder.Entity("Dobby.Core.Models.Partij", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("SpeeltempoFisherSeconden")
                        .HasColumnType("int");

                    b.Property<int>("SpeeltempoMinuten")
                        .HasColumnType("int");

                    b.Property<int>("TijdWitSpeler")
                        .HasColumnType("int");

                    b.Property<int>("TijdZwartSpeler")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Partijen");
                });

            modelBuilder.Entity("Dobby.Core.Models.Speler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<string>("KleurSpeler")
                        .HasColumnType("text");

                    b.Property<int>("PartijId")
                        .HasColumnType("int");

                    b.Property<int>("RatingAanBeginVanWedstrijd")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("PartijId");

                    b.ToTable("Spelers");
                });

            modelBuilder.Entity("Dobby.Core.Models.Zet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeginVeld")
                        .HasColumnType("int");

                    b.Property<int>("EindVeld")
                        .HasColumnType("int");

                    b.Property<int>("PartijId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartijId");

                    b.ToTable("Zetten");
                });

            modelBuilder.Entity("Dobby.Core.Models.Bericht", b =>
                {
                    b.HasOne("Dobby.Core.Models.Gebruiker", "Afzender")
                        .WithMany()
                        .HasForeignKey("AfzenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dobby.Core.Models.Chat", "Chat")
                        .WithMany("Berichten")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dobby.Core.Models.Chat", b =>
                {
                    b.HasOne("Dobby.Core.Models.Partij", "Partij")
                        .WithOne("Chat")
                        .HasForeignKey("Dobby.Core.Models.Chat", "PartijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dobby.Core.Models.GebruikerContact", b =>
                {
                    b.HasOne("Dobby.Core.Models.Gebruiker", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dobby.Core.Models.Gebruiker", "Gebruiker")
                        .WithMany("Contacten")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dobby.Core.Models.Partij", b =>
                {
                    b.HasOne("Dobby.Core.Models.Gebruiker", null)
                        .WithMany("Partijen")
                        .HasForeignKey("GebruikerId");
                });

            modelBuilder.Entity("Dobby.Core.Models.Speler", b =>
                {
                    b.HasOne("Dobby.Core.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId");

                    b.HasOne("Dobby.Core.Models.Partij", "Partij")
                        .WithMany("Spelers")
                        .HasForeignKey("PartijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dobby.Core.Models.Zet", b =>
                {
                    b.HasOne("Dobby.Core.Models.Partij", "Partij")
                        .WithMany("Zetten")
                        .HasForeignKey("PartijId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
