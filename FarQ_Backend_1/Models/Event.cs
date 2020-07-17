using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string EmployerLink { get; set; }
        public string UserLink { get; set; }
        public string Status { get; set; }
        public string HelpLink { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}