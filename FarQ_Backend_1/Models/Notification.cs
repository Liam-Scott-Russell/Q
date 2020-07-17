using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }
        public string Requester { get; set; }
        public string Respondent { get; set; }
        public string Message { get; set; }
        public string? Payload { get; set; }
        public bool IsActioned { get; set; }

    }
}