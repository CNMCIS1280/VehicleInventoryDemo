
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace VehicleInventory
{
    /// <summary>
    /// Database access service for Vehicle Table
    /// </summary>
    public class VehicleService
    {

        public List<Vehicle> GetAll()
        {
            List<Vehicle> items = new List<Vehicle>();
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string select = "SELECT * FROM Vehicle;";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle item = new Vehicle();
                    item.Id = reader.GetInt32(0);
                    item.VIN = reader.GetString(1);
                    item.Mileage = reader.GetDouble(2);
                    item.Model = reader.GetString(3);
                    item.Make = reader.GetString(4);
                    item.Remarks = reader.GetString(5);
                    item.LastOilChange = reader.GetDouble(6);
                    item.Year = reader.GetInt32(7);
                    item.Color = reader.GetString(8);
                    items.Add(item);
                }
                conn.Close();
            }
            return items;
        }

        public void AddItem(Vehicle item)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"INSERT INTO Vehicle (VIN, Mileage, Model, Make, Remarks, LastOilChange, Year, Color) VALUES (@VIN, @Mileage, @Model, @Make, @Remarks, @LastOilChange, @Year, @Color);";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("VIN", item.VIN);
                cmd.Parameters.AddWithValue("Mileage", item.Mileage);
                cmd.Parameters.AddWithValue("Model", item.Model);
                cmd.Parameters.AddWithValue("Make", item.Make);
                cmd.Parameters.AddWithValue("Remarks", item.Remarks);
                cmd.Parameters.AddWithValue("LastOilChange", item.LastOilChange);
                cmd.Parameters.AddWithValue("Year", item.Year);
                cmd.Parameters.AddWithValue("Color", item.Color);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteItem(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"DELETE FROM Vehicle WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateItem(Vehicle item)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string cmdStr = @"UPDATE Vehicle SET VIN = @VIN, Mileage = @Mileage, Model = @Model, Make = @Make, Remarks= @Remarks, LastOilChange= @LastOilChange, Year= @Year, Color= @Color WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                cmd.Parameters.AddWithValue("Id", item.Id);
                cmd.Parameters.AddWithValue("VIN", item.VIN);
                cmd.Parameters.AddWithValue("Mileage", item.Mileage);
                cmd.Parameters.AddWithValue("Model", item.Model);
                cmd.Parameters.AddWithValue("Make", item.Make);
                cmd.Parameters.AddWithValue("Remarks", item.Remarks);
                cmd.Parameters.AddWithValue("LastOilChange", item.LastOilChange);
                cmd.Parameters.AddWithValue("Year", item.Year);
                cmd.Parameters.AddWithValue("Color", item.Color);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
