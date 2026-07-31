using System.ComponentModel.DataAnnotations;

public class CreateCategoryRequest
{
    [Required]
    public string Name { get; set; } = "";
}