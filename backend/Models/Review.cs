namespace MyntraCloneBackend.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
