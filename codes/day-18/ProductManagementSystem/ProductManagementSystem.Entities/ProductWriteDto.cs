﻿namespace ProductManagementSystem.Entities
{
    public class ProductWriteDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
