using Newtonsoft.Json;

namespace PriceEngine.Extensions
{
    public static class ObjectConversionExtensions
    {
        public static T ConvertToType<T>(this object response)
        {
            //TODO: may be should write whether it can be converted or not before. 
            var jsonData = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
