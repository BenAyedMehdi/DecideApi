using System.Text.Json.Serialization;

namespace DecideApi.Models
{
    public class Conn : IReason
    {
        public int Id { get; set; }
        public string ReasonName { get; set; }
        public int Importance { get; set; } = 0;
        public int DecisionId { get; set; }
        [JsonIgnore]
        public Decision Decision { get; set; }
    }
}
