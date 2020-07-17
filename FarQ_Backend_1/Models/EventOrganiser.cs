using System.Collections.Generic;

namespace Q_Backend.DTOs
{
    public class EventOrganiser : BaseUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<int> EventIDs { get; set; }
    }
}