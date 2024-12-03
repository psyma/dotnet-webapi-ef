using System.Text.Json.Serialization;

namespace dotnet_webapi_ef.Models;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    [JsonIgnore]
    public List<VideoGame> VideoGames { get; set; }
}