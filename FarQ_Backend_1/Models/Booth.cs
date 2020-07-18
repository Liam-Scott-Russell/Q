using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class Booth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoothID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int InterviewerID { get; set; }
        public string Payload { get; set; }
        public int CurrentUser { get; set; }
        public bool IsActive { get; set; }
        public int EventID { get; set; }
    }
}