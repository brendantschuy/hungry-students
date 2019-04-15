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

            var cmd = new SqlCommand("SELECT * FROM new_food WHERE event_name LIKE '%" + query + "%';", conn);
            
            //cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            //string result = "";
            List<DatabaseEntry> searchResult = new List<DatabaseEntry>();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string ename = reader.GetString(0);
                    int estart = reader.GetInt32(1);
                    int eend = reader.GetInt32(2);
                    int edate = reader.GetInt32(3);
                    string eaddress = reader.GetString(4);
                    string edesc = reader.GetString(5);
                    string etypes = reader.GetString(6);

                    searchResult.Add(new DatabaseEntry(ename, estart, eend, edate, eaddress, edesc,etypes));


                    /*result += "<ul id='responses'>";
                    result += "<li> Name: " + (string)reader.GetString(0) + "</li><br/>";
                    result += "<li> Start: " + reader.GetInt32(1).ToString() + "</li><br/>";
                    result += "<li> End: " + reader.GetInt32(2).ToString() + "</li><br/>";
                    result += "<li> Date: " + reader.GetInt32(3).ToString() + "</li><br/>";
                    result += "<li> Address: " + (string)reader.GetString(4) + "</li><br/>";
                    result += "<li> Description: " + reader.GetString(5) + "</li><br/>";
                    result += "</ul>";*/
                    //reader.NextResult();
                }
            }
            else
            {
                
            }

            reader.Close();
            conn.Close();

            return new JsonResult(new
            {
                //Data = "Hello.",
                Data = searchResult,
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
