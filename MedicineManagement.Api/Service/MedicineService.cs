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

    private readonly IMedicineRepository _repository;
    private readonly AppDbContext _context;
    public MedicineService(
            IMedicineRepository repository,
            AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public MedicineService(AppDbContext context)
    {
        _context = context;
    }

    public PagedResult<Medicine> GetAll(MedicineQueryRequest request)
        => _repository.GetAll(request);

    public async Task<Medicine> Add(CreateMedicineRequest request)
    {
        return await _repository.Add(request);
    }

    public async Task<Medicine?> GetById(int id)
    // public Medicine? GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public Task<Medicine?> Update(int id, UpdateMedicineRequest request)
    {
        return _repository.Update(id, request);
    }

    public bool Delete(int id)
    {

        return _repository.Delete(id);
        // Medicine? medicine = _context.Medicines.FirstOrDefault(m => m.Id == id);

        // if (medicine == null)
        // {
        //     return false;
        // }

        // _context.Medicines.Remove(medicine);
        // _context.SaveChanges();

        // return true;
    }

    public List<Medicine> Search(string keyword)
    {
        return _context.Medicines
        .Where(m => m.Name.Contains(keyword))
        .ToList();
    }


}