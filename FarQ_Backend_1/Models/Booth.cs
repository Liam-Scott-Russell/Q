using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class Booth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoothID { get; set; }
        public bool Occupied { get; set; }
        public Interviewer Interviewer { get; set; }
        public string Payload { get; set; }
        public int CurrentUser { get; set; }
        public bool IsActive { get; set; }
        public int EventID { get; set; }
    }
}