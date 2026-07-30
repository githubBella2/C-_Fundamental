public interface IMedicineService
{
    Task<PagedResult<Medicine>> GetAll(MedicineQueryRequest request);

    Task<MedicineResponse> GetById(int id);

    Task<Medicine> Add(CreateMedicineRequest request);

    Task<Medicine?> Update(int id, UpdateMedicineRequest request);

    Task<bool> Delete(int id);

    Task<List<Medicine>> Search(string keyword);


}