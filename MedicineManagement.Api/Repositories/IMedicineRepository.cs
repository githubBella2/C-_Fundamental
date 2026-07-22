using Microsoft.AspNetCore.Mvc.RazorPages;

public interface IMedicineRepository
{
    PagedResult<Medicine> GetAll(MedicineQueryRequest request);
    
    Task<Medicine> GetById(int id);
    // Medicine? GetById(int id);
    Task<Medicine> Add(CreateMedicineRequest request);
    bool Delete(int id);
    Task<Medicine?> Update(int id, UpdateMedicineRequest request);
}