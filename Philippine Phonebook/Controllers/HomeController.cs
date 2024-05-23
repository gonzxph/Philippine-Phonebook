using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Philippine_Phonebook.Controllers
{
    public class HomeController : Controller
    {
        string connstr = @"Data Source=gonzxph\MSSQLSERVER04;Initial Catalog=Phonebook;Integrated Security=True";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Phonebook()
        {
            return View();
        }

        public ActionResult AddPhonebook()
        {
            var phonebook = new List<object>();
            var name = Request["name"]?.ToUpper();
            int area_code = Convert.ToInt32(Request["area_code"]);
            int phone_number = Convert.ToInt32(Request["phone_number"]);
            int mobile_number = Convert.ToInt32(Request["mobile_number"]);
            int house_number = Convert.ToInt32(Request["house_number"]);
            var street = Request["street"];
            var city = Request["city"];
            var province = Request["province"];
            var zip_code = Request["zip_code"];
            var email = Request["email"];

            using (var db = new SqlConnection(connstr))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO phonebook (NAME, AREA_CODE, PHONE_NUMBER, MOBILE_NUMBER, HOUSE_NUMBER, STREET, CITY, PROVINCE, ZIP_CODE, EMAIL) VALUES (@NAME, @AREA_CODE, @PHONE_NUMBER, @MOBILE_NUMBER, @HOUSE_NUMBER, @STREET, @CITY, @PROVINCE, @ZIP_CODE, @EMAIL)";
                    cmd.Parameters.AddWithValue("@NAME", name);
                    cmd.Parameters.AddWithValue("@AREA_CODE", area_code);
                    cmd.Parameters.AddWithValue("@PHONE_NUMBER", phone_number);
                    cmd.Parameters.AddWithValue("@MOBILE_NUMBER", mobile_number);
                    cmd.Parameters.AddWithValue("@HOUSE_NUMBER", house_number);
                    cmd.Parameters.AddWithValue("@STREET", street);
                    cmd.Parameters.AddWithValue("@CITY", city);
                    cmd.Parameters.AddWithValue("@PROVINCE", province);
                    cmd.Parameters.AddWithValue("@ZIP_CODE", zip_code);
                    cmd.Parameters.AddWithValue("@EMAIL", email);

                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr >= 1)
                    {
                        phonebook.Add(new
                        {
                            mess = 1,
                        });
                    }

                }


            }


            return Json(phonebook, JsonRequestBehavior.AllowGet);
        }

    }
}