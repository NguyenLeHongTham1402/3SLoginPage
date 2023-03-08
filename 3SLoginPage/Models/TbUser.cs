using System;
using System.Collections.Generic;

#nullable disable

namespace _3SLoginPage.Models
{
    public partial class TbUser
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
    }
}
