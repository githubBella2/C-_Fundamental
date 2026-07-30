using AutoMapper;

public class MedicineProfile:Profile
{
    public MedicineProfile()
    {
        CreateMap<CreateMedicineRequest, Medicine>();
        CreateMap<UpdateMedicineRequest, Medicine>();
        CreateMap<Medicine, MedicineResponse>();
    }
}