using System.Collections.Generic;

namespace Q_Backend.Models
{
    public class Pool
    {
        public List<Booth> Booths { get; set; }
        public int QueueID { get; set; }
    }
}