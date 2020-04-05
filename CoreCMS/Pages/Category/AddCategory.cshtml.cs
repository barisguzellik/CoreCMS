using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreCMS
{
    public class AddCategoryModel : PageModel
    {
        public string con { get; set; }
        private IWebHostEnvironment _environment;
        public AddCategoryModel(IOptions<ConnectionString> _con, IWebHostEnvironment environment)
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
        }

        public IActionResult OnPost()
        {
            var category = Category;

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

            //Create
            using (var connection = new SqlConnection(con))
            {
                var sql = "INSERT INTO Category(CategoryName,Image,[Index],Status,ParentCategoryId,CreatedDate) Values(@CategoryName,@Image,@Index,@Status,@ParentCategoryId,@CreatedDate)";
                var param = new { CategoryName = category.CategoryName, Image = category.Image, Index = category.Index, Status = category.Status, ParentCategoryId = category.ParentCategoryId, CreatedDate = DateTime.Now };
                connection.Execute(sql, param);
            }

            return RedirectToPage("/Category/Index");
        }
    }
}