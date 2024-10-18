using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L2code.Manoelcaixas.Application.DTOs.OutputBoxes
{
    public class PackagingFeedbackDTO
    {
        [JsonPropertyName("pedidos")]
        public List<OrdersFeedbackDTO> Orders { get; set; }
    }
}
