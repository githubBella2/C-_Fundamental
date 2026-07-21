using Microsoft.AspNetCore.Mvc.RazorPages;

public interface IMedicineRepository
{
    // PagedResult<Medicine> GetAll(MedicineQueryRequest request);

    Medicine? GetById(int id);
    Medicine Add(CreateMedicineRequest request);
    // Medicine? Update(int id, UpdateMedicineRequest request);
    // bool Delete(int id);
}