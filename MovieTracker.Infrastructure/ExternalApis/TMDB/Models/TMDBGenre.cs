
using Newtonsoft.Json;

namespace MovieTracker.Infrastructure.ExternalApis.TMDB.Models;

public class TMDBGenre
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}
