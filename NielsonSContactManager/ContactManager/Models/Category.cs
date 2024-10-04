namespace ContactManager.Models
{
    public class Category
    {
        // properties for CategoryId name, set to empty string as we don't want it to be null
        public string CategoryId { get; set; } = string.Empty;

        // properties for Category name, set to empty string as we don't want it to be null
        public string Name { get; set; } = string.Empty;
    }
}
