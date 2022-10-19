using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DecideApi.Models
{
    //[JsonObject(IsReference = true)]
    public class Decision
    {
        public int DecisionId { get; set; }
        public string Idea { get; set; }
        public List<Pro> ProsList { get; set; }
        public List<Conn> ConsList { get; set; }
        public bool Finished { get; set; } = false;
        public int ProsTotal { get; set; }
        public int ConsTotal { get; set; }
        public bool IsPulic { get; set; } = false;
    }
}
