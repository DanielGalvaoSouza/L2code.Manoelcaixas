using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class InputOrdersDTO
    {
        [JsonPropertyName("pedidos")]
        public List<OrderDTO> Orders { get; set; }
    }
}
