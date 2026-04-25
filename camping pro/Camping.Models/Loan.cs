namespace Camping.Models
{
    public class Loan
    {
        public int Id { get; set; }


        public int CustomerId { get; set; }


        public int EquipmentId { get; set; }


        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Activo";
    }
}