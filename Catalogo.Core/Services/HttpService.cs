using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Catalogo.Services
{
    public class HttpService : IHttpService
    {
        public const string BaseUrl = "http://pastebin.com/raw/";

        public async Task<T> GetAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{BaseUrl}{url}");
                var message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(message);
            }
        }
        public async Task<T> PostAsync<T>(string url, object json)
        {
            using (var client = new HttpClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{BaseUrl}{url}", httpContent);
                var message = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(message);
            }
        }
    }
}
