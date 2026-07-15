using Microsoft.AspNetCore.Mvc;
namespace MedicineManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicinesController : ControllerBase
{
    private readonly MedicineService _medicineService;
    public MedicinesController(MedicineService medicineService)
    {
        _medicineService = medicineService;
    }


    [HttpGet]
    public IActionResult Get()
    {
        var medicines = _medicineService.GetAll();
        return Ok(medicines);
    }


    [HttpPost]
    public IActionResult Create(CreateMedicineRequest request)
    {
        var medicine = _medicineService.Add(request);
        return Ok(medicine);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var medicine = _medicineService.GetById(id);
        if (medicine == null)
        {
            return NotFound();
        }
        return Ok(medicine);
    }
}