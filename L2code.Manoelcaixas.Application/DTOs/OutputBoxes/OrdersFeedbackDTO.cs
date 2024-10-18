using System.Text.Json.Serialization;

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
