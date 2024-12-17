using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoesController: ControllerBase
{
    private static List<Shoes> list;
        static ShoesController()
    {
        list = new List<Shoes>
        {
            new Shoes { Id = 1, Name = "Sports", Size = 36, IsSale = true },
            new Shoes { Id = 2, Name = "Heel", Size = 37, IsSale = false },
            new Shoes { Id = 3, Name = "Rubber", Size = 34, IsSale = false },
            new Shoes { Id = 4, Name = "Crocs", Size = 35, IsSale = true }
        };
    }

    [HttpGet(Name = "GetShoes")]
    public IEnumerable<Shoes> Get()
    {
        return list;
    }

    [HttpGet("{id}")]
    public ActionResult<Shoes> Get(int id)
    {
        var shoes = list.FirstOrDefault(s => s.Id == id);
        if (shoes == null)
            return NotFound("Invalid ID");

        return Ok(shoes);
    }

    [HttpPost]
    public ActionResult<Shoes> Insert(Shoes newShoes)
    {
        var maxId = list.Any() ? list.Max(s => s.Id) : 0;
        newShoes.Id = maxId + 1;
        list.Add(newShoes);

        return CreatedAtAction(nameof(Get), new { id = newShoes.Id }, newShoes);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Shoes newShoes)
    {
        var oldShoes = list.FirstOrDefault(s => s.Id == id);
        if (oldShoes == null)
            return NotFound("Invalid ID");

        if (newShoes.Id != oldShoes.Id)
            return BadRequest("ID mismatch");

        oldShoes.Name = newShoes.Name;
        oldShoes.Size = newShoes.Size;
        oldShoes.IsSale = newShoes.IsSale;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var oldShoes = list.FirstOrDefault(s => s.Id == id);
        if (oldShoes == null)
            return NotFound("Invalid ID");

        list.Remove(oldShoes);
        return NoContent();
    }
}