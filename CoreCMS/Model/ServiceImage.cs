using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCMS.Model
{
    public class ServiceImage
    {
        [Key]
        public int ServiceImageId { get; set; }
        public int Index { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
