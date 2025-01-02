namespace Recipes.UI.Models
{
    public class Recipe
    {
        public required int ID { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdateBy { get; set; }
        public int Category { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
