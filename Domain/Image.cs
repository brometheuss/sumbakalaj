using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
