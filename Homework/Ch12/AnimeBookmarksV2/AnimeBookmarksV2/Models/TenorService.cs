using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AnimeBookmarksV2.Models
{
    public class TenorService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public TenorService(IConfiguration config, HttpClient httpClient)
        {
            _apiKey = config["Tenor:ApiKey"];
            _httpClient = httpClient;
        }



        public async Task<string> GetGifAsync()
        {
            var url = $"https://tenor.googleapis.com/v2/search?q=cute+dance+anime+moves+party+time&key={_apiKey}&limit=1";
            var response = await _httpClient.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<TenorResponse>(response);
            return result?.Results?.FirstOrDefault()?.MediaFormats?.Gif?.Url;
        }
    }

    public class TenorResponse
    {
        [JsonProperty("results")]
        public List<TenorResult> Results { get; set; }
    }

    public class TenorResult
    {
        [JsonProperty("media_formats")]
        public TenorMediaFormats MediaFormats { get; set; }
    }

    public class TenorMediaFormats
    {
        [JsonProperty("gif")]
        public TenorGif Gif { get; set; }
    }

    public class TenorGif
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
