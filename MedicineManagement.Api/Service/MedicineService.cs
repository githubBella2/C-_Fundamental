public class MedicineService
{
    // private readonly List<Medicine> medicines = new()
    // {
    //     new Medicine
    //     {
    //         Id = 1,
    //         Name = "Paracetamol",
    //         Stock = 100,
    //         Price = 5000
    //     },

    //     new Medicine
    //     {
    //         Id = 2,
    //         Name = "Amoxicillin",
    //         Stock = 50,
    //         Price = 10000
    //     }
    // };

    private readonly AppDbContext _context;
    public MedicineService(AppDbContext context)
    {
        _context = context;
    }
    public List<Medicine> GetAll()
    {
        return _context.Medicines.ToList();
        // return medicines;
    }

    public Medicine Add(CreateMedicineRequest request)
    {
        Medicine medicine = new Medicine
        {
            // Id = medicines.Count + 1,
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price
        };
        _context.Medicines.Add(medicine);
        _context.SaveChanges();
        // medicines.Add(medicine);
        return medicine;
    }

    public Medicine? GetById(int id)
    {
        return _context.Medicines.FirstOrDefault(m => m.Id == id);
    }

}