namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductCommandViewModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
