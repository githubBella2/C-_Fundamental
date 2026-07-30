using AutoMapper;

public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _repository;
    private readonly IMapper _mapper;
    public MedicineService(IMedicineRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<PagedResult<Medicine>> GetAll(MedicineQueryRequest request)
    {
        return _repository.GetAll(request);
    }

    public Task<Medicine> Add(CreateMedicineRequest request)
    {
        return _repository.Add(request);
    }

    public async Task<MedicineResponse> GetById(int id)
    {
        Medicine? medicine = await _repository.GetById(id);
        if (medicine == null)
        {
            return null;
        }
        return _mapper.Map<MedicineResponse>(medicine);
    }

    public Task<Medicine?> Update(int id, UpdateMedicineRequest request)
    {
        return _repository.Update(id, request);
    }

    public Task<bool> Delete(int id)
    {
        return _repository.Delete(id);
    }

    public Task<List<Medicine>> Search(string keyword)
    {
        return _repository.Search(keyword);
    }
}