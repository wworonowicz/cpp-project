using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public partial class AspNetUserLogins
    {
        [Key]
        public string AspNetUserLoginsId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
