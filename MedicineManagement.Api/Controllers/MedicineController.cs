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
    // public IActionResult Get(int page =1, int pageSize=10, string sort= "id")
    public IActionResult Get([FromQuery] MedicineQueryRequest request)
    {
        var medicines = _medicineService.GetAll(request);
        // var medicines = _medicineService.GetAll(page,pageSize,sort);
        return Ok(medicines);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateMedicineRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var medicine = _medicineService.Add(request);
        return Ok(medicine);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medicine = _medicineService.GetById(id);
        if (medicine == null)
        {
            return NotFound();
        }
        return Ok(medicine);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMedicineRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var medicine = await _medicineService.Update(id, request);
        if (medicine == null)
        {
            return NotFound();
        }

        return Ok(medicine);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var medicine = _medicineService.Delete(id);
        return Ok(medicine);
    }


    [HttpGet("search")]
    public IActionResult Search(string keyword)
    {
        var medicines = _medicineService.Search(keyword);
        return Ok(medicines);
    }

}