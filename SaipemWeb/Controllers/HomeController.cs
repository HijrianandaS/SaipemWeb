using Microsoft.AspNetCore.Mvc;
using SaipemWeb.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using WebSaipem.Models;

namespace SaipemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<CompanyView> companyViews = new List<CompanyView>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            WebSaipem();

            return View(companyViews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void WebSaipem()
        {
            string connectionString = "Server=RAS-HIJRIANANDA;Database=tes;user id=sa; password=5aPassword; Trusted_Connection = false; Encrypt = false;";
            string query = "SELECT * FROM company_view WHERE company_name_2 LIKE 'SAIPEM%' ORDER BY company_name_2 DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        companyViews.Add(new CompanyView()
                        {
                            company_code_1_1 = reader["company_code_1_1"].ToString(),
                            company_name_1 = reader["company_name_1"].ToString(),
                            company_code_2 = reader["company_code_2"].ToString(),
                            company_name_2 = reader["company_name_2"].ToString()
                        });

                    }
                        connection.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
        }
    }
}