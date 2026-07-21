using System.ComponentModel.DataAnnotations;

public class CreateMedicineRequest
{
    [Required(ErrorMessage = "Nama wajib diisi")]
    public string Name { get; set; } = "";

    [Range(1, int.MaxValue, ErrorMessage = "Stock minimal 1")]
    public int Stock { get; set; }

    [Range(typeof(decimal), "1", "999999999", ErrorMessage = "Harga harus lebih dari 0 ")]
    public decimal Price { get; set; }

    
}