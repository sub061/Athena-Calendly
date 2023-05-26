namespace Medical_Athena_Calendly.CommonServices
{
    public static class GetSubstring
    {
        public static string GetResult(string inputString)
        {
            int index = inputString.IndexOf('/'); // Find the index of the first occurrence of "/"

            if (index >= 0 && index < inputString.Length - 1)
            {
                string substring = inputString.Substring(index + 1); // Extract the substring after "/"
                return substring; // Output: "some-text"
            }
            return "";
        }

    }
}
