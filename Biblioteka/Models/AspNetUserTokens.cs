using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public partial class AspNetUserTokens
    {
        [Key]
        public string tokenId { get; set; }
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public AspNetUsers User { get; set; }
    }
}
