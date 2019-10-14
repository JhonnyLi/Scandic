namespace BookingService
{
    public class Hotel
    {
        public string Name { get; set; }
        public Country CountryCode { get; set; }
    }
    public enum Country
    {
        SE,
        DK,
        DE
    }
}

