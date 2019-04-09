using System;
using System.Collections.Generic;

namespace TaskCorePractice.Models
{
    public partial class UserTask
    {
        public UserTask()
        {
            ItemTask = new HashSet<ItemTask>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ItemTask> ItemTask { get; set; }
    }
}
