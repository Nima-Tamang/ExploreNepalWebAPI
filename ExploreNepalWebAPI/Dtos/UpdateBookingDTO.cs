namespace ImagesTesting.Models.Dtos
{
    public class UpdateBookingDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string SelectedSeason { get; set; }
        public string SortBy { get; set; }
        public decimal Price { get; set; }
       // public PaymentDTO PaymentDetails { get; set; }
    }
}
//public class PaymentDTO
//{
//    public string PaymentMethod { get; set; } // For example: Khalti
//    public decimal Amount { get; set; }
//    public string TransactionId { get; set; } // For Khalti Transaction ID
//    // Add more payment-related fields as needed
//}