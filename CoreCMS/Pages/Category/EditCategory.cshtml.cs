﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data.SqlClient;

namespace CoreCMS
{
    public class EditCategoryModel : PageModel
    {
        public string con { get; set; }
        public EditCategoryModel(IOptions<ConnectionString> _con)
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
            if (!string.IsNullOrEmpty(Request.Query["id"]))
            {
                var category = Category;
                var id = int.Parse(Request.Query["id"]);
                using (var connection = new SqlConnection(con))
                {
                    var sql = "DELETE from Category Where CategoryId=@CategoryId";
                    var param = new { CategoryId = id };
                    connection.Execute(sql, param);
                }
            }

            return RedirectToPage("/Category/Index");
        }

        public IActionResult OnPostUpdate()
        {
            if (!string.IsNullOrEmpty(Request.Query["id"]))
            {
                var category = Category;
                var id = int.Parse(Request.Query["id"]);

                using (var connection = new SqlConnection(con))
                {
                    var sql = "UPDATE Category Set CategoryName=@CategoryName,[Index]=@Index,Status=@Status,ParentCategoryId=@ParentCategoryId,CreatedDate=@CreatedDate Where CategoryId=@CategoryId";
                    var param = new { CategoryId = id, CategoryName = category.CategoryName, Index = category.Index, Status = category.Status, ParentCategoryId = category.ParentCategoryId, CreatedDate = DateTime.Now };
                    connection.Execute(sql, param);
                }
            }
            return RedirectToPage("/Category/Index");
        }
    }
}