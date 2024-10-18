using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Domain.Entity
{
    public class Products
    {
        [JsonPropertyName("produto_id")]
        public string ProductsId { get; set; }

        [JsonPropertyName("dimensoes")]
        public Dimensions Dimensions { get; set; }
    }
}
