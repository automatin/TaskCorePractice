using System;
using System.Collections.Generic;

namespace TaskCorePractice.Models
{
    public partial class User
    {
        public User()
        {
            UserTask = new HashSet<UserTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserTask> UserTask { get; set; }
    }
}
