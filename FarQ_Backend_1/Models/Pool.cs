using System.Collections.Generic;

namespace Q_Backend.DTOs
{
    public class Pool
    {
        public List<Booth> Booths { get; set; }
        public int QueueID { get; set; }
    }
}