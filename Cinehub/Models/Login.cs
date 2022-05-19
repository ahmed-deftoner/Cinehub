using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Login
    {
        public int SessionNo { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
