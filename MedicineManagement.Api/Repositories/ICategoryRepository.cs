public interface ICategoryRespository
{
    Task<List<Category>> GetAll();
    // Task<Category?> GetById(int id);
    Task<Category> Add(CreateCategoryRequest request);
}