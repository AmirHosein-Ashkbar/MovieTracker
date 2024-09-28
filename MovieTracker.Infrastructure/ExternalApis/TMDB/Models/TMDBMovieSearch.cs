using Newtonsoft.Json;

namespace MovieTracker.Infrastructure.ExternalApis.TMDB.Models;

public class TMDBMovieSearch
{
    [JsonProperty("adult")]
    public bool Adult { get; set; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("genre_ids")]
    public List<int> GenreIds { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    [JsonProperty("overview")]
    public string Overview { get; set; }

    [JsonProperty("popularity")]
    public double Popularity { get; set; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }



    //public bool adult { get; set; }
    //public List<int> GenreIds { get; set; }
    //public bool video { get; set; }
    //public double vote_average { get; set; }
    //public int vote_count { get; set; }
}

