using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Dapper;
using System.Text.Json;
namespace CoreCMS
{
    public class CategoryModel : PageModel
    {
        public string con { get; set; }
        public CategoryModel(IOptions<ConnectionString> _con)
        {
            con = _con.Value.Default;
        }
        public List<Category> Category { get; set; }
        public void OnGet()
        {
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                Category = connection.Query<Category>("SELECT * FROM Category").ToList();
            }
        }
    }
}