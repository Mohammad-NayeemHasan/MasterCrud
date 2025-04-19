using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCrud.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = default!;
        public string ProductNumber { get; set; } = default!;
        public string Color { get; set; } = default!;
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int Size { get; set; }
        public decimal Weight { get; set; }
    }
}
