using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoBackend.Data;
using TodoBackend.DTOs;
using TodoBackend.Enums;
using TodoBackend.Models;

namespace TodoBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController(AppDbContext appDbContext) : ControllerBase
	{
		

		[HttpGet("")]
		public async Task<IActionResult>GetAllTodos()
		{
			var todos = await appDbContext.Todos.ToListAsync();
			return Ok(todos);
		}

		[HttpGet("titles")]
		public async Task<IActionResult> GetAllTitle() 
		{
			//var list = await (from todos in appDbContext.Todos select new { Titles = todos.Title }).ToListAsync();
			var list = await (from todos in appDbContext.Todos select new { Title = todos.Title }).AsNoTracking().ToArrayAsync();
			return Ok(list);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTodoById([FromRoute] int id)
		{
			var todo = await appDbContext.Todos.FindAsync(id);
			if (todo == null) {
				return NotFound(new { message="Todo not found" });

			}
			return Ok(todo);
		}

		[HttpPost("")]
		public async Task<IActionResult> AddTodo([FromBody] Todo todo)
		{
			appDbContext.Todos.AddAsync(todo);
			await appDbContext.SaveChangesAsync();
			return Ok(todo);
		}


		[HttpPut("{Id}")]
		public async Task<IActionResult> UpdateTodo([FromRoute] int Id, [FromBody] UpdateTitleDescriptionDTO updateTitleDescriptionDTO)
		{
			var todo = await appDbContext.Todos.Where(x => x.Id == Id)
				.ExecuteUpdateAsync(x => x
				.SetProperty(p => p.Title, updateTitleDescriptionDTO.Title)
				.SetProperty(p => p.Description,p=> updateTitleDescriptionDTO.Description == null ? p.Description : updateTitleDescriptionDTO.Description)
				);

			return Ok(todo);
		}

		[HttpPut("{Id}/status")]
		public async Task<IActionResult> UpdateStatus([FromRoute] int Id, [FromQuery] StatusEnum status)
		{
			var isUpdated = await appDbContext.Todos.Where(x => x.Id == Id).ExecuteUpdateAsync(x =>
					x.SetProperty(p => p.Status , status)
			);
			return Ok(isUpdated);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteTodo(int Id) 
		{
			var todo = await appDbContext.Todos.Where(x => x.Id==Id).ExecuteDeleteAsync();
			return Ok(todo==0? new { message ="Todo not deleted or not avalilable in database"} : new { message = "Todo deleted from database" });
		}

		
	}
}
