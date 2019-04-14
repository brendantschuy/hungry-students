using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bs2.Models;
using System.Data.SqlClient;
using System.Text;

namespace bs2.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection conn;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult AddPage()
        {
            return View();
        }

        public IActionResult Access()
        {
            ViewData["Message"] = "Your database access page.";

            Console.WriteLine("Hello from console");
            return View();
        }

        public ActionResult ConnectToDatabase()
        {
            string connString = "Server=tcp:tschuy.database.windows.net,1433;Initial Catalog=Projects;Persist Security Info=False;User ID=tschuy;Password=Vacasa321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conn = new SqlConnection(connString);
            try{
                conn.Open();
                Console.WriteLine("SQL Connection successful.");
            }
            catch(Exception e){
                Console.WriteLine("Error connecting to database.");
                Environment.Exit(-1);
            }
            SqlDataAdapter cmd = new SqlDataAdapter();  
            cmd.InsertCommand = new SqlCommand("INSERT INTO new_food(event_name, event_start, event_end, event_date, event_address, descript, food_type) VALUES('Hackathon @ Vacasa', '0900', '1700', '030993', '850 NW 13th Ave. Portland, OR 97209', 'A Hackathon at Vacasa, all types of food provided', 'Fresh Produce, Drinks, Vegetarian, Baked Goods');");
            cmd.InsertCommand.Connection = conn;
            cmd.InsertCommand.ExecuteNonQuery();
            Console.WriteLine("SQL Query execution successful.");
            
            return new JsonResult( new{
                Data = "Connection succeeded",
                success = true
            });
        }

        public class JsonObject
        {
            
        }
        
        public ActionResult Search(string query)
        {
            string connString = "Server=tcp:tschuy.database.windows.net,1433;Initial Catalog=Projects;Persist Security Info=False;User ID=tschuy;Password=Vacasa321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            conn = new SqlConnection(connString);
            conn.Open();

            var poop = "Hackathon";

            var cmd = new SqlCommand("SELECT * FROM new_food WHERE event_name LIKE '%" + poop + "%';", conn);
            
            //cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            string result = "";
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    result += (string)reader.GetString(0);
                    reader.NextResult();
                }
            }
            else
            {
                result = "None found.";
            }

            reader.Close();
            conn.Close();

            return new JsonResult(new
            {
                Data = result,
                //JsonRequestBehavior = JsonRequestBehavior.AllowGet
            });
           
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
    }
}
