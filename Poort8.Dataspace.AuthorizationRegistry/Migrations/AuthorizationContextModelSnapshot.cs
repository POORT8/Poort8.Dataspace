﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Poort8.Dataspace.AuthorizationRegistry;

#nullable disable

namespace Poort8.Dataspace.AuthorizationRegistry.Migrations
{
    [DbContext(typeof(AuthorizationContext))]
    partial class AuthorizationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("FeatureProduct", b =>
                {
                    b.Property<string>("FeaturesFeatureId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("FeaturesFeatureId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FeatureProduct");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee+EmployeeProperty", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeProperty");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature", b =>
                {
                    b.Property<string>("FeatureId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FeatureId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature+FeatureProperty", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("FeatureId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureProperty");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("TEXT");

                    b.Property<string>("InvoicingContact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Representative")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Identifier");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization+OrganizationProperty", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrganizationIdentifier")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("OrganizationIdentifier");

                    b.ToTable("OrganizationProperty");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Policy", b =>
                {
                    b.Property<string>("PolicyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Expiration")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IssuedAt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IssuerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("NotBefore")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UseCase")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PolicyId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Policy+PolicyProperty", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PolicyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyProperty");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Provider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Product+ProductProperty", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsIdentifier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductProperty");
                });

            modelBuilder.Entity("FeatureProduct", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization", null)
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee+EmployeeProperty", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee", null)
                        .WithMany("Properties")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature+FeatureProperty", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature", null)
                        .WithMany("Properties")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization+OrganizationProperty", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization", null)
                        .WithMany("Properties")
                        .HasForeignKey("OrganizationIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Policy+PolicyProperty", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Policy", null)
                        .WithMany("Properties")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Product+ProductProperty", b =>
                {
                    b.HasOne("Poort8.Dataspace.AuthorizationRegistry.Entities.Product", null)
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Employee", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Feature", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Organization", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Policy", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Poort8.Dataspace.AuthorizationRegistry.Entities.Product", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
