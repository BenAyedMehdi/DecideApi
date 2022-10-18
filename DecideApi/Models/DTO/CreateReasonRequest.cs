using System.Text.Json.Serialization;

namespace DecideApi.Models.DTO
{
    public class CreateReasonRequest
    {
        public string ReasonName { get; set; }
        public int Importance { get; set; }
        public int DecisionId { get; set; }
    }
}
