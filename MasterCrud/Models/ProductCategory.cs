using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCrud.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; } = default!;
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    }
}
