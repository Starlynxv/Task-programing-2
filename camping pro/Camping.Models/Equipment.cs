namespace Camping.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EquipmentStatus { get; set; } = "Disponible";
        public decimal PricePerDay { get; set; }
        public int CategoryId { get; set; }
    }
}