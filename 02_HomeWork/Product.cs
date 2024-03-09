using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_HomeWork
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public int SupplierId {  get; set; }
        public string SupplyDate { get; set; }


        public override string ToString()
        {
            return $"Id:{Id,-5} Name:{Name,-15} Type:{Type,-15} Quantity:{Quantity,-5} CostPrice:{Cost,-5} Producer:{SupplierId,-10} Date:{SupplyDate,-5}";
        }
    }
}
