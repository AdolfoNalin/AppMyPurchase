using SQLite;

namespace AppMyPurchase.Models
{
    public record class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double Total => Amount * Price;
    }
}
