using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace apple.Controllers
{
    public class HomeController : Controller
    {

        string connDB = WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult About()
        {        

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

//-------------------------------- CREATE EMPLOYEE ACCOUNT -----------------------------------

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
           
            var lastname = Request["txtL"];
            var firstname = Request["txtF"];
            var usr = Request["txtU"];
            var pwd = Request["txtP"];
            var cpwd = Request["txtCP"];

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO USRTBL (LASTNAME,FIRSTNAME,USERNAME,PASSWORD,CPASSWORD)"
                                + " VALUES ("
                                + " @LASTNAME,"
                                + " @FIRSTNAME,"
                                + " @USERNAME,"
                                + " @PASSWORD,"
                                + " @CPASSWORD)";
                    cmd.Parameters.AddWithValue("@LASTNAME", lastname);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", firstname);
                    cmd.Parameters.AddWithValue("@USERNAME", usr);
                    cmd.Parameters.AddWithValue("@PASSWORD", pwd);
                    cmd.Parameters.AddWithValue("@CPASSWORD", cpwd);

                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        Response.Write("<script>alert('Registration Success!')</script>");                  
                    }
                    else
                    {
                        Response.Write("<script>alert('Registration Failed! Try Again.')</script>");                  
                    }                  
                }
            }
            // return Json(data, JsonRequestBehavior.AllowGet);
            return View();
        }


