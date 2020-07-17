using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q_Backend.Models
{
    public class BaseUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public int EventID { get; set; }
        public string Email { get; set; }
    }
}