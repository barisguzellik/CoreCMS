using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CoreCMS
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int ServiceCount { get; set; }
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void OnGet()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                CategoryCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Category");
                ProductCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Product");
                ServiceCount = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Service");
            }
        }
    }
}