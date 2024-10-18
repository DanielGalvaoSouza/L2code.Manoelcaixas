using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Domain.Entity
{
    public class Boxes
    {
        [JsonPropertyName("pedidos")]
        public List<Order> Orders { get; set; }
    }
}
