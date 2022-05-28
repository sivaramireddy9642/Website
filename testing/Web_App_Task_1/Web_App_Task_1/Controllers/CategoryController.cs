using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Web_App_Task_1.Models;
namespace Web_App_Task_1.Controllers
{
    public class CategoryController : Controller
    {
        SqlConnection conn;
        SqlCommand comm;
       // SqlDataReader dreader;
        CategoryContext db = new CategoryContext();
        // GET: Category
        public ActionResult CategoryList()
        {
            return View(db.CategoryList());
        }

        public ActionResult SaveForm()
        {
            string mesg = "Save";
            ViewBag.mesg = mesg;
            return View();
        }
        public ActionResult Update(int CatID)
        {
            var checkdata = db.CategoryList();
            var data = checkdata.Where(a => a.CategoryID == CatID).ToList();
            ViewBag.data = data.ToList();
            return View();
        }

        public JsonResult UpdateData(int CatID, string Catname, string ImagePath)
        {
            JsonResult js = new JsonResult();
            string mesg = "";
            var checkdata = db.CategoryList();
            var catName = checkdata.Where(a => a.CategoryName == Catname).FirstOrDefault();
            if (catName != null && catName.CategoryName == Catname)
            {
                mesg = "Name Already Exits";
                js.Data = mesg;
                return js;
            }
            else
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                comm = new SqlCommand("update tblCategory set CategoryName= '" + Catname + "', DefaultImage= '" + ImagePath + "' where CategoryID = " + CatID + " ", conn);
                try
                {
                    comm.ExecuteNonQuery();
                    mesg = "updated Successfully"; ;
                }
                catch (Exception)
                {
                    mesg = " Not Updated";
                }
                finally
                {
                    conn.Close();
                }

                js.Data = mesg;
                return js;
            }
        }
        public JsonResult Save(string name, string image)
        {
            string mesg = "";
            JsonResult js = new JsonResult();
            var checkdata = db.CategoryList();
            var catName = checkdata.Where(a => a.CategoryName == name).FirstOrDefault();
            if (catName != null && catName.CategoryName == name)
            {
                mesg = "Name Already Exits";
                js.Data = mesg;
                return js;
            }
            else
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                //('Ram','/c/images/','01/02/2022',0,'01-02-2022')
                comm = new SqlCommand("insert into tblCategory values('" + name + "','" + image + "','" + "" + "','" + 1 + "','" + "" + "')", conn);
                try
                {
                    comm.ExecuteNonQuery();
                    mesg = "successfully Saved";
                }
                catch (Exception)
                {
                    mesg = " Not Saved";
                }
                finally
                {
                    conn.Close();
                }

                js.Data = mesg;
                return js;
            }
        }

        public JsonResult delete(int CatID)
        {
            JsonResult js = new JsonResult();
            string mesg = "";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            //('Ram','/c/images/','01/02/2022',0,'01-02-2022')
            comm = new SqlCommand("delete from tblCategory where CategoryID="+ CatID + "", conn);
            try
            {
                comm.ExecuteNonQuery();
                mesg = " deleted successfully";
            }
            catch (Exception ex)
            {
                mesg = "unabel to delete";
            }
            finally
            {
                conn.Close();
            }

           js.Data = mesg;
            return js;
        }



        public JsonResult Active(int CatID)
        {
            JsonResult js = new JsonResult();
            string mesg = "";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            conn.Open();
            //('Ram','/c/images/','01/02/2022',0,'01-02-2022')
            comm = new SqlCommand("update tblCategory set isActive=1 where CategoryID=" + CatID + "", conn);
            try
            {
                comm.ExecuteNonQuery();
                mesg = " Active successfully";
            }
            catch (Exception ex)
            {
                mesg = "unabel to Active";
            }
            finally
            {
                conn.Close();
            }

            js.Data = mesg;
            return js;
        }

        public ActionResult DragDropTopToBottom()
        {
            return View();
        }
        public ActionResult Sortable()
        {
            return View();
        }

        public ActionResult DropDown()
        {
            return View();
        }

    }
}