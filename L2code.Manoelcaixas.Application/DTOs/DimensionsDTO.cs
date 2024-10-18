using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class DimensionsDTO
    {
        [JsonPropertyName("altura")]
        public decimal Height { get; set; }

        [JsonPropertyName("largura")]
        public decimal Width { get; set; }

        [JsonPropertyName("comprimento")]
        public decimal Length { get; set; }

        // Calcular o volume do produto
        [JsonIgnore]
        public decimal Volume => Height * Width * Length;
    }
}
