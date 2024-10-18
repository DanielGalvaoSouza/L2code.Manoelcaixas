using System.Text.Json.Serialization;

namespace L2code.Manoelcaixas.Application.DTOs
{
    public class Boxes
    {
        public Boxes(string boxId, decimal height, decimal width, decimal length)
        {
            BoxId = boxId;

            Dimensions = new DimensionsDTO();
            Dimensions.Height = height;
            Dimensions.Width = width;
            Dimensions.Length = length;
        }

        public Boxes()
        {

        }

        [JsonPropertyName("caixa_id")]
        public string BoxId { get; set; }

        [JsonIgnore]
        public DimensionsDTO Dimensions { get; set; }

        // Lista de produtos alocados na caixa
        public List<ProductsDTO> Products { get; set; } = new List<ProductsDTO>();

        // Calcular o volume ocupado pela soma dos produtos na caixa
        public decimal VolumeOccupied => Products.Sum(p => p.Dimensions.Volume);

        // Calcular o volume disponível
        public decimal VolumeAvailable => Dimensions.Volume - VolumeOccupied;

    }
}
