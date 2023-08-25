namespace Medical_Athena_Calendly.ViewModel.Athena
{
    public class BalanceViewModel
    {
        public string DepartmentList { get; set; }
        public decimal Balance { get; set; }
        public bool CleanBalance { get; set; }
    }

    public class PatientViewModel
    {
        public string email { get; set; }
        public string departmentid { get; set; }
        public bool portaltermsonfile { get; set; }
        public bool consenttotext { get; set; }
        public DateTime dob { get; set; }
        public bool Patientphoto { get; set; }
        public string guarantorfirstname { get; set; }
        public string lastname { get; set; }
        public string guarantorlastname { get; set; }
        public DateTime guarantordob { get; set; }
        public string guarantorrelationshiptopatient { get; set; }
        public string firstname { get; set; }
        public bool emailexists { get; set; }
        public List<BalanceViewModel> balances { get; set; }
        public string guarantoremail { get; set; }
        public string patientid { get; set; }
        public bool driverslicense { get; set; }
        public string primarydepartmentid { get; set; }
        public bool guarantoraddresssameaspatient { get; set; }
        public string countrycode { get; set; }
        public DateTime registrationdate { get; set; }
        public string primaryproviderid { get; set; }
        public string status { get; set; }
        public List<string> race { get; set; }
        public bool privacyinformationverified { get; set; }
        public string countrycode3166 { get; set; }
    }

    public class PatientSearchVM
    {
        public int totalcount { get; set; }
        public List<PatientViewModel> patients { get; set; }
    }

}
