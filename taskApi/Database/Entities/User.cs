using System;
using System.Collections.Generic;

#nullable disable

namespace taskApi.Database
{
    public partial class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public short? IsActive { get; set; }
    }
}
