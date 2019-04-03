using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCorePractice.Models.Entity
{
    public class UserTask : TaskCorePractice.Models.Entity.Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
