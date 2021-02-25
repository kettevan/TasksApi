using System;
using System.Collections.Generic;

#nullable disable

namespace taskApi.Database
{
    public partial class StatusFlow
    {
        public int Id { get; set; }
        public int? FromStatusId { get; set; }
        public int? ToStatusId { get; set; }
    }
}
