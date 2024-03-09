using _02_HomeWork;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
internal partial class Program
{
    public class Storoom
    {
        SqlConnection connection;
        public Storoom(string conString)
        {
            connection = new SqlConnection(conString);
            connection.Open();
            Console.WriteLine("Connected");
        }

        private void setCommandParams(ref SqlCommand command, Product product)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.Cost;
            command.Parameters.Add("@producer", System.Data.SqlDbType.Int).Value = product.SupplierId;
            command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.SupplyDate;
        }
        private void setCommandParams(ref SqlCommand command, Supplier supplier)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = supplier.Name;
           
        }


        public void GetCommand()
        {
            while (true)
            {
                Console.Write("Enter a command: ");
                string cmd = Console.ReadLine();
                if (cmd.ToLower() == "exit")
                {
                    break;
                }
                if (cmd.ToLower().Contains("insert") || cmd.ToLower().Contains("update") || cmd.ToLower().Contains("delete"))
                {
                    Execute(cmd);
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }

        public void Execute(string cmd)
        {
            try
            {
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command: {ex.Message}");
            }
        }





    }

}