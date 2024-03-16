using _02_HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

internal partial class Program
{
    public class Storoom
    {
        private SqlConnection connection;

        public Storoom(string conString)
        {
            connection = new SqlConnection(conString);
            connection.Open();
            Console.WriteLine("Connected");
        }

        private void SetCommandParams(ref SqlCommand command, Product product)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.Cost;
            command.Parameters.Add("@producer", System.Data.SqlDbType.Int).Value = product.SupplierId;
        }

        private void SetCommandParams(ref SqlCommand command, Supplier supplier)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = supplier.Name;
        }

        public void CreateProduct(Product product)
        {
            string cmdText = @"insert into Products 
                            values(@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SetCommandParams(ref command, product);
            command.ExecuteNonQuery();
        }

        public void CreateSupplier(Supplier supplier)
        {
            string cmdText = @"insert into Suppliers
                            values(@name)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SetCommandParams(ref command, supplier);
            command.ExecuteNonQuery();
        }

        public void UpdateProduct(Product product)
        {
            string cmdText = @"update Products
                               set
                                   Name = @name,
                                   TypeProduct = @type,
                                   Quantity = @quantity,
                                   Cost = @cost_price,
                                   SupplierId = @producer
                               where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SetCommandParams(ref command, product);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.Id;
            command.ExecuteNonQuery();
        }

        public void DeleteProduct(int id)
        {
            string cmdText = @"delete from Products
                               where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            string cmdText = @"update Suppliers
                               set
                                   Name = @name
                               where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SetCommandParams(ref command, supplier);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = supplier.Id;
            command.ExecuteNonQuery();
        }

        public void DeleteSupplier(int id)
        {
            string cmdText = @"delete from Suppliers
                               where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }

        private List<Product> GetProductQuery(SqlCommand command)
        {
            List<Product> products = new List<Product>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    Cost = (int)reader[4],
                    SupplierId = (int)reader[5],
                    SupplyDate = reader[6].ToString()
                });
            }
            reader.Close();
            return products;
        }

        private List<Supplier> GetSupplierQuery(SqlCommand command)
        {
            List<Supplier> suppliers = new List<Supplier>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                suppliers.Add(new Supplier()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1]
                });
            }
            reader.Close();
            return suppliers;
        }

        public List<Product> GetAllProducts()
        {
            string cmdText = "select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return GetProductQuery(command);
        }

        public List<Supplier> GetAllSuppliers()
        {
            string cmdText = "select * from Suppliers";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return GetSupplierQuery(command);
        }
    }
}
