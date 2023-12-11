using System.Text.Json.Serialization;
using SmartEssayChecker.Models.Essays;

namespace SmartEssayChecker.Models.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<Essay> Essays { get; set; }
    
}