using MediatR;
namespace TotvsTest_Model
{
    public class ProductRequest: IRequest<IEnumerable<ProductDTO>>
    {
    }

    public enum ProductType
    {
        Final, 
        Intermediario, 
        Consumo, 
        MateriaPrima
    }

    public class ProductDTO
    {
        public string Description { get; set; }
        public double PriceSale { get; set; }
        public double PriceValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductType Type { get; set; }

        public double PriceGain { get; set; }
        public bool IsAvailable { get; set; }
    }
}
