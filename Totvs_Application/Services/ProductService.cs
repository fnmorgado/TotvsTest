using MediatR;
using TotvsTest_Model;

namespace Totvs_Application.Services
{
    public class ProductService: IRequestHandler<ProductRequest, IEnumerable<ProductDTO>>
    {
        private List<ProductDTO> products = new List<ProductDTO>();

        public ProductService() { }

        public async Task<IEnumerable<ProductDTO>> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            await LoadProduct();

            await ValidateProduct();

            await SetPriceGain();

            var result = products.Where(s => s.IsAvailable).OrderByDescending(o => o.PriceGain).Take(3).OrderBy(o => o.Type);

            return result;
        }

        private async Task LoadProduct()
        {
            products.Add(new ProductDTO() { Description = "Product 1", PriceValue = 50, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 2", PriceValue = 60, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 3", PriceValue = 70, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 4", PriceValue = 80, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 5", PriceValue = 90, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });

            products.Add(new ProductDTO() { Description = "Product 11", PriceValue = 100, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 12", PriceValue = 100, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 13", PriceValue = 100, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 14", PriceValue = 100, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 15", PriceValue = 100, PriceSale = 100, Type = ProductType.Final, CreatedDate = DateTime.Now });

            products.Add(new ProductDTO() { Description = "Product 21", PriceValue = 200, PriceSale = 200, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 22", PriceValue = 200, PriceSale = 200, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 23", PriceValue = 200, PriceSale = 200, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 24", PriceValue = 200, PriceSale = 200, Type = ProductType.Final, CreatedDate = DateTime.Now });
            products.Add(new ProductDTO() { Description = "Product 25", PriceValue = 200, PriceSale = 200, Type = ProductType.Final, CreatedDate = DateTime.Now });
        }

        private async Task ValidateProduct()
        {
            foreach (var product in products)
            {
                bool available = true;

                if (product.PriceValue >= product.PriceSale)
                    available = false;

                if (product.CreatedDate.Year < 2024)
                    available = false;

                if (product.Description.Length < 5)
                    available = false;

                if (product.PriceValue <= 0)
                    available = false;

                if (product.PriceSale <= 0)
                    available = false;

                product.IsAvailable = available;
            }
        }

        private async Task SetPriceGain()
        {
            foreach (var product in products.Where(s => s.IsAvailable == true).ToList())
                product.PriceGain = product.PriceSale - product.PriceValue;
        }

    }
}
