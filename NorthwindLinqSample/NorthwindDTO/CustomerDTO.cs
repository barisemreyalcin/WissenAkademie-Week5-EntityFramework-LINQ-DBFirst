using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindLinqSample.NorthwindDTO
{
    // İhtiyacım olan property'leri tanımlayacam
    public class CustomerDTO
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string Region{ get; set; }


    }
}
