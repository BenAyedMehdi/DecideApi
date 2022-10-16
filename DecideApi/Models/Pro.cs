using System.Text.Json.Serialization;

namespace DecideApi.Models
{
    public class Pro
    {
        public int Id { get; set; }
        public string ReasonName { get; set; }
        public int Importance { get; set; }
        public int DecisionId { get; set; }
        [JsonIgnore]
        public Decision Decision { get; set; }
    }

}
