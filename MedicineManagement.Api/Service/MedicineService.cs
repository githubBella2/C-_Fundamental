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
    public PagedResult<Medicine> GetAll(MedicineQueryRequest request)
    // public PagedResult<Medicine> GetAll(int page, int pageSize, string sort)
    {
        if (request.Page <= 0)
            request.Page = 1;

        if (request.PageSize <= 0)
            request.PageSize = 10;

        if (string.IsNullOrWhiteSpace(request.Sort))
            request.Sort = "id";
        int totalData = _context.Medicines.Count();

        IQueryable<Medicine> query = _context.Medicines;
        // Filter
        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(m => m.Name.Contains(request.Name));
        }
         if (request.MinPrice.HasValue)
        {
            query = query.Where(m => m.Price >= request.MinPrice.Value);
        }
         if(request.MaxPrice.HasValue)
        {
            query = query.Where(m => m.Price <= request.MaxPrice.Value);
            
        }

        // Sort / urutkan
        if (request.Sort.ToLower() == "name")
        {
            query = query.OrderBy(m => m.Name);
        }
        else if (request.Sort.ToLower() == "price")
        {
            query = query.OrderBy(m => m.Price);
        }
        else if (request.Sort.ToLower() == "stock")
        {
            query = query.OrderBy(m => m.Stock);
        }
        else
        {
            query = query.OrderBy(m => m.Id);
        }


        List<Medicine> medicines = query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<Medicine>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalData = totalData,
            TotalPages = (int)Math.Ceiling((double)totalData / request.PageSize),
            Data = medicines
        };
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

    public Medicine? Update(int id, UpdateMedicineRequest request)
    {
        Medicine? medicine = _context.Medicines.FirstOrDefault(m => m.Id == id);
        if (medicine == null)
        {
            return null;
        }

        medicine.Name = request.Name;
        medicine.Stock = request.Stock;
        medicine.Price = request.Price;


        // _context.Medicines.Update(medicine);
        _context.SaveChanges();

        return medicine;
    }

    public bool Delete(int id)
    {
        Medicine? medicine = _context.Medicines.FirstOrDefault(m => m.Id == id);

        if (medicine == null)
        {
            return false;
        }

        _context.Medicines.Remove(medicine);
        _context.SaveChanges();

        return true;
    }

    public List<Medicine> Search(string keyword)
    {
        return _context.Medicines
        .Where(m => m.Name.Contains(keyword))
        .ToList();
    }
}