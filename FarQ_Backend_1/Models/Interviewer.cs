using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class Interviewer : BaseUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Desc { get; set; }
    }
}