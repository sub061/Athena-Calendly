namespace Medical_Athena_Calendly.CommonServices
{
    public class SexualOrientation
    {
        public string Name { get; set; }
    }

    public static class SexualOrientationData
    {
        public static List<SexualOrientation> GetData()
        {
            var sexualOrientations = new List<SexualOrientation>
            {
        new SexualOrientation { Name = "Straight or heterosexual" },
        new SexualOrientation {  Name = "Lesbian, gay or homosexual" },
        new SexualOrientation {  Name = "Bisexual" },
        new SexualOrientation {  Name = "Don't know" },
        new SexualOrientation {  Name = "Something else" },
        new SexualOrientation {  Name = "Choose not to disclose" },
        new SexualOrientation {  Name = "Something else, please describe" }
             };

            return sexualOrientations;
        }
    }
}
