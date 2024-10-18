using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class ProductsDTO
    {
        [JsonPropertyName("produto_id")]
        public string ProductsId { get; set; }

        [JsonPropertyName("dimensoes")]
        public DimensionsDTO Dimensions { get; set; }

        [JsonIgnore]
        public bool ProductIsSmall { get; set; }

        [JsonIgnore]
        public bool HasBoxToThisProduct { get; set; }


    }
}
