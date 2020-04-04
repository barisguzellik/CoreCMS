using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCMS.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        [Required]
        public string Username { get; set; }
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        [StringLength(100)]
        [Required]
        public string Token { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
