using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicinesController : ControllerBase
{
    private readonly IMedicineService _medicineService;
   

    public MedicinesController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] MedicineQueryRequest request)
    {
        var medicines = await _medicineService.GetAll(request);

        return Ok(medicines);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(CreateMedicineRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var medicine = await _medicineService.Add(request);

        return Ok(medicine);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var medicine = await _medicineService.GetById(id);

        if (medicine == null)
        {
            return NotFound();
        }

        return Ok(medicine);
    }

    // UPDATE
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

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _medicineService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    // SEARCH
    [HttpGet("search")]
    public async Task<IActionResult> Search(string keyword)
    {
        var medicines = await _medicineService.Search(keyword);

        return Ok(medicines);
    }
}