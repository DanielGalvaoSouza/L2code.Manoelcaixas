using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Application.DTOs.OutputBoxes
{
    public class BoxesFeedbackDTO
    {
        [JsonPropertyName("caixa_id")]
        public string BoxeId { get; set; } // ID da Caixa (null se não houver caixa disponível)

        [JsonPropertyName("produtos")]
        public List<string> Produts { get; set; } // Lista de produtos que estão dentro da caixa

        [JsonPropertyName("observacao")]
        public string Note { get; set; }
    }
}
