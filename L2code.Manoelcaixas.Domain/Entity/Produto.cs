using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Domain.Entity
{
    public class Produto
    {
        public string ProdutoId { get; set; }
        public Dimensoes Dimensoes { get; set; }
    }
}
