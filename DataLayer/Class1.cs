using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml.Linq;
using System.Diagnostics;
using System.Data;

namespace DataLayer
{
    public class DataLayerClass
    {
        string sqlConnect = "Data Source=MSI;Initial Catalog=ProductsData;Integrated Security=True;Encrypt=False";
        public void connectDataBase(string product_Name,int quantity,double price,double stock_value)
        { 
            using (SqlConnection connect = new SqlConnection(sqlConnect))
            {
                connect.Open();
                string insertQuery = "insert into ProductStore(Product_Name,Quantity,Price,Stock_Value) values\r\n(@Product_Name,@Quantity,@Price,@Stock_Value);";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@Product_Name", product_Name);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock_Value", stock_value);

                    cmd.ExecuteNonQuery();


                }
                connect.Close();
            }
        }
        public void update(string product_Name, int quantity, double price, double stock_value)
        {
            using (SqlConnection connect = new SqlConnection(sqlConnect))
            {
                connect.Open();
                string updateQuery = "Update ProductStore set product_name=@Product_Name,quantity=@Quantity,price=@Price,stock_value=@Stock_Value where product_Name=@Product_Name;";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@Product_Name", product_Name);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock_Value", stock_value);

                    cmd.ExecuteNonQuery();


                }
            }
        }
        public void delete(string product_Name)
        {
            using (SqlConnection connect = new SqlConnection(sqlConnect))
            {
                connect.Open();
                string deleteQuery = "DELETE FROM ProductStore WHERE product_Name=@Product_Name;";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@Product_Name", product_Name);

                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void displayingData()
        {
            using (SqlConnection connect = new SqlConnection(sqlConnect))
            {
                connect.Open();
                string displaying = "Select * FROM ProductStore";

                using (SqlCommand cmd = new SqlCommand(displaying, connect))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);


                }
            }
        }

    }
}
