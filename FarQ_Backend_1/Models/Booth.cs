namespace Q_Backend.DTOs
{
    public class Booth
    {
        public int BoothID { get; set; }
        public bool Occupied { get; set; }
        public Interviewer Interviewer { get; set; }
        public string Payload { get; set; }
        public int CurrentUser { get; set; }
        public bool IsActive { get; set; }
        public int EventID { get; set; }
    }
}