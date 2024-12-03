using System.Text.Json.Serialization;

namespace dotnet_webapi_ef.Models;

public class VideoGame
{
    public int  Id { get; set; }
    public string? Title { get; set; }
    public string? Platform { get; set; }
    
    [JsonIgnore] 
    public int? DeveloperId { get; set; }
    public Developer? Developer { get; set; }
    
    [JsonIgnore] 
    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    
    public VideoGameDetails? VideoGameDetails { get; set; }
    public List<Genre>? Genres { get; set; }
}