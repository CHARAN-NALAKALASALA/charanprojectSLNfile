using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace ShopBridge.Controllers
{

    //Code done by Charan
    public class ShopBridgeDController : Controller
    {
        string myConnection = ConfigurationManager.ConnectionStrings["myDBConnection"].ConnectionString;        //ConnectionString
       

        // GET: ShopBridgeD
        [HttpGet]
        public ActionResult Index()                                                         
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(myConnection))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from ComponentsTable", conn);
                sda.Fill(dt);
            }
                
                return View(dt);                                //Retrieve data from database and display it in datatable
        }

        // GET: ShopBridgeD/Details/5
        public ActionResult Details(int id)             //Display product Details passing Product_Id as parameters
        {
            Shopbridgedata1 shopBridgeData = new Shopbridgedata1();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(myConnection))
            {
                conn.Open();
                string query = "select * from ComponentsTable where product_id = @product_id";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("product_id", id);
                sqlDataAdapter.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                shopBridgeData.product_id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                shopBridgeData.product_name = dataTable.Rows[0][1].ToString();
                shopBridgeData.product_price = dataTable.Rows[0][2].ToString();
                shopBridgeData.product_description = dataTable.Rows[0][3].ToString();
                return View(shopBridgeData);
                
            }
            else
                return RedirectToAction("Index");
        }

        // GET: ShopBridgeD/Create
        [HttpGet]
        public ActionResult Create()                                //Insert Data into the table
        {
            return View(new Shopbridgedata1());
        }

        // POST: ShopBridgeD/Create
        [HttpPost]
        public ActionResult Create(Shopbridgedata1 shopbridgedata)
        {
            using (SqlConnection conn=new SqlConnection(myConnection)) 
            {
                conn.Open();
                string query = "Insert into ComponentsTable values(@product_name,@product_price,@product_description)";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@product_name", shopbridgedata.product_name);
                cmd.Parameters.AddWithValue("@product_price", shopbridgedata.product_price);
                cmd.Parameters.AddWithValue("@product_description", shopbridgedata.product_description);
                cmd.ExecuteNonQuery();
            }

            
            // TODO: Add insert logic here
            //Close the popup-window 
            return Content(@"<body>
                       <script type='text/javascript'>             
                         window.close();
                       </script>
                     </body> ");
            
            

        }

               // GET: ShopBridgeD/Delete/5
        public ActionResult Delete(int id)                                  //Delete the data from table passing productID as parameter
        {
            using (SqlConnection conn = new SqlConnection(myConnection))
            {
                conn.Open();
                string query = "Delete from ComponentsTable where product_id = @product_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        
    }
}
