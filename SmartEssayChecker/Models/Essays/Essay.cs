using System.Text.Json.Serialization;
using SmartEssayChecker.Models.Feedbacks;
using SmartEssayChecker.Models.Users;

namespace SmartEssayChecker.Models.Essays;

public class Essay
{
    public Guid EssayId { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    [JsonIgnore]
    public Feedback Feedback { get; set; }
}