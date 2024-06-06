﻿using System;
using System.Collections.Generic;

namespace TheLearningHub.core.Data
{
    public partial class Role
    {
        public Role()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
