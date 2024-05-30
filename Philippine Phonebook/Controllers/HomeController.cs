using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

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
            var area_code = Request["area_code"];
            var phone_number = Request["phone_number"];
            var mobile_number = Request["mobile_number"];
            var house_number = Request["house_number"];
            var street = Request["street"];
            var city = Request["city"];
            var province = Request["province"];
            var zip_code = Request["zip_code"];
            var email = Request["email"];
            var status = Request["status"];

            using (var db = new SqlConnection(connstr))
            {

                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO phonebook (NAME, AREA_CODE, PHONE_NUMBER, MOBILE_NUMBER, HOUSE_NUMBER, STREET, CITY, PROVINCE, ZIP_CODE, EMAIL, STATUS) VALUES (@NAME, @AREA_CODE, @PHONE_NUMBER, @MOBILE_NUMBER, @HOUSE_NUMBER, @STREET, @CITY, @PROVINCE, @ZIP_CODE, @EMAIL, @STATUS)";
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
                    cmd.Parameters.AddWithValue("@STATUS", status);

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

        [HttpGet]
        public ActionResult GetPhonebook(int id)
        {
            using (var db = new SqlConnection(connstr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM PHONEBOOK WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var phonebook_data = new
                            {
                                id = reader["id"].ToString(),
                                name = reader["name"].ToString(),
                                area_code = reader["area_code"].ToString(),
                                phone_number = reader["phone_number"].ToString(),
                                mobile_number = reader["mobile_number"].ToString(),
                                house_number = reader["house_number"].ToString(),
                                street = reader["street"].ToString(),
                                city = reader["city"].ToString(),
                                province = reader["province"].ToString(),
                                zip_code = reader["zip_code"].ToString(),
                                email = reader["email"].ToString(),
                                status = reader["status"].ToString(),
                            };

                            return Json(phonebook_data, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(null, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult ModifyPhonebook()
        {
            var id = Request.Form["id"];
            var name = Request.Form["name"];
            var area_code = Request.Form["area_code"];
            var phoneno = Request.Form["phoneno"];
            var mobileno = Request.Form["mobileno"];
            var houseno = Request.Form["houseno"];
            var status = Request.Form["status"];
            var street = Request.Form["street"];
            var city = Request.Form["city"];
            var province = Request.Form["province"];
            var zcode = Request.Form["zcode"];
            var email = Request.Form["email"];

            using (var db = new SqlConnection(connstr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE PHONEBOOK SET NAME = @name, AREA_CODE = @area_code, PHONE_NUMBER = @phoneno, MOBILE_NUMBER = @mobileno, HOUSE_NUMBER = @houseno, STREET = @street, CITY = @city, PROVINCE = @province, " +
                        "ZIP_CODE = @zcode, EMAIL = @email, STATUS = @status WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@area_code", area_code);
                    cmd.Parameters.AddWithValue("@phoneno", phoneno);
                    cmd.Parameters.AddWithValue("@mobileno", mobileno);
                    cmd.Parameters.AddWithValue("@houseno", houseno);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@province", province);
                    cmd.Parameters.AddWithValue("@zcode", zcode);
                    cmd.Parameters.AddWithValue("@email", email);

                    var ctr = cmd.ExecuteNonQuery();
                    var result = new { success = ctr > 0 };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult DeletePhonebook(int prod_id)
        {
            using (var db = new SqlConnection(connstr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM PHONEBOOK WHERE ID = @prod_id";
                    cmd.Parameters.AddWithValue("@prod_id", prod_id);
                    var ctr = cmd.ExecuteNonQuery();
                    
                    var result = new
                    { 
                        success = ctr > 0
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
        }

    }
}