﻿// <auto-generated />
using System;
using Account.Microservice.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Account.Microservice.Persistence.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20220503065440_seed_roles")]
    partial class seed_roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Account.Microservice.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsThirdParty")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("OTP")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("ThirdPartyProvider")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Account.Microservice.Domain.Entities.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("Account.Microservice.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateUserId = "builder.seed",
                            CreatedDate = new DateTime(2022, 5, 3, 8, 54, 39, 908, DateTimeKind.Local).AddTicks(3792),
                            Description = "An administrator role normaly does everything",
                            IsActive = true,
                            ModifyDate = new DateTime(2022, 5, 3, 8, 54, 39, 912, DateTimeKind.Local).AddTicks(8005),
                            ModifyUserId = "builder.seed",
                            RoleName = "Admin",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateUserId = "builder.seed",
                            CreatedDate = new DateTime(2022, 5, 3, 8, 54, 39, 912, DateTimeKind.Local).AddTicks(8566),
                            Description = "An student role makes applications to ITS 4.0",
                            IsActive = true,
                            ModifyDate = new DateTime(2022, 5, 3, 8, 54, 39, 912, DateTimeKind.Local).AddTicks(8570),
                            ModifyUserId = "builder.seed",
                            RoleName = "Student",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreateUserId = "builder.seed",
                            CreatedDate = new DateTime(2022, 5, 3, 8, 54, 39, 912, DateTimeKind.Local).AddTicks(8572),
                            Description = "A clerk is responsible for creating subject and modifying the subjects based on their Faculty Subject Aps requirements",
                            IsActive = true,
                            ModifyDate = new DateTime(2022, 5, 3, 8, 54, 39, 912, DateTimeKind.Local).AddTicks(8573),
                            ModifyUserId = "builder.seed",
                            RoleName = "Clerk",
                            StatusId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
