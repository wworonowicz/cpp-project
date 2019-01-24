using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public partial class AspNetUserRoles
    {
        [Key]
        public string userRolesId { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AspNetRoles Role { get; set; }
        public AspNetUsers User { get; set; }
    }
}
