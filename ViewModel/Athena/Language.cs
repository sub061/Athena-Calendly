namespace Medical_Athena_Calendly.ViewModel.Athena
{
    public class Language
    {

        public string Alpha3Code { get; set; }
        public string EnglishName { get; set; }

        public override string ToString()
        {
            //return $"{Alpha3Code} - {EnglishName}";
            return $"{EnglishName}";
        }
    }
}
