using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreCMS.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CoreCMS
{
    public class IndexModel : PageModel
    {
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int ServiceCount { get; set; }

        public string con { get; set; }
        public IndexModel(IOptions<ConnectionString> _con)
        {
            con = _con.Value.Default;
        }

        public void OnGet()
        {
            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                CategoryCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Category");
                ProductCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Product");
                ServiceCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Service");
            }
        }
    }
}