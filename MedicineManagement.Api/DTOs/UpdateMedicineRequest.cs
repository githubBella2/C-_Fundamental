using System.ComponentModel.DataAnnotations;

public class UpdateMedicineRequest
{
    [Required(ErrorMessage ="Nama wajib diisi")]
    public string Name {get; set;} ="";
    
    [Range(1, int.MaxValue)]
    public int Stock {get; set;} 
    
    [Range(typeof(decimal), "1","999999999")]
    public decimal Price {get; set;}
}