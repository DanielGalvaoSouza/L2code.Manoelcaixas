using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class OrderDTO
    {
        [JsonPropertyName("pedido_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("produtos")]
        public List<ProductsDTO> Products { get; set; }

        [JsonIgnore]
        public List<Boxes>? Boxes { get; set; }
    }
}
