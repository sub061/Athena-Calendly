using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical_Athena_Calendly.Migrations
{
    /// <inheritdoc />
    public partial class addPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpiration",
                table: "user",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpiration",
                table: "user");

            migrationBuilder.CreateTable(
                name: "PatientModel",
                columns: table => new
                {
                    patientid = table.Column<string>(type: "text", nullable: false),
                    address1 = table.Column<string>(type: "text", nullable: false),
                    address2 = table.Column<string>(type: "text", nullable: false),
                    agriculturalworker = table.Column<int>(type: "integer", nullable: true),
                    agriculturalworkertype = table.Column<int>(type: "integer", nullable: true),
                    altfirstname = table.Column<string>(type: "text", nullable: false),
                    assignedsexatbirth = table.Column<int>(type: "integer", nullable: true),
                    caresummarydeliverypreference = table.Column<int>(type: "integer", nullable: true),
                    city = table.Column<string>(type: "text", nullable: false),
                    clinicalordertypegroupid = table.Column<string>(type: "text", nullable: false),
                    consenttocall = table.Column<bool>(type: "boolean", nullable: false),
                    consenttotext = table.Column<bool>(type: "boolean", nullable: false),
                    contacthomephone = table.Column<string>(type: "text", nullable: false),
                    contactmobilephone = table.Column<string>(type: "text", nullable: false),
                    contactname = table.Column<string>(type: "text", nullable: false),
                    contactpreference = table.Column<int>(type: "integer", nullable: false),
                    contactpreference_announcement_email = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_announcement_phone = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_announcement_sms = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_appointment_email = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_appointment_phone = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_appointment_sms = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_billing_email = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_billing_phone = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_billing_sms = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_lab_email = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_lab_phone = table.Column<bool>(type: "boolean", nullable: false),
                    contactpreference_lab_sms = table.Column<bool>(type: "boolean", nullable: false),
                    contactrelationship = table.Column<int>(type: "integer", nullable: false),
                    countrycode3166 = table.Column<string>(type: "text", nullable: false),
                    deceaseddate = table.Column<string>(type: "text", nullable: false),
                    defaultpharmacyncpdpid = table.Column<string>(type: "text", nullable: false),
                    departmentid = table.Column<int>(type: "integer", nullable: false),
                    dob = table.Column<string>(type: "text", nullable: false),
                    donotcallyn = table.Column<bool>(type: "boolean", nullable: false),
                    driverslicenseexpirationdate = table.Column<string>(type: "text", nullable: false),
                    driverslicensenumber = table.Column<string>(type: "text", nullable: false),
                    driverslicensestateid = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    employerid = table.Column<int>(type: "integer", nullable: false),
                    employerphone = table.Column<string>(type: "text", nullable: false),
                    ethnicitycode = table.Column<string>(type: "text", nullable: false),
                    ethnicitycodes = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    genderidentity = table.Column<string>(type: "text", nullable: false),
                    genderidentityother = table.Column<string>(type: "text", nullable: false),
                    guarantoraddress1 = table.Column<string>(type: "text", nullable: false),
                    guarantoraddress2 = table.Column<string>(type: "text", nullable: false),
                    guarantoraddresssameaspatient = table.Column<bool>(type: "boolean", nullable: false),
                    guarantorcity = table.Column<string>(type: "text", nullable: false),
                    guarantorcountrycode3166 = table.Column<string>(type: "text", nullable: false),
                    guarantordob = table.Column<string>(type: "text", nullable: false),
                    guarantoremail = table.Column<string>(type: "text", nullable: false),
                    guarantoremployerid = table.Column<int>(type: "integer", nullable: false),
                    guarantorfirstname = table.Column<string>(type: "text", nullable: false),
                    guarantorlastname = table.Column<string>(type: "text", nullable: false),
                    guarantormiddlename = table.Column<string>(type: "text", nullable: false),
                    guarantorphone = table.Column<string>(type: "text", nullable: false),
                    guarantorrelationshiptopatient = table.Column<string>(type: "text", nullable: false),
                    guarantorssn = table.Column<string>(type: "text", nullable: false),
                    guarantorstate = table.Column<string>(type: "text", nullable: false),
                    guarantorsuffix = table.Column<string>(type: "text", nullable: false),
                    guarantorzip = table.Column<string>(type: "text", nullable: false),
                    guardianfirstname = table.Column<string>(type: "text", nullable: false),
                    guardianlastname = table.Column<string>(type: "text", nullable: false),
                    guardianmiddlename = table.Column<string>(type: "text", nullable: false),
                    guardiansuffix = table.Column<string>(type: "text", nullable: false),
                    hasmobileyn = table.Column<bool>(type: "boolean", nullable: false),
                    homeboundyn = table.Column<bool>(type: "boolean", nullable: false),
                    homeless = table.Column<int>(type: "integer", nullable: false),
                    homelesstype = table.Column<int>(type: "integer", nullable: false),
                    homephone = table.Column<string>(type: "text", nullable: false),
                    ignorerestrictions = table.Column<bool>(type: "boolean", nullable: false),
                    industrycode = table.Column<string>(type: "text", nullable: false),
                    language6392code = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    maritalstatus = table.Column<int>(type: "integer", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    mobilecarrierid = table.Column<string>(type: "text", nullable: false),
                    mobilephone = table.Column<string>(type: "text", nullable: false),
                    nextkinname = table.Column<string>(type: "text", nullable: false),
                    nextkinphone = table.Column<string>(type: "text", nullable: false),
                    nextkinrelationship = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false),
                    occupationcode = table.Column<string>(type: "text", nullable: false),
                    onlinestatementonlyyn = table.Column<bool>(type: "boolean", nullable: false),
                    portalaccessgiven = table.Column<bool>(type: "boolean", nullable: false),
                    povertylevelcalculated = table.Column<string>(type: "text", nullable: false),
                    povertylevelfamilysize = table.Column<int>(type: "integer", nullable: false),
                    povertylevelfamilysizedeclined = table.Column<bool>(type: "boolean", nullable: false),
                    povertylevelincomedeclined = table.Column<bool>(type: "boolean", nullable: false),
                    povertylevelincomepayperiod = table.Column<int>(type: "integer", nullable: false),
                    povertylevelincomeperpayperiod = table.Column<int>(type: "integer", nullable: false),
                    povertylevelincomerangedeclined = table.Column<bool>(type: "boolean", nullable: false),
                    preferredname = table.Column<string>(type: "text", nullable: false),
                    preferredpronouns = table.Column<string>(type: "text", nullable: false),
                    primarydepartmentid = table.Column<string>(type: "text", nullable: false),
                    primaryproviderid = table.Column<string>(type: "text", nullable: false),
                    publichousing = table.Column<int>(type: "integer", nullable: false),
                    race = table.Column<int>(type: "integer", nullable: false),
                    referralsourceid = table.Column<string>(type: "text", nullable: false),
                    referralsourceother = table.Column<string>(type: "text", nullable: false),
                    schoolbasedhealthcenter = table.Column<int>(type: "integer", nullable: false),
                    sex = table.Column<int>(type: "integer", nullable: false),
                    sexualorientation = table.Column<string>(type: "text", nullable: false),
                    sexualorientationother = table.Column<string>(type: "text", nullable: false),
                    showerrormessage = table.Column<bool>(type: "boolean", nullable: false),
                    ssn = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    suffix = table.Column<string>(type: "text", nullable: false),
                    veteran = table.Column<int>(type: "integer", nullable: true),
                    workphone = table.Column<string>(type: "text", nullable: false),
                    zip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientModel", x => x.patientid);
                });
        }
    }
}
