using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _db;

    public TodoController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _db.Todos.ToListAsync();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoItem item)
    {
        _db.Todos.Add(item);
        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoItem item)
    {
        var todo = await _db.Todos.FindAsync(id);
        if(todo == null) return NotFound();

        todo.Title = item.Title;
        todo.IsCompleted = item.IsCompleted;
        await _db.SaveChangesAsync();
        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if(todo == null) return NotFound();

        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
        return Ok();
    }
}