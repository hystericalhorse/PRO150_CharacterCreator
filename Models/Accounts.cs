using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models {
	public class Accounts {
		[Key]
		public int ID { get; set; }
		public int CharacterID { get; set; }
		public string UserID { get; set; } = string.Empty;
		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; } = string.Empty; 
		public string? Description { get; set; }
		public string? Image { get; set; } // This is if we have the time to do it
	}
}