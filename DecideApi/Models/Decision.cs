namespace DecideApi.Models
{
    public class Decision
    {
        public int DecisionId { get; set; }
        public string Idea { get; set; }
        public List<Pro> ProsList { get; set; }
        public List<Conn> ConsList { get; set; }
        public bool Finished { get; set; } = false;
        public int ProsTotal { get; set; }
        public int ConsTotal { get; set; }
    }
}
