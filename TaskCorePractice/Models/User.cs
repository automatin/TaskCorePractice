using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskCorePractice.Models.Entity;

namespace TaskCorePractice.Models
{
    public class User : TaskCorePractice.Models.Entity.Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  UserName { get; set; }
        public string Password { get; set; }
        public List<UserTask> TaskList{ get; set; }

        public User()
        {
            TaskList = new List<UserTask>();        
        }
    }
}
