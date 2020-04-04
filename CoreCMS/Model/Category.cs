using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCMS.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [DefaultValue(0)]
        public int Index { get; set; }
        public bool Status { get; set; }
        [DefaultValue(0)]
        public int ParentCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
