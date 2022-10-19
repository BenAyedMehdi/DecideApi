using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DecideApi.Models
{
    //[DataContract(IsReference = true)]
    public class Pro: IReason
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]    
        public string ReasonName { get; set; }
        [DataMember]    
        public int Importance { get; set; } = 0;
        [DataMember]
        public int DecisionId { get; set; }
        [JsonIgnore]
        public Decision Decision { get; set; }
    }

}
