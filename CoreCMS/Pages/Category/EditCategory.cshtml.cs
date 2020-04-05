using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CoreCMS
{
    public class EditCategoryModel : PageModel
    {
        public string con { get; set; }
        private IWebHostEnvironment _environment;
        public EditCategoryModel(IOptions<ConnectionString> _con, IWebHostEnvironment environment)
        {
            con = _con.Value.Default;
            _environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
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


            //id param
            if (!string.IsNullOrEmpty(Request.Query["id"]))
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    int id = int.Parse(Request.Query["id"].ToString());
                    string sql = "SELECT * FROM Category WHERE CategoryId=@Id";
                    var param = new { Id = id };
                    Category = connection.QuerySingle<Category>(sql, param);
                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var category = Category;
            var id = Category.CategoryId;
            using (var connection = new SqlConnection(con))
            {
                var sql = "DELETE from Category Where CategoryId=@CategoryId";
                var param = new { CategoryId = id };
                connection.Execute(sql, param);
            }

            return RedirectToPage("/Category/Index");
        }

        public IActionResult OnPostUpdate()
        {
            var category = Category;
            var id = Category.CategoryId;

            //file upload
            if (Upload != null)
            {
                var fileName = Guid.NewGuid().ToString() + "-" + Upload.FileName;
                var file = Path.Combine(_environment.WebRootPath, "uploads", fileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    Upload.CopyTo(fileStream);
                }
                category.Image = fileName;
            }

            //update
            using (var connection = new SqlConnection(con))
            {
                var sql = "UPDATE Category Set CategoryName=@CategoryName,Image=@Image,[Index]=@Index,Status=@Status,ParentCategoryId=@ParentCategoryId,CreatedDate=@CreatedDate Where CategoryId=@CategoryId";
                var param = new { CategoryId = id, CategoryName = category.CategoryName, Image = category.Image, Index = category.Index, Status = category.Status, ParentCategoryId = category.ParentCategoryId, CreatedDate = DateTime.Now };
                connection.Execute(sql, param);
            }

            return RedirectToPage("/Category/Index");

        }
    }
}