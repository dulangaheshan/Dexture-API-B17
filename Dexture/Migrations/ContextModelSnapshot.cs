﻿// <auto-generated />
using System;
using Dexture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dexture.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dexture.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Nic");

                    b.Property<string>("Password");

                    b.Property<string>("PersonalAddress");

                    b.HasKey("AdminId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dexture.Models.AgricultureOfficer", b =>
                {
                    b.Property<int>("AgricultureOfficerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Nic");

                    b.Property<string>("Password");

                    b.Property<string>("PersonalAddress");

                    b.HasKey("AgricultureOfficerId");

                    b.ToTable("AgricultureOfficers");
                });

            modelBuilder.Entity("Dexture.Models.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Nic");

                    b.Property<string>("Password");

                    b.Property<string>("PersonalAddress");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Dexture.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("GramaNiladariDivision");

                    b.Property<bool>("IsAccepted");

                    b.Property<string>("LastName");

                    b.Property<string>("Nic");

                    b.Property<string>("Password");

                    b.Property<string>("PersonalAddress");

                    b.HasKey("FarmerId");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("Dexture.Models.Land", b =>
                {
                    b.Property<int>("LandId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FarmerId");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<double>("Size");

                    b.HasKey("LandId");

                    b.HasIndex("FarmerId");

                    b.ToTable("Lands");
                });

            modelBuilder.Entity("Dexture.Models.Repository.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("HarvestID");

                    b.Property<double>("Price");

                    b.Property<double>("Quantity");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.HasKey("AuctionID");

                    b.HasIndex("HarvestID")
                        .IsUnique();

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Dexture.Models.Repository.FutureCultivation", b =>
                {
                    b.Property<int>("CultivationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<int>("FarmerId");

                    b.Property<string>("Name");

                    b.Property<double>("Quantity");

                    b.HasKey("CultivationId");

                    b.HasIndex("FarmerId");

                    b.ToTable("FutureCultivations");
                });

            modelBuilder.Entity("Dexture.Models.Repository.Generate", b =>
                {
                    b.Property<int>("GenerateId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CultivationId");

                    b.Property<int?>("HarvestId");

                    b.HasKey("GenerateId");

                    b.HasIndex("CultivationId");

                    b.HasIndex("HarvestId");

                    b.ToTable("Generates");
                });

            modelBuilder.Entity("Dexture.Models.Repository.Harvest", b =>
                {
                    b.Property<int>("HarvestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllQuantity");

                    b.Property<string>("Name");

                    b.Property<string>("SellingQuantity");

                    b.HasKey("HarvestId");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("Dexture.Models.Repository.Prediction", b =>
                {
                    b.Property<int>("PredictionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<double>("DemandRate");

                    b.Property<int?>("FarmerId");

                    b.Property<int?>("FutureCultivationsCultivationId");

                    b.Property<int?>("HarvestsHarvestId");

                    b.Property<double>("Quantity");

                    b.HasKey("PredictionID");

                    b.HasIndex("FarmerId");

                    b.HasIndex("FutureCultivationsCultivationId");

                    b.HasIndex("HarvestsHarvestId");

                    b.ToTable("predictions");
                });

            modelBuilder.Entity("Dexture.Models.Land", b =>
                {
                    b.HasOne("Dexture.Models.Farmer", "Farmers")
                        .WithMany()
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dexture.Models.Repository.Auction", b =>
                {
                    b.HasOne("Dexture.Models.Repository.Harvest", "Harvest")
                        .WithOne("Auction")
                        .HasForeignKey("Dexture.Models.Repository.Auction", "HarvestID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dexture.Models.Repository.FutureCultivation", b =>
                {
                    b.HasOne("Dexture.Models.Farmer", "Farmers")
                        .WithMany("FutureCultivations")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dexture.Models.Repository.Generate", b =>
                {
                    b.HasOne("Dexture.Models.Repository.FutureCultivation", "FutureCultivations")
                        .WithMany("generates")
                        .HasForeignKey("CultivationId");

                    b.HasOne("Dexture.Models.Repository.Harvest", "Harvests")
                        .WithMany("generates")
                        .HasForeignKey("HarvestId");
                });

            modelBuilder.Entity("Dexture.Models.Repository.Prediction", b =>
                {
                    b.HasOne("Dexture.Models.Farmer")
                        .WithMany("Lands")
                        .HasForeignKey("FarmerId");

                    b.HasOne("Dexture.Models.Repository.FutureCultivation", "FutureCultivations")
                        .WithMany()
                        .HasForeignKey("FutureCultivationsCultivationId");

                    b.HasOne("Dexture.Models.Repository.Harvest", "Harvests")
                        .WithMany()
                        .HasForeignKey("HarvestsHarvestId");
                });
#pragma warning restore 612, 618
        }
    }
}
