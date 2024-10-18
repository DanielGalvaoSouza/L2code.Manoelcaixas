using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.DTOs.OutputBoxes
{
    public class OrdersFeedbackDTO
    {
        [JsonPropertyName("pedido_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("caixas")]
        public List<BoxesFeedbackDTO> Boxes { get; set; }
    }
}
