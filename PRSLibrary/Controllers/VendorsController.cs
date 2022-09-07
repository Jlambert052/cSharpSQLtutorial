using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PRSLibrary.Models;

namespace PRSLibrary.Controllers {

    public class VendorsController {

        public Connection connection = null;
        public VendorsController(Connection conn) {
            connection = conn;
        }

        public IEnumerable<Vendor> GetAllVendors() {
            string sql = "SELECT * FROM Vendors;";
            SqlCommand cmd = new(sql, connection.sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Vendor> vendors = new();
            while (reader.Read()) {
                Vendor vendor = new();
                vendor.Id = Convert.ToInt32(reader["Id"]);
                vendor.Code = Convert.ToString(reader["Code"]);
                vendor.Name = Convert.ToString(reader["Name"]);
                vendor.Address = Convert.ToString(reader["Address"]);
                vendor.City = Convert.ToString(reader["City"]);
                vendor.State = Convert.ToString(reader["State"]);
                vendor.Zip = Convert.ToString(reader["Zip"]);
                if (reader["Phone"] == System.DBNull.Value) {
                    vendor.Phone = null;
                } else {
                    Convert.ToString(reader["Phone"]);
                }
                if (reader["Email"] == System.DBNull.Value) {
                    vendor.Email = null;
                } else {
                    Convert.ToString(reader["Email"]);
                }
                vendors.Add(vendor);
            }
            reader.Close();
            return vendors;
        }

        public Vendor? GetByPk(int id) {
            string sql = $"SELECT * FROM Vendors Where Id = {id}; ";
            SqlCommand cmd = new(sql, connection.sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if(!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            Vendor vendor = new();
            vendor.Id = Convert.ToInt32(reader["Id"]);
            vendor.Code = Convert.ToString(reader["Code"]);
            vendor.Name = Convert.ToString(reader["Name"]);
            vendor.Address = Convert.ToString(reader["Address"]);
            vendor.City = Convert.ToString(reader["City"]);
            vendor.State = Convert.ToString(reader["State"]);
            vendor.Zip = Convert.ToString(reader["Zip"]);
            if (reader["Phone"] == System.DBNull.Value) {
                vendor.Phone = null;
            } else {
                Convert.ToString(reader["Phone"]);
            }
            if (reader["Email"] == System.DBNull.Value) {
                vendor.Email = null;
            } else {
                Convert.ToString(reader["Email"]);
            }
            reader.Close();
            return vendor;

        }

        public bool Delete(int id) {
            string sql = $"DELETE FROM Vendors Where ID is {id}; ";
            SqlCommand cmd = new(sql, connection.sqlConnection);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1) { 
            return false;
            }
            return true;
        }
        
        public bool Insert(Vendor vendor) {
            string sql = "INSERT into Vendors" +
                        "(Code, Name, Address, City " +
                        " State, Zip, Phone, Email) VALUES " +
                        "(@Code, @Name, @Address, @City " +
                        "@State, @Zip, @Phone, @Email);";
            SqlCommand cmd = new(sql, connection.sqlConnection);
            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@Email", vendor.Email);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1) {
                return false;
            }
            return true;
        }

        public bool Update(Vendor vendor) {
            string sql = "UPDATE Vendors SET" +
                        " Code = @Code, " +
                        " Name = @Name, " +
                        " Address = @Address, " +
                        " City = @City, " +
                        " State = @State, " +
                        " Zip = @Zip, " +
                        " Phone = @Phone, " +
                        " Email = @Email, " +
                        "Where ID = @Id;";
            SqlCommand cmd = new(sql, connection.sqlConnection);
            cmd.Parameters.AddWithValue("@Code", vendor.Code);
            cmd.Parameters.AddWithValue("@Name", vendor.Name);
            cmd.Parameters.AddWithValue("@Address", vendor.Address);
            cmd.Parameters.AddWithValue("@City", vendor.City);
            cmd.Parameters.AddWithValue("@State", vendor.State);
            cmd.Parameters.AddWithValue("@Zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@Phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@Email", vendor.Email);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected != 1) {
                return false;
            }
            return true;
        }

    }
}
