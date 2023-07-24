
using Medical_Athena_Calendly.CommonServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medical_Athena_Calendly.ViewModel.Athena
{
    public class PatientModel
    {
  
        public string patientid { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public Boolean israce { get; set; }
        public Boolean isethnicitycode { get; set; }
        public Boolean islanguage6392code { get; set; }

        public Race race { get; set; }
        //public AgriculturalWorker? agriculturalworker { get; set; }
        //public AgriculturalWorkerType? agriculturalworkertype { get; set; }
        //public string altfirstname { get; set; }
        //public AssignedSexAtBirth assignedsexatbirth { get; set; }
        //public CareSummaryDeliveryPreference? caresummarydeliverypreference { get; set; }
        public string city { get; set; }
        //public string clinicalordertypegroupid { get; set; }
        public Boolean consenttocall { get; set; }
        public Boolean consenttotext { get; set; }
        public string contacthomephone { get; set; }
        public string contactmobilephone { get; set; }
        public string contactname { get; set; }
        //public ContactPreference contactpreference { get; set; }
        //public Boolean contactpreference_announcement_email { get; set; }
        //public Boolean contactpreference_announcement_phone { get; set; }
        //public Boolean contactpreference_announcement_sms { get; set; }
        //public Boolean contactpreference_appointment_email { get; set; }
        //public Boolean contactpreference_appointment_phone { get; set; }
        //public Boolean contactpreference_appointment_sms { get; set; }
        //public Boolean contactpreference_billing_email { get; set; }
        //public Boolean contactpreference_billing_phone { get; set; }
        //public Boolean contactpreference_billing_sms { get; set; }
        //public Boolean contactpreference_lab_email { get; set; }
        //public Boolean contactpreference_lab_phone { get; set; }
        //public Boolean contactpreference_lab_sms { get; set; }
        //public Relationship contactrelationship { get; set; }
        public string countrycode3166 { get; set; }
        //public string deceaseddate { get; set; }
        //public string defaultpharmacyncpdpid { get; set; }
        [Required]
        public int departmentid { get; set; }
        [Required]
        public string dob { get; set; }
        public Boolean donotcallyn { get; set; }
        //public string driverslicenseexpirationdate { get; set; }
        //public string driverslicensenumber { get; set; }
        //public DriversLicenseStateid driverslicensestateid { get; set; }
        public string email { get; set; }
        //public int employerid { get; set; }
        //public string employerphone { get; set; }
        //public string ethnicitycode { get; set; }
        //public string ethnicitycodes { get; set; }
        [Required]
        public string firstname { get; set; }
        public string genderidentity { get; set; }
        public string genderidentityother { get; set; }
        public string guarantoraddress1 { get; set; }
        public string guarantoraddress2 { get; set; }
        public Boolean guarantoraddresssameaspatient { get; set; }
        public string guarantorcity { get; set; }
        public string guarantorcountrycode3166 { get; set; }
        public string guarantordob { get; set; }
        public string guarantoremail { get; set; }
        //public int guarantoremployerid { get; set; }
        //public string guarantorfirstname { get; set; }
        //public string guarantorlastname { get; set; }
        //public string guarantormiddlename { get; set; }
        //public string guarantorphone { get; set; }
        public string guarantorrelationshiptopatient { get; set; } //GuarantorRelationshipToPatient
        //public string guarantorssn { get; set; }
        public string guarantorstate { get; set; }
        //public string guarantorsuffix { get; set; }
        public string guarantorzip { get; set; }
        //public string guardianfirstname { get; set; }
        //public string guardianlastname { get; set; }
        //public string guardianmiddlename { get; set; }
        //public string guardiansuffix { get; set; }
        //public Boolean hasmobileyn { get; set; }
        //public BooleanValue homeboundyn { get; set; }
        //public CommonEnum homeless { get; set; }
        //public HomelessType homelesstype { get; set; }
        public string homephone { get; set; }
        //public Boolean ignorerestrictions { get; set; }
        //public string industrycode { get; set; }
        public string language6392code { get; set; }
        [Required]
        public string lastname { get; set; }
        //public MaritalStatus maritalstatus { get; set; }
        //public string middlename { get; set; }
        //public string mobilecarrierid { get; set; } //MobileCarrierid
        public string mobilephone { get; set; }
        //public string nextkinname { get; set; }
        //public string nextkinphone { get; set; }
        //public Relationship nextkinrelationship { get; set; }
        //public string notes { get; set; }
        //public string occupationcode { get; set; }
        //public Boolean onlinestatementonlyyn { get; set; }
        //public Boolean portalaccessgiven { get; set; }
        //public string povertylevelcalculated { get; set; } //povertylevelcalculated
        //public int povertylevelfamilysize { get; set; }
        //public Boolean povertylevelfamilysizedeclined { get; set; }
        //public Boolean povertylevelincomedeclined { get; set; }
        //public  PovertyLevelIncomepayPeriod povertylevelincomepayperiod { get; set; }
        //public int povertylevelincomeperpayperiod { get; set; }
        //public Boolean povertylevelincomerangedeclined { get; set; }
        //public string preferredname { get; set; }
        //public  string preferredpronouns { get; set; } //preferredpronouns
        //public string primarydepartmentid { get; set; }
        //public string primaryproviderid { get; set; }
        //public CommonEnum publichousing { get; set; }
        //public string referralsourceid { get; set; }
        //public string referralsourceother { get; set; }
        //public CommonEnum schoolbasedhealthcenter { get; set; }
        //public Sex sex { get; set; }
        //public SexualOrientation sexualorientation { get; set; } //sexualorientation
        //public string sexualorientationother { get; set; }
        //public Boolean showerrormessage { get; set; }
        //public string ssn { get; set; }
        public string state { get; set; }
        public PatientStatus status { get; set; } //status 
        //public string suffix { get; set; }
        //public CommonEnum? veteran { get; set; }
        public string workphone { get; set; }
        public string zip { get; set; }




    }

    public enum Race
    {

    }
    public enum AgriculturalWorker
    {
        None,
        N,
        P,
        Y
    }
    public enum AgriculturalWorkerType
    {
        None,
        MIGRANT,
        SEASONAL,
        UNSPECIFIED
    }

    public class AssignedSexAtBirth
    {
        public AssignedSexAtBirthEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }
    public enum AssignedSexAtBirthEnum
    {
        M,
        F,
        N,
        U
    }
    public enum CareSummaryDeliveryPreference
    {
        None,
        PAPER,
        PORTAL
    }

    public class ContactPreference
    {
        public ContactPreferenceEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }

    public class MaritalStatus
    {
        public MaritalStatusEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }

    public class BooleanValue
    {
        public BooleanValueEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }
    public enum ContactPreferenceEnum
    {
        None,
        HOMEPHONE,
        MAIL,
        MOBILEPHONE,
        PORTAL,
        WORKPHONE
    }


    public class Relationship
    {
        public ContactRelationshipEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }

    public enum ContactRelationshipEnum
    {
        CHILD,
        COUSIN,
        FRIEND,
        GUARDIAN,
        OTHER,
        PARENT,
        SIBLING,
        SPOUSE
    }
    public enum DriversLicenseStateid
    {
        None,
        AL,
        AK,
        AZ,
        AR,
        CA,
        CO,
        CT,
        DE,
        FL,
        GA,
        HI,
        ID,
        IL,
        IN,
        IA,
        KS,
        KY,
        LA,
        ME,
        MD,
        MA,
        MI,
        MN,
        MS,
        MO,
        MT,
        NE,
        NV,
        NH,
        NJ,
        NM,
        NY,
        NC,
        ND,
        OH,
        OK,
        OR,
        PA,
        RI,
        SC,
        SD,
        TN,
        TX,
        UT,
        VT,
        VA,
        WA,
        WV,
        WI,
        WY,
        AS,
        DC,
        FM,
        GU,
        MH,
        MP,
        PW,
        PR,
        VI,
        AE,
        AA,
        AP
    }

    public enum CommonEnum
    {
        None,
        N,
        P,
        Y
    }

    public enum BooleanValueEnum
    {
        True,
        False
    }
    public enum HomelessType
    {
        DOUBLINGUP,
        OTHER,
        PERMANENT,
        SHELTER,
        STREET,
        TRANSITIONAL,
        UNKNOWN,
        UNSPECIFIED
    }
    public enum MaritalStatusEnum
    {
        D,
        M,
        P,
        S,
        U,
        W,
        X
    }

    public enum NextkinRelationship
    {
        None,
        CHILD,
        COUSIN,
        FRIEND,
        GUARDIAN,
        OTHER,
        PARENT,
        SIBLING,
        SPOUSE
    }

    public enum PovertyLevelIncomepayPeriod
    {
        None,
        BIWEEK,
        MONTH,
        WEEK,
        YEAR
    }

    public class Sex
    {
        public SexEnum SelectedValue { get; set; }
        public IEnumerable<SelectListItem> DropdownOptions { get; set; }
    }
    public enum SexEnum
    {
        F,
        M
    }
    public enum PatientStatus
    {
        none,
        a,
        d,
        i,
        p
    }


}
