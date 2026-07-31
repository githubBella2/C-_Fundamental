using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRespository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

   public async Task<Category> Add(CreateCategoryRequest request)
    {
        Category category = _mapper.Map<Category>(request);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
}