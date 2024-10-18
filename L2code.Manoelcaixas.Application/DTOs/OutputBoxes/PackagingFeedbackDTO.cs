using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Application.DTOs.OutputBoxes
{
    public class PackagingFeedbackDTO
    {
        [JsonPropertyName("pedidos")]
        public List<OrdersFeedbackDTO> Orders { get; set; }
    }
}
