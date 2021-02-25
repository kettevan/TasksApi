using System;
namespace taskApi.Models
{
    public class TaskModel
    {
        public string taskName { get; set; }
        public int workingHours { get; set; }
        public string currentStatus { get; set; }
        public int userId { get; set; }

           
    }
}
