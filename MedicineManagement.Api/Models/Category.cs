public class Category
{
    public int Id {get;set;}
    public string Name {get;set;} ="";

    // 1 category punya banyak Medicine
    public List<Medicine> Medicines {get;set;} = new();
}