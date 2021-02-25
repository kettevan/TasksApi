using System;
using System.Collections.Generic;

#nullable disable

namespace taskApi.Database
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
        public int? WorkingHours { get; set; }
        public int? UserId { get; set; }
        public short? IsActive { get; set; }
    }
}
