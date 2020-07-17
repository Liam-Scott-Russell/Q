using System.Collections.Generic;

namespace Q_Backend.DTOs
{
    public class Queue
    {
        public int QueueID { get; set; }
        public List<int> UserIDs { get; set; }
    }
}