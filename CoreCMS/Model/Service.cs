using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCMS.Model
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [StringLength(50)]
        [Required]
        public string ServiceName { get; set; }
        public string Detail { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [DefaultValue(0)]
        public int Index { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ServiceImage> ServiceImages { get; set; }
    }
}
