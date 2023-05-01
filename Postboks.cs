using System.IO;
using System.Text.Json;

namespace PostboksApi
{
    public class Postboks
    {
        private List<Dictionary<string, string>> postboksList;

        public Postboks(string postcodes)
        {
            string json = File.ReadAllText(postcodes);
            postboksList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
        }

        public string GetCity(string postboksNumber)
        {
            foreach (var postboks in postboksList)
            {
                if (postboks.ContainsKey("po") && postboks.ContainsKey("city") && postboks["po"] == postboksNumber)
                {
                    return postboks["city"];
                }
            }

            return "City not found";
        }
    }

}
