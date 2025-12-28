namespace ControlGastosApp.Models
{
    public class Period
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public string DisplayName => $"{Year:D4}-{Month:D2}";
    }
}