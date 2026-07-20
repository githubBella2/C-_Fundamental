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
    public IActionResult Get([FromQuery] MedicineQueryRequest request )
    {
        var medicines = _medicineService.GetAll(request);
        // var medicines = _medicineService.GetAll(page,pageSize,sort);
        return Ok(medicines);
    }


    [HttpPost]
    public IActionResult Create(CreateMedicineRequest request)
    {
        // Validasi Nama
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Nama obat wajib diisi");
        }

        // Validasi Stock
        if (request.Stock < 0)
        {
            return BadRequest("Stock tidak boleh negatif");
        }

        // Validasi harga
        if (request.Price <= 0)
        {
            return BadRequest("Harga harus lebih dari 0");
        }

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

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateMedicineRequest request)
    {
        var medicine = _medicineService.Update(id, request);
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