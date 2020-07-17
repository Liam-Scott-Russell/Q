using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarQ_Backend_1.DTOs
{
    public class NotificationRequest
    {
        public string Requester { get; set; }
        public string Message { get; set; }
        public string? Payload { get; set; }
        public string RequestRole { get; set; }
    }
}
