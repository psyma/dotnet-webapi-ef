using System.Text.Json.Serialization;

namespace dotnet_webapi_ef.Models;

public class VideoGameDetails
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    [JsonIgnore]
    public int VideoGameId { get; set; }
}