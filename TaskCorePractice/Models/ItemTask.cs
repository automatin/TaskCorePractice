using System;
using System.Collections.Generic;

namespace TaskCorePractice.Models
{
    public partial class ItemTask
    {
        public int Id { get; set; }
        public int UserTaskId { get; set; }
        public string Name { get; set; }

        public virtual UserTask UserTask { get; set; }
    }
}
