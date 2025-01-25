using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Services;
using MyProject.Interfaces;

namespace MyProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoesController : ControllerBase
{
    private IShoesService ShoesService;

    public ShoesController(IShoesService ShoesService)
    {
        this.ShoesService = ShoesService;
    }


    [HttpGet]
    public ActionResult<List<Shoes>> GetAll() => ShoesService.GetAll();

    [HttpGet(Name = "GetShoes")]
    public ActionResult<Shoes> Get(int id)
    {
        var shoes = ShoesService.Get(id);

        if (shoes == null)
            return NotFound();

        return shoes;
    }


    [HttpPost]
    public IActionResult Insert(Shoes shoes)
    {
        ShoesService.Add(shoes);
        return CreatedAtAction(nameof(Insert), new { id = shoes.Id }, shoes);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Shoes shoes)
    {
        if (id != shoes.Id)
            return BadRequest();

        var existingShoes = ShoesService.Get(id);
        if (existingShoes is null)
            return NotFound("Invalid ID");
        ShoesService.Update(existingShoes);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingShoes = ShoesService.Get(id);
        if (existingShoes is null)
            return NotFound("Invalid ID");
        ShoesService.Delete(id);
        // list.Remove(existingShoes);
        return NoContent();
    }
}