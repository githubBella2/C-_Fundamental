using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class MedicineRepository : IMedicineRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MedicineRepository(AppDbContext context)
    {
        _context = context;
    }

    public MedicineRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PagedResult<Medicine>> GetAll(MedicineQueryRequest request)
    {
        if (request.Page <= 0)
            request.Page = 1;

        if (request.PageSize <= 0)
            request.PageSize = 10;

        if (string.IsNullOrWhiteSpace(request.Sort))
            request.Sort = "id";

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

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(m => m.Price <= request.MaxPrice.Value);
        }

        // Total data SETELAH FILTER
        int totalData = await query.CountAsync();

        // Sorting
        switch (request.Sort.ToLower())
        {
            case "name":
                query = query.OrderBy(m => m.Name);
                break;

            case "price":
                query = query.OrderBy(m => m.Price);
                break;

            case "stock":
                query = query.OrderBy(m => m.Stock);
                break;

            default:
                query = query.OrderBy(m => m.Id);
                break;
        }

        List<Medicine> medicines = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new PagedResult<Medicine>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalData = totalData,
            TotalPages = (int)Math.Ceiling((double)totalData / request.PageSize),
            Data = medicines
        };
    }

    public async Task<Medicine?> GetById(int id)
    {
        return await _context.Medicines
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Medicine> Add(CreateMedicineRequest request)
    {
        Medicine medicine = _mapper.Map<Medicine>(request);

        _context.Medicines.Add(medicine);

        await _context.SaveChangesAsync();

        return medicine;
    }

    public async Task<Medicine?> Update(int id, UpdateMedicineRequest request)
    {
        Medicine? medicine = await _context.Medicines
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medicine == null)
        {
            return null;
        }

        _mapper.Map(request, medicine);

        await _context.SaveChangesAsync();

        return medicine;
    }

    public async Task<bool> Delete(int id)
    {
        Medicine? medicine = await _context.Medicines
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medicine == null)
        {
            return false;
        }

        _context.Medicines.Remove(medicine);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Medicine>> Search(string keyword)
    {
        return await _context.Medicines
            .Where(m => m.Name.Contains(keyword))
            .ToListAsync();
    }
}