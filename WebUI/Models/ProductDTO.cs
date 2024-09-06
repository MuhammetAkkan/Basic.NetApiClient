using System.Text.Json.Serialization;

namespace WebUI.Models
{
    public class ProductDTO
    {
        //Api projesindeki ProductDTO as

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = null!;
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
