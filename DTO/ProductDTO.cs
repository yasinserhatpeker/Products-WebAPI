namespace ProductsAPI.DTO
{
    public class ProductDTO
    {
         public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

    }
}