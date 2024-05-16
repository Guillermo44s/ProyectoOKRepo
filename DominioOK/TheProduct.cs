using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioOK
{
    public class TheProduct
    {
        public int IdProduct {  get; set; }
        public string Product {  get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public bool Available { get; set; }    
        public int Cant {  get; set; }
    }
}
