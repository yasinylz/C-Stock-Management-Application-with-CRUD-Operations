using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜrünStokUygulaması
{
    public class ProductsDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETry;integrated security=true");

        public List<Pruduct> GetAll()
        {
            connetionsControl();

             SqlCommand command = new SqlCommand("Select*from product", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Pruduct> producters = new List<Pruduct>();
            while (reader.Read())
            {
                Pruduct pruduct = new Pruduct {

                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Stok = Convert.ToInt32(reader["Stok"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                      
                    
                   





            };
                producters.Add(pruduct);

            }

            _connection.Close();
            reader.Close();

            return producters;

        }
        public void Add(Pruduct pruduct)
        {
            connetionsControl();
            SqlCommand cmd = new SqlCommand("Insert into product values(@name,@price,@stok)", _connection);
            cmd.Parameters.AddWithValue("@name", pruduct.Name);
            cmd.Parameters.AddWithValue("@price", pruduct.Price);
            cmd.Parameters.AddWithValue("@stok", pruduct.Stok);
            cmd.ExecuteNonQuery();
            _connection.Close();


        }
        public void Update(Pruduct pruduct)
        {
            connetionsControl();
            SqlCommand cmd = new SqlCommand("Update product set Name=@name,Price=@price,Stok=@stok where Id=@id", _connection);
            cmd.Parameters.AddWithValue("@name", pruduct.Name);
            cmd.Parameters.AddWithValue("@price", pruduct.Price);
            cmd.Parameters.AddWithValue("@stok", pruduct.Stok);
            cmd.Parameters.AddWithValue("@id", pruduct.Id);

            cmd.ExecuteNonQuery();
            _connection.Close();


        }
        public void Delete(int id)
        {
            connetionsControl();
            SqlCommand cmd = new SqlCommand("Delete from product where Id=@id", _connection);
           
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            _connection.Close();


        }
        public DataTable GetAll2()
        {

            connetionsControl();
            SqlCommand command = new SqlCommand("Select*from product", _connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable databse = new DataTable();
            databse.Load(reader);
            _connection.Close();
            reader.Close();
            return databse;

        }
        public void connetionsControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
