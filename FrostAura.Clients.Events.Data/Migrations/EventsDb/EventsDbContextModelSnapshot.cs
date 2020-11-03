﻿// <auto-generated />
using System;
using FrostAura.Clients.Events.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrostAura.Clients.Events.Data.Migrations.EventsDb
{
    [DbContext(typeof(EventsDbContext))]
    partial class EventsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.BookingWindow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplyTagsInclusively")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("HoursInAdvanceBookingsAllowed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BookingWindows");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.BookingWindowTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingWindowId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingWindowId");

                    b.HasIndex("TagId");

                    b.ToTable("BookingWindowTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.ConditionPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("PeriodId");

                    b.ToTable("ConditionPeriods");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.ControlType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ControlTypes");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Durations");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.IfLogic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DurationId")
                        .HasColumnType("int");

                    b.Property<int>("LogicKeyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.HasIndex("LogicKeyId");

                    b.HasIndex("OperatorId");

                    b.ToTable("IfLogic");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.IfLogicTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("IfLogicId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IfLogicId");

                    b.HasIndex("TagId");

                    b.ToTable("IfLogicTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Limit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplyTagsInclusively")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("DurationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.ToTable("Limits");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.LimitTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LimitId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LimitId");

                    b.HasIndex("TagId");

                    b.ToTable("LimitTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.LogicKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ControlTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ControlTypeId");

                    b.ToTable("LogicKeys");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.OrLogic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrLogic");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.OrLogicCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrLogicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("OrLogicId");

                    b.ToTable("OrLogicConditions");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.OrLogicIfLogicGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("IfLogicId")
                        .HasColumnType("int");

                    b.Property<int>("OrLogicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IfLogicId");

                    b.HasIndex("OrLogicId");

                    b.ToTable("OrLogicIfLogicGroups");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.PeriodDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("PeriodId");

                    b.ToTable("PeriodDays");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Space", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("SpaceId");

                    b.ToTable("SpaceAvailability");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceBookingWindow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingWindowId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookingWindowId");

                    b.HasIndex("SpaceId");

                    b.ToTable("SpaceBookingWindows");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("SpaceId");

                    b.ToTable("SpaceConditions");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("LimitId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LimitId");

                    b.HasIndex("SpaceId");

                    b.ToTable("SpaceLimits");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceVisibleToTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("SpaceId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SpaceId");

                    b.HasIndex("TagId");

                    b.ToTable("SpacesVisibleToTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ShareBookerDetails")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.VenueAllowedBookingForTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueAllowedBookingsForTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.VenueAllowedRepeatedBookingForTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("VenueId");

                    b.ToTable("VenueAllowedRepeatedBookingsForTags");
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.BookingWindowTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.BookingWindow", "BookingWindow")
                        .WithMany("BookingWindowTags")
                        .HasForeignKey("BookingWindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("BookingWindowTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.ConditionPeriod", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Condition", "Condition")
                        .WithMany("Periods")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Period", "Period")
                        .WithMany("Periods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.IfLogic", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Duration", "Duration")
                        .WithMany("IfLogic")
                        .HasForeignKey("DurationId");

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.LogicKey", "LogicKey")
                        .WithMany("IfLogic")
                        .HasForeignKey("LogicKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Operator", "Operator")
                        .WithMany("IfLogic")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.IfLogicTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.IfLogic", "IfLogic")
                        .WithMany("IfLogicTags")
                        .HasForeignKey("IfLogicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("IfLogicTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Limit", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Duration", "Duration")
                        .WithMany("Limits")
                        .HasForeignKey("DurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.LimitTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Limit", "Limit")
                        .WithMany("LimitTags")
                        .HasForeignKey("LimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("LimitTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.LogicKey", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.ControlType", "ControlType")
                        .WithMany("LogicKeys")
                        .HasForeignKey("ControlTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.OrLogicCondition", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Condition", "Condition")
                        .WithMany("OrLogicConditions")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.OrLogic", "OrLogic")
                        .WithMany("OrLogicConditions")
                        .HasForeignKey("OrLogicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.OrLogicIfLogicGroup", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.IfLogic", "IfLogic")
                        .WithMany("OrLogicIfLogicGroups")
                        .HasForeignKey("IfLogicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.OrLogic", "OrLogic")
                        .WithMany("OrLogicIfLogicGroups")
                        .HasForeignKey("OrLogicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.PeriodDay", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Day", "Day")
                        .WithMany("PeriodDays")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Period", "Period")
                        .WithMany("PeriodDays")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.Space", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Venue", "Venue")
                        .WithMany("Spaces")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceAvailability", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Day", null)
                        .WithMany("SpaceAvailability")
                        .HasForeignKey("DayId");

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Period", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Space", "Space")
                        .WithMany("SpaceAvailability")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceBookingWindow", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.BookingWindow", "BookingWindow")
                        .WithMany("SpaceBookingWindows")
                        .HasForeignKey("BookingWindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Space", "Space")
                        .WithMany("SpaceBookingWindows")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceCondition", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Condition", "Condition")
                        .WithMany("SpaceConditions")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Space", "Space")
                        .WithMany("SpaceConditions")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceLimit", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Limit", "Limit")
                        .WithMany("SpaceLimits")
                        .HasForeignKey("LimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Space", "Space")
                        .WithMany("SpaceLimits")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.SpaceVisibleToTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Space", "Space")
                        .WithMany("SpacesVisibleToTags")
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("SpacesVisibleToTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.VenueAllowedBookingForTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("VenueAllowedBookingsForTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Venue", "Venue")
                        .WithMany("VenueAllowedBookingsForTags")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FrostAura.Clients.Events.Shared.Models.VenueAllowedRepeatedBookingForTag", b =>
                {
                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Tag", "Tag")
                        .WithMany("VenueAllowedRepeatedBookingsForTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrostAura.Clients.Events.Shared.Models.Venue", "Venue")
                        .WithMany("VenueAllowedRepeatedBookingsForTags")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
