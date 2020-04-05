using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreCMS
{
    public class AddCategoryModel : PageModel
    {
        public string con { get; set; }
        public AddCategoryModel(IOptions<ConnectionString> _con)
        {
            con = _con.Value.Default;
        }
        [BindProperty]
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet()
        {
            //SelectList Category
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                Categories = connection.Query<Category>("SELECT * FROM Category").ToList();
            }
            //End Select
        }

        public IActionResult OnPost()
        {
            var category = Category;
            //Create
            using (var connection = new SqlConnection(con))
            {
                var sql = "INSERT INTO Category(CategoryName,[Index],Status,ParentCategoryId,CreatedDate) Values(@CategoryName,@Index,@Status,@ParentCategoryId,@CreatedDate)";
                var param = new { CategoryName = category.CategoryName, Index = category.Index, Status = category.Status, ParentCategoryId = category.ParentCategoryId, CreatedDate = DateTime.Now };
                connection.Execute(sql, param);
            }

            return RedirectToPage("/Category/Index");
        }
    }
}