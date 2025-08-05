namespace WidgetApi.Models
{
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
    }
}
