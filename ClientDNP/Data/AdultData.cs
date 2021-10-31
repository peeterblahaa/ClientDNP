using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientDNP.Models;
using Newtonsoft.Json;

namespace ClientDNP.Data
{
    public class AdultData : IAdultData
    {
        private const string _url = "https://localhost:5002/Adults";
        private readonly HttpClient client; 
        public AdultData()
        {
            client = new HttpClient();
            Adults = new List<Adult>();
        }
        public IList<Adult> Adults { get; private set; }


        public async Task<IList<Adult>> GetAdults()
        {
            if (!Adults.Any())
            {
                var response = await client.GetAsync(_url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();


                JsonSerializerSettings settings = new() {TypeNameHandling = TypeNameHandling.All};
                Adults = JsonConvert.DeserializeObject<List<Adult>>(responseBody, settings);
            }

            return Adults;
        }
        

        public async Task RemoveAdult(Adult adult)
        {
            Adults.Remove(adult);
            var response = await client.DeleteAsync(_url + $"/{adult.Id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task Add(Adult adult)
        {
            var max = Adults.Max(adult => adult.Id);
            adult.Id = ++max;
            Adults.Add(adult);


            StringContent queryString = new(JsonConvert.SerializeObject(adult), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_url, queryString);
            response.EnsureSuccessStatusCode();
        }
        
    }
}