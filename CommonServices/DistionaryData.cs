using System.Reflection;

namespace Medical_Athena_Calendly.CommonServices
{
    public static class DictionaryData
    {

        public static Dictionary<string, string> ConvertToDictionary<T>(T model)
        {
            var formData = new Dictionary<string, string>();

            foreach (var property in model.GetType().GetProperties())
            {
                var value = property.GetValue(model)?.ToString();
                var key = property.Name;
                formData.Add(key, value);
            }

            return formData;
        }
        //public static Dictionary<string, string> ConvertToDictionary(object obj)
        //{
        //    Dictionary<string, string> dictionary = new Dictionary<string, string>();

        //    PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    foreach (PropertyInfo property in properties)
        //    {
        //        string propertyName = property.Name;
        //        object propertyValue = property.GetValue(obj);

        //        dictionary.Add(propertyName, (string)propertyValue);
        //    }

        //    return dictionary;
        //}
    }
}
