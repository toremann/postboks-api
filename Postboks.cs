using System.Text.Json;
using System.Text;

namespace PostboksApi
{
    public class Postboks
    {
        private List<Dictionary<string, string>> postboksList;

        public Postboks(string postcodes)
        {
            if (postcodes == null)
            {
                throw new ArgumentNullException(nameof(postcodes));
            }
            string json = File.ReadAllText(postcodes, Encoding.UTF8);
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
