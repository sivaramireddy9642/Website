using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Web_App_Task_1.Models
{
    public class CategoryContext
    {
      // public string connectionstring = "Data Source=LAPTOP-N2P4T9AQ\TEST;Initial Catalog=TEST;Integrated Security=true;";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public List<CategoryModel> CategoryList()
        {
            List<CategoryModel> listdata = new List<CategoryModel>();
            SqlCommand cmd = new SqlCommand("select * from tblCategory",con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string currentdate = System.DateTime.Now.ToString("dd MMM yyyy");
            foreach(DataRow dr in dt.Rows)
            {
                CategoryModel categorylist = new CategoryModel();
                categorylist.CategoryID =Convert.ToInt16( dr[0]);
                categorylist.CategoryName = Convert.ToString(dr[1]);
                categorylist.DefaultImage = Convert.ToString(dr[2]);
                categorylist.CreatedOn = Convert.ToDateTime(dr[3] == "" ? currentdate : dr[3]);
                categorylist.isActive = Convert.ToBoolean(dr[4]);
                categorylist.updatedOn = Convert.ToDateTime(dr[5]==""? currentdate : dr[5]);
                listdata.Add(categorylist);
            }
            return listdata.ToList();
        }

        
    }
}