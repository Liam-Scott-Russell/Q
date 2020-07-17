﻿// <auto-generated />
using System;
using FarQ_Backend_1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FarQ_Backend_1.Migrations
{
    [DbContext(typeof(FarQContext))]
    partial class FarQContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Q_Backend.Models.Booth", b =>
                {
                    b.Property<int>("BoothID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InterviewerID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Occupied")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Payload")
                        .HasColumnType("TEXT");

                    b.HasKey("BoothID");

                    b.ToTable("Booth");
                });

            modelBuilder.Entity("Q_Backend.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("HelpLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserLink")
                        .HasColumnType("TEXT");

                    b.HasKey("EventID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Q_Backend.Models.EventOrganiser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventIDs")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("EventOrganiser");
                });

            modelBuilder.Entity("Q_Backend.Models.Interviewer", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Desc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Interviewer");
                });

            modelBuilder.Entity("Q_Backend.Models.Pool", b =>
                {
                    b.Property<int>("PoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Booths")
                        .HasColumnType("TEXT");

                    b.Property<int>("QueueID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PoolID");

                    b.ToTable("Pool");
                });

            modelBuilder.Entity("Q_Backend.Models.Queue", b =>
                {
                    b.Property<int>("QueueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserIDs")
                        .HasColumnType("TEXT");

                    b.HasKey("QueueID");

                    b.ToTable("Queue");
                });

            modelBuilder.Entity("Q_Backend.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
