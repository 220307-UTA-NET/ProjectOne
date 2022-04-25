using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndieGameStoreConsole2.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int customerID { get; set; }
        public int productID { get; set; }
    }
}
