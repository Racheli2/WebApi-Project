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
    // private static List<Shoes> list;
    // static ShoesController()
    // {
    //     list = new List<Shoes>
    //     {
    //         new Shoes { Id = 1, Name = "Sports", Size = 36, IsSale = true },
    //         new Shoes { Id = 2, Name = "Heel", Size = 37, IsSale = false },
    //         new Shoes { Id = 3, Name = "Rubber", Size = 34, IsSale = false },
    //         new Shoes { Id = 4, Name = "Crocs", Size = 35, IsSale = true }
    //     };
    // }

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
    // public IEnumerable<Shoes> Get()
    // {
    //     return list;
    // }

    // [HttpGet("{id}")]
    // public ActionResult<Shoes> Get(int id)
    // {
    //     var shoes = list.FirstOrDefault(s => s.Id == id);
    //     if (shoes == null)
    //         return NotFound("Invalid ID");

    //     return Ok(shoes);
    // }

    [HttpPost]
    public IActionResult Insert(Shoes shoes)
    {
        ShoesService.Add(shoes);
        return CreatedAtAction(nameof(Insert), new { id = shoes.Id }, shoes);
    }
    // public ActionResult<Shoes> Insert(Shoes shoes)
    // {
    //     var maxId = list.Any() ? list.Max(s => s.Id) : 0;
    //     shoes.Id = maxId + 1;
    //     list.Add(shoes);

    //     return CreatedAtAction(nameof(Get), new { id = shoes.Id }, shoes);
    // }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Shoes shoes)
    {
        if (id != shoes.Id)
            return BadRequest();

        var existingShoes = ShoesService.Get(id);
        if (existingShoes is null)
            return NotFound("Invalid ID");
        ShoesService.Update(existingShoes);

        // existingShoes.Name = shoes.Name;
        // existingShoes.Size = shoes.Size;
        // existingShoes.IsSale = shoes.IsSale;

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