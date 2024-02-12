﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poort8.Dataspace.OrganizationRegistry;

#nullable disable

namespace Poort8.Dataspace.CoreManager.Migrations
{
    [DbContext(typeof(OrganizationContext))]
    [Migration("20240206150536_iShareOrganisationModel")]
    partial class iShareOrganisationModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Agreement", b =>
                {
                    b.Property<string>("AgreementId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool?>("CompliancyVerified")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ContractFile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("DataspaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateOfExpiry")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfSigning")
                        .HasColumnType("date");

                    b.Property<string>("Framework")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashOfSignedContract")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgreementId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("Agreement");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.AuditRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditRecords");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.AuthorizationRegistry", b =>
                {
                    b.Property<string>("AuthorizationRegistryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorizationRegistryOrganizationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizationRegistryUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataspaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorizationRegistryId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("AuthorizationRegistry");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Certificate", b =>
                {
                    b.Property<string>("CertificateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("CertificateFile")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateOnly>("EnabledFrom")
                        .HasColumnType("date");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CertificateId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Organization", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("OrOrganization", (string)null);
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.OrganizationRole", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CompliancyVerified")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("LegalAdherence")
                        .HasColumnType("bit");

                    b.Property<string>("LoA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("RoleId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("OrganizationRole");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Property", b =>
                {
                    b.Property<string>("PropertyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Service", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Agreement", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("Agreements")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.AuthorizationRegistry", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("AuthorizationRegistries")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Certificate", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("Certificates")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Organization", b =>
                {
                    b.OwnsOne("Poort8.Dataspace.OrganizationRegistry.AdditionalDetails", "AdditionalDetails", b1 =>
                        {
                            b1.Property<string>("OrganizationIdentifier")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("CapabilitiesUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CompanyEmail")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CompanyPhone")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CountriesOfOperation")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LogoUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool?>("PubliclyPublishable")
                                .HasColumnType("bit");

                            b1.Property<string>("Sectors")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Tags")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WebsiteUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrganizationIdentifier");

                            b1.ToTable("OrOrganization");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationIdentifier");
                        });

                    b.OwnsOne("Poort8.Dataspace.OrganizationRegistry.Adherence", "Adherence", b1 =>
                        {
                            b1.Property<string>("OrganizationIdentifier")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateOnly>("ValidFrom")
                                .HasColumnType("date");

                            b1.Property<DateOnly>("ValidUntil")
                                .HasColumnType("date");

                            b1.HasKey("OrganizationIdentifier");

                            b1.ToTable("OrOrganization");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationIdentifier");
                        });

                    b.Navigation("AdditionalDetails")
                        .IsRequired();

                    b.Navigation("Adherence")
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.OrganizationRole", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("Roles")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Property", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("Properties")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Service", b =>
                {
                    b.HasOne("Poort8.Dataspace.OrganizationRegistry.Organization", null)
                        .WithMany("Services")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.OrganizationRegistry.Organization", b =>
                {
                    b.Navigation("Agreements");

                    b.Navigation("AuthorizationRegistries");

                    b.Navigation("Certificates");

                    b.Navigation("Properties");

                    b.Navigation("Roles");

                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
