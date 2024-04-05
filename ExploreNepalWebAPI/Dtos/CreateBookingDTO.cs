namespace ImagesTesting.Models.Dtos
{
    public class CreateBookingDTO
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
