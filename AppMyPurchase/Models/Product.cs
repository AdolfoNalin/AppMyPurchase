using SQLite;

namespace AppMyPurchase.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amout { get; set; }
        public double Price { get; set; }
    }
}
