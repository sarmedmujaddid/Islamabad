using Newtonsoft.Json.Linq;

namespace Islamabad.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {

        }

        public string extractData(String tokenName)
        {

            String myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
