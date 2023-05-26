﻿// <auto-generated />
using System;
using Medical_Athena_Calendly.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medical_Athena_Calendly.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230526072735_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Medical_Athena_Calendly.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Medical_Athena_Calendly.ViewModel.Athena.PatientModel", b =>
                {
                    b.Property<string>("patientid")
                        .HasColumnType("text");

                    b.Property<string>("address1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("agriculturalworker")
                        .HasColumnType("integer");

                    b.Property<int?>("agriculturalworkertype")
                        .HasColumnType("integer");

                    b.Property<string>("altfirstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("assignedsexatbirth")
                        .HasColumnType("integer");

                    b.Property<int?>("caresummarydeliverypreference")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("clinicalordertypegroupid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("consenttocall")
                        .HasColumnType("boolean");

                    b.Property<bool>("consenttotext")
                        .HasColumnType("boolean");

                    b.Property<string>("contacthomephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactmobilephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("contactname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("contactpreference")
                        .HasColumnType("integer");

                    b.Property<bool>("contactpreference_announcement_email")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_announcement_phone")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_announcement_sms")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_appointment_email")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_appointment_phone")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_appointment_sms")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_billing_email")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_billing_phone")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_billing_sms")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_lab_email")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_lab_phone")
                        .HasColumnType("boolean");

                    b.Property<bool>("contactpreference_lab_sms")
                        .HasColumnType("boolean");

                    b.Property<int>("contactrelationship")
                        .HasColumnType("integer");

                    b.Property<string>("countrycode3166")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("deceaseddate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("defaultpharmacyncpdpid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("departmentid")
                        .HasColumnType("integer");

                    b.Property<string>("dob")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("donotcallyn")
                        .HasColumnType("boolean");

                    b.Property<string>("driverslicenseexpirationdate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("driverslicensenumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("driverslicensestateid")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("employerid")
                        .HasColumnType("integer");

                    b.Property<string>("employerphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ethnicitycode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ethnicitycodes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("genderidentity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("genderidentityother")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantoraddress1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantoraddress2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("guarantoraddresssameaspatient")
                        .HasColumnType("boolean");

                    b.Property<string>("guarantorcity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorcountrycode3166")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantordob")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantoremail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("guarantoremployerid")
                        .HasColumnType("integer");

                    b.Property<string>("guarantorfirstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorlastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantormiddlename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorrelationshiptopatient")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorssn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorstate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorsuffix")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guarantorzip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guardianfirstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guardianlastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guardianmiddlename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("guardiansuffix")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("hasmobileyn")
                        .HasColumnType("boolean");

                    b.Property<bool>("homeboundyn")
                        .HasColumnType("boolean");

                    b.Property<int>("homeless")
                        .HasColumnType("integer");

                    b.Property<int>("homelesstype")
                        .HasColumnType("integer");

                    b.Property<string>("homephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ignorerestrictions")
                        .HasColumnType("boolean");

                    b.Property<string>("industrycode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("language6392code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("maritalstatus")
                        .HasColumnType("integer");

                    b.Property<string>("middlename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mobilecarrierid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("mobilephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nextkinname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nextkinphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("nextkinrelationship")
                        .HasColumnType("integer");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("occupationcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("onlinestatementonlyyn")
                        .HasColumnType("boolean");

                    b.Property<bool>("portalaccessgiven")
                        .HasColumnType("boolean");

                    b.Property<string>("povertylevelcalculated")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("povertylevelfamilysize")
                        .HasColumnType("integer");

                    b.Property<bool>("povertylevelfamilysizedeclined")
                        .HasColumnType("boolean");

                    b.Property<bool>("povertylevelincomedeclined")
                        .HasColumnType("boolean");

                    b.Property<int>("povertylevelincomepayperiod")
                        .HasColumnType("integer");

                    b.Property<int>("povertylevelincomeperpayperiod")
                        .HasColumnType("integer");

                    b.Property<bool>("povertylevelincomerangedeclined")
                        .HasColumnType("boolean");

                    b.Property<string>("preferredname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("preferredpronouns")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("primarydepartmentid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("primaryproviderid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("publichousing")
                        .HasColumnType("integer");

                    b.Property<int>("race")
                        .HasColumnType("integer");

                    b.Property<string>("referralsourceid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("referralsourceother")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("schoolbasedhealthcenter")
                        .HasColumnType("integer");

                    b.Property<int>("sex")
                        .HasColumnType("integer");

                    b.Property<string>("sexualorientation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sexualorientationother")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("showerrormessage")
                        .HasColumnType("boolean");

                    b.Property<string>("ssn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("suffix")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("veteran")
                        .HasColumnType("integer");

                    b.Property<string>("workphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("patientid");

                    b.ToTable("PatientModel");
                });
#pragma warning restore 612, 618
        }
    }
}
