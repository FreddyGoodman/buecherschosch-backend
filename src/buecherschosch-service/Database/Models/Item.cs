using System.ComponentModel.DataAnnotations;

namespace buecherschosch_service.Database.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        public required string Sku { get; set; }

        public Item(decimal Price, decimal Discount, string Sku)
        {
            this.Price = Price;
            this.Discount = Discount;
            this.Sku = Sku;
        }
    }
}