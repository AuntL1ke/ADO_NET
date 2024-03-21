
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AeroportDb context = new AeroportDb();

            context.Airplanes.Add(new Airplane()
            {
                Model = "Boieng=777",
                MaxPassangers=300,
                Country="Spain"
            }) ;
            context.SaveChanges();
        }
    }
}
