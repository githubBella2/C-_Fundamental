public class MedicineRepository : IMedicineRepository
{
    private readonly AppDbContext _context;
    public MedicineRepository(AppDbContext context)
    {
        _context = context;
    }

    public Medicine? GetById(int id)
    {
        return _context.Medicines.FirstOrDefault(m => m.Id == id);
    }

    public Medicine Add(CreateMedicineRequest request)
    {
        Medicine medicine = new Medicine
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price
        };

        _context.Medicines.Add(medicine);
        _context.SaveChanges();

        return medicine;
    }


    
}