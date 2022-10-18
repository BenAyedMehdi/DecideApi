using System.Text.Json.Serialization;

namespace DecideApi.Models
{
    public interface IReason
    {
        int Id { get; set; }
         string ReasonName { get; set; }
         int Importance { get; set; }
         int DecisionId { get; set; }
         Decision Decision { get; set; }
    }
}
