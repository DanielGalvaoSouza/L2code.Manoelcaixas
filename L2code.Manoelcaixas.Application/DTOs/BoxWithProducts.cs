using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class BoxWithProducts
    {
        public int OrderId { get; set; }
        public Boxes Box { get; set; }
        public ProductsDTO Product { get; set; }
    }
}
