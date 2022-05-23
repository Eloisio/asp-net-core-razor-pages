using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TWTodoList.Data;
using TWTodoList.Models;

namespace TWTodoList.Pages.Todos;

public class IndexModel : PageModel
{
    public ICollection<Todo> Todos { get; set; } = new List<Todo>();

    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Listagem de Tarefas";
        Todos = _context.Todos.OrderBy(x => x.Date).ToList();
    }

    public IActionResult OnGetDelete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        _context.Remove(todo);
        _context.SaveChanges();
        return RedirectToPage();
    }
}