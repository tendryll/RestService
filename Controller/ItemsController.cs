using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestService.Context;
using RestService.Model;

namespace RestService.controller;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItemsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Item>> GetItems() => await _context.Items.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> CreateItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}