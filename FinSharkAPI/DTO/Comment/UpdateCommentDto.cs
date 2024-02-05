using System.ComponentModel.DataAnnotations;

namespace FinSharkAPI.DTO.Comment
{
	public class UpdateCommentDto
	{
		[Required]
		[MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
		[MaxLength(10, ErrorMessage = "Title cannot be over 50 over characters")]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MinLength(10, ErrorMessage = "Content must be at least 10 characters")]
		[MaxLength(140, ErrorMessage = "Content cannot be over 140 over characters")]
		public string Content { get; set; } = string.Empty;
	}
}
