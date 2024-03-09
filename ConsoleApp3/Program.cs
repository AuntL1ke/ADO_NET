using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // В цій програмі є захист, користувач може вводити запити тільки з select і не зможе змінити чи завдати шкоди програмі

            string conn = "Data Source=DESKTOP-JGNME93;Initial Catalog=Salings;Integrated Security=True;Connect Timeout=2";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            Console.WriteLine("Connected");
            string injection = "select";
            while (true)
            {
                Console.Write("Enter a command: ");
                string cmd = Console.ReadLine();
                if(cmd.ToLower() == "exit")
                {
                    break;
                }
                if(cmd.ToLower().Contains(injection))
                {
                    using (SqlCommand command = new SqlCommand(cmd, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),16}");
                            }
                            Console.WriteLine();
                            Console.WriteLine(new string('-', 120));

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i],16}");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("command prohibited");
                }
               
            }

            connection.Close();
        }
    }
}
