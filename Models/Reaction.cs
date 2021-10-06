using System;
using System.Collections.Generic;

#nullable disable

namespace Instagram.Models
{
    public partial class Reaction
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ReactTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ReactType { get; set; }

        public virtual Post ReactTo1 { get; set; }
        public virtual Comment ReactToNavigation { get; set; }
    }
}
