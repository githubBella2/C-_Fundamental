public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Stock { get; set; }
    public decimal Price { get; set; }

    // relasi kategori dan medicine
    public int CategoryId{get;set;}
    public Category? Category{get;set;}
    
}