//-------------------------------- LOGIN ---------------------------------------
        public ActionResult Login()
        {

            return View();
        }

        public ActionResult LogIn_User()
        {
            var data = new List<object>();
            var Inuser = Request["username"];
            var Inpass = Request["password"];

            using (var db = new SqlConnection(connDB))
            {

                db.Open();

                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM USRTBL WHERE USERNAME = '" + Inuser + "'AND PASSWORD = '" + Inpass + "'";
                    Session["userName"] = Inuser.ToString();
                    //Layout navbar Session
                    //Session["userName"] = Inuser.ToString();
                    SqlDataReader rd = cmd.ExecuteReader();


                    if (rd.Read())
                    {
                        data.Add(new
                        {
                            mess = 0
                        });
                    }

                    else
                    {
                        data.Add(new
                        {
                            mess = 1
                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //------------------------------- DETAILS ENTRY -----------------------------------
        public ActionResult Entry()
        {

            return View();
        }
   
        public ActionResult DetailsEntry()
        {
            var data = new List<object>();
            var mvfile = Request["mvfl"];
            var plateno = Request["pltno"];
            var motorno = Request["mtrno"];
            var serialno = Request["srlno"];
            var offclrcpt = Request["ofclrcpt"];
            var cocno = Request["cocno"];
            var plcyno = Request["plcyno"];
            var rcvdfrm = Request["rcvdfrm"];
            var address = Request["address"];
            var placeissue = Request["plcissue"];
            var make = Request["make"];
            var series = Request["series"];
            var typeofbody = Request["bodytyp"];
            var modelno = Request["mdlno"];
            var others = Request["othrs"];
            var docsstamp1 = Request["stamp1"];
            var lgt = Request["lgt"];
            var premiumsales= Request["premsls"];
            var docsstamp2 = Request["stamp2"];
            var lgtax = Request["lgtax"];
            var dateissue = Request["dtissue"];
            var fromdate = Request["frm"];
            var todate = Request["to"];
            var color = Request["clr"];
            var day = Request["day"];
            var mnths = Request["mnths"];
            var yr = Request["year"];
            var misc = Request["misc"];
            var total = Request["total"];
            var sumpesos = Request["sumpesos"];
            var transtype = Request["transtype"];

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO HISTORYTBL (MV_FILE_NO, PLATE_NO, MOTOR_NO, SERIAL_NO, OFFICIAL_RECEIPT, COC_NO, POLICY_NO, RECEIVED_FROM, ADDRESS, PLACE_ISSUE, MAKE, SERIES, TYPE_OF_BODY, MODEL_NO, OTHERS, DOCS_STAMP1, LGT, PREMIUM_SALES, DOCS_STAMP2, LGTAX, DATE_ISSUE, FROM_DATE, TO_DATE, COLOR, DAY, MONTHS, YEAR, MISC, TOTAL, SUM_OF_PESOS, TRANSTYPE)"
                                + " VALUES ("
                                + " @MV_FILE_NO,"
                                + " @PLATE_NO,"
                                + " @MOTOR_NO,"
                                + " @SERIAL_NO,"
                                + " @OFFICIAL_RECEIPT,"
                                + " @COC_NO,"
                                + " @POLICY_NO,"
                                + " @RECEIVED_FROM,"
                                + " @ADDRESS,"
                                + " @PLACE_ISSUE,"
                                + " @MAKE,"
                                + " @SERIES,"
                                + " @TYPE_OF_BODY,"
                                + " @MODEL_NO,"
                                + " @OTHERS,"
                                + " @DOCS_STAMP1,"
                                + " @LGT,"
                                + " @PREMIUM_SALES,"
                                + " @DOCS_STAMP2,"
                                + " @LGTAX,"
                                + " @DATE_ISSUE,"
                                + " @FROM_DATE,"
                                + " @TO_DATE,"
                                + " @COLOR,"
                                + " @DAY,"
                                + " @MONTHS,"
                                + " @YEAR,"
                                + " @MISC,"
                                + " @TOTAL,"
                                + " @SUM_OF_PESOS,"
                                + " @TRANSTYPE)";

                    cmd.Parameters.AddWithValue("@MV_FILE_NO", mvfile);
                    cmd.Parameters.AddWithValue("@PLATE_NO", plateno);
                    cmd.Parameters.AddWithValue("@MOTOR_NO", motorno);
                    cmd.Parameters.AddWithValue("@SERIAL_NO", serialno);
                    cmd.Parameters.AddWithValue("@OFFICIAL_RECEIPT", offclrcpt);
                    cmd.Parameters.AddWithValue("@COC_NO", cocno);
                    cmd.Parameters.AddWithValue("@POLICY_NO", plcyno);
                    cmd.Parameters.AddWithValue("@RECEIVED_FROM", rcvdfrm);
                    cmd.Parameters.AddWithValue("@ADDRESS", address);
                    cmd.Parameters.AddWithValue("@PLACE_ISSUE", placeissue);
                    cmd.Parameters.AddWithValue("@MAKE", make);
                    cmd.Parameters.AddWithValue("@SERIES", series);
                    cmd.Parameters.AddWithValue("@TYPE_OF_BODY", typeofbody);
                    cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                    cmd.Parameters.AddWithValue("@OTHERS", others);
                    cmd.Parameters.AddWithValue("@DOCS_STAMP1", docsstamp1);
                    cmd.Parameters.AddWithValue("@LGT", lgt);
                    cmd.Parameters.AddWithValue("@PREMIUM_SALES", premiumsales);
                    cmd.Parameters.AddWithValue("@DOCS_STAMP2", docsstamp2);
                    cmd.Parameters.AddWithValue("@LGTAX", lgtax);
                    cmd.Parameters.AddWithValue("@DATE_ISSUE", dateissue);
                    cmd.Parameters.AddWithValue("@FROM_DATE", fromdate);
                    cmd.Parameters.AddWithValue("@TO_DATE", todate);
                    cmd.Parameters.AddWithValue("@COLOR", color);
                    cmd.Parameters.AddWithValue("@DAY", day);
                    cmd.Parameters.AddWithValue("@MONTHS", mnths);
                    cmd.Parameters.AddWithValue("@YEAR", yr);
                    cmd.Parameters.AddWithValue("@MISC", misc);
                    cmd.Parameters.AddWithValue("@TOTAL", total);
                    cmd.Parameters.AddWithValue("@SUM_OF_PESOS", sumpesos);
                    cmd.Parameters.AddWithValue("@TRANSTYPE", transtype);

                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new
                        {
                            mess = 0
                        });
                    }
                    else
                    {
                        data.Add(new
                        {
                            mess = 1
                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


// ------------------------ HISTORY/ DETAILS RECORD ------------------------------------------

        public ActionResult Records()
        {
            return View();
        }

// ----------------------- REMOVE DETAILS RECORD ---------------------------------------------     

        public ActionResult removeData()
        {
            var data = new List<object>();
            // var username = Session["userName"].ToString();
            var removeId = Request["transID"];
            //var tType = Request["transType"];
            //var receivedFrom = Request["rcvdFrom"];

            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "DELETE FROM HISTORYTBL WHERE ID = '" + id + "'AND TRANSTYPE = '" + tType + "'";
                    cmd.CommandText = "DELETE FROM HISTORYTBL WHERE Id = '" + removeId + "'";

                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    
                    {
                        data.Add(new
                        {
                            mess = 0
                        });
                    }
                    else
                    {
                        data.Add(new
                        {
                            mess = 1
                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // ---------------------------------  SEARCH MV-FILE-NUM on VIEWDATA  ---------------------------------------


        public ActionResult SearchItem()
        {
            var data = new List<object>();
            
            //var mvNum = Request["mvNum"];
            var searchId = Request["TransID"];


            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM HISTORYTBL WHERE Id ='" + searchId + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        data.Add(new
                        {
                            mess = 0,

                            type= reader["transType"].ToString(),
                            mvNum = reader["MV_FILE_NO"].ToString(),
                            brand = reader["MAKE"].ToString(),
                            issued = reader["DATE_ISSUE"].ToString(),

                            plate = reader["PLATE_NO"].ToString(),
                            series = reader["SERIES"].ToString(),
                            dateFrom = reader["FROM_DATE"].ToString(),

                            motorNum = reader["MOTOR_NO"].ToString(),
                            body = reader["TYPE_OF_BODY"].ToString(),
                            dateTo = reader["TO_DATE"].ToString(),

                            srl = reader["SERIAL_NO"].ToString(),
                            modelNum = reader["MODEL_NO"].ToString(),
                            color = reader["COLOR"].ToString(),

                            off_Rcpt = reader["OFFICIAL_RECEIPT"].ToString(),
                            othr = reader["OTHERS"].ToString(),
                            day = reader["DAY"].ToString(),

                            cocNum = reader["COC_NO"].ToString(),
                            docs1 = reader["DOCS_STAMP1"].ToString(),
                            mnth = reader["MONTHS"].ToString(),

                            polcyNum = reader["POLICY_NO"].ToString(),
                            lgt = reader["LGT"].ToString(),
                            year = reader["YEAR"].ToString(),

                            receiveFrom = reader["RECEIVED_FROM"].ToString(),
                            premiumSales = reader["PREMIUM_SALES"].ToString(),
                            msc = reader["MISC"].ToString(),

                            address = reader["ADDRESS"].ToString(),
                            docs2 = reader["DOCS_STAMP2"].ToString(),
                            total = reader["TOTAL"].ToString(),

                            place = reader["PLACE_ISSUE"].ToString(),
                            lg = reader["LGTAX"].ToString(),
                            sum = reader["SUM_OF_PESOS"].ToString(),

                        }) ;
                    }
                    else
                    {
                        data.Add(new
                        {
                            mess = 1,
                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


//---------------------------------------------------------------------------

        public ActionResult ViewData()
        {
            return View();
        }

//----------------------------------------------------------------------------
        public ActionResult Update()
        {
            return View();
        }


        public ActionResult UpdateItem()
        {
            var data = new List<object>();

            //var mvNum = Request["mvNum"];
            var updateId = Request["TransID"];

            var mvNw = Request["mvNum"];
            var makeNw = Request["make"];
            var datepickerNw = Request["datepicker1"];

            var plateNw = Request["txtPlate"];
            var seriesNw = Request["txtSeries"];          
            var datepicker2Nw = Request["datepicker2"];

            var motorNw = Request["txtMotorNum"];       
            var bodyNw = Request["txtBody"];
            var datepicker3Nw = Request["datepicker3"];

            var serNw = Request["txtSer"];
            var modelNw = Request["txtModelNo"];   
            var colorNw = Request["txtColor"];

            var orNw = Request["txtOR"];
            var othNw = Request["Oth"];
            var dayNw = Request["txtDay"];

            var cocNw = Request["txtCoc"];
            var docNw = Request["txtDoc"];
            var monthNw = Request["txtMonth"];

            var polNw = Request["txtPol"];
            var lgtNw = Request["txtLgt"];
            var yearNw = Request["txtYear"];

            var recNw = Request["txtRec"];
            var premNw = Request["txtPrem"];
            var miscNw = Request["txtMisc"];

            var addressNw = Request["txtAddress"];
            var docsNw = Request["txtDocs"];
            var totalNw= Request["txtTotal"];

            var placeNw = Request["txtPlace"];
            var lgNw = Request["txtLg"];
            var sumNw = Request["txtSum"];


            using (var db = new SqlConnection(connDB))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE HISTORYTBL SET "
                        + "MV_FILE_NO ='" + mvNw + ","
                        + "MAKE ='" + makeNw + ","
                        + "DATE_ISSUE ='" + datepickerNw + ","

                        + "PLATE_NO ='" + plateNw + ","
                        + "SERIES ='" + seriesNw + ","
                        + "FROM_DATE ='" + datepicker2Nw + ","

                        + "MOTOR_NO ='" + motorNw + ","
                        + "TYPE_OF_BODY ='" + bodyNw + ","
                        + "TO_DATE ='" + datepicker3Nw + ","

                        + "SERIAL ='" + serNw + ","
                        + "MODEL_NO ='" + modelNw + ","
                        + "COLOR ='" + colorNw + ","

                        + "OFFICIAL_RECEIPT ='" + orNw + ","
                        + "OTHERS ='" + othNw + ","
                        + "DAY ='" + dayNw + ","

                        + "COC_NO ='" + cocNw + ","
                        + "DOCS_STAMP1 ='" + docNw + ","
                        + "MONTHS ='" + monthNw + ","

                        + "POLICY_NO ='" + polNw + ","
                        + "LGT ='" + lgtNw + ","
                        + "YEAR ='" + yearNw + ","

                        + "RECEIVED_FROM ='" + recNw + ","
                        + "PREMIUM ='" + premNw + ","
                        + "MISC ='" + miscNw + ","

                        + "ADDRESS ='" + addressNw + ","
                        + "DOCS_STAMP2 ='" + docsNw + ","
                        + "TOTAL ='" + totalNw + ","

                        + "PLACE_ISSUE ='" + placeNw + ","
                        + "LGTAX ='" + lgNw + ","
                        + "SUM_OF_PESOS ='" + sumNw + ","

                        + "WHERE Id ='" + updateId + "'";


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        data.Add(new
                        {
                            mess = 0,

                            type = reader["transType"].ToString(),
                            mvNum = reader["MV_FILE_NO"].ToString(),
                            brand = reader["MAKE"].ToString(),
                            issued = reader["DATE_ISSUE"].ToString(),

                            plate = reader["PLATE_NO"].ToString(),
                            series = reader["SERIES"].ToString(),
                            dateFrom = reader["FROM_DATE"].ToString(),

                            motorNum = reader["MOTOR_NO"].ToString(),
                            body = reader["TYPE_OF_BODY"].ToString(),
                            dateTo = reader["TO_DATE"].ToString(),

                            srl = reader["SERIAL_NO"].ToString(),
                            modelNum = reader["MODEL_NO"].ToString(),
                            color = reader["COLOR"].ToString(),

                            off_Rcpt = reader["OFFICIAL_RECEIPT"].ToString(),
                            othr = reader["OTHERS"].ToString(),
                            day = reader["DAY"].ToString(),

                            cocNum = reader["COC_NO"].ToString(),
                            docs1 = reader["DOCS_STAMP1"].ToString(),
                            mnth = reader["MONTHS"].ToString(),

                            polcyNum = reader["POLICY_NO"].ToString(),
                            lgt = reader["LGT"].ToString(),
                            year = reader["YEAR"].ToString(),

                            receiveFrom = reader["RECEIVED_FROM"].ToString(),
                            premiumSales = reader["PREMIUM_SALES"].ToString(),
                            msc = reader["MISC"].ToString(),

                            address = reader["ADDRESS"].ToString(),
                            docs2 = reader["DOCS_STAMP2"].ToString(),
                            total = reader["TOTAL"].ToString(),

                            place = reader["PLACE_ISSUE"].ToString(),
                            lg = reader["LGTAX"].ToString(),
                            sum = reader["SUM_OF_PESOS"].ToString(),
                        });
                    }
                    else
                    {
                        data.Add(new
                        {
                            mess = 1,
                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }























        //------------------------------------------------ LOGOUT---------------------------------------------------
       
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();

            Response.Redirect("../Home/Login");

            return View();
        }


    }
}