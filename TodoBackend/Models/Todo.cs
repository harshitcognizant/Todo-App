using System.ComponentModel.DataAnnotations;
using TodoBackend.Enums;

namespace TodoBackend.Models
{
	public class Todo
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public StatusEnum Status { get; set; } = StatusEnum.Pending;

	}
}
