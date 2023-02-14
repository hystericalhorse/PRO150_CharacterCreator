using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models {
	public class Accounts {
		[Key]
		public int ID { get; set; }
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; } = string.Empty;
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; } = string.Empty;

		//public string Email { get; set; } = string.Empty; Use this or UserName or both
		// Can possibly add more account data I just wanted to get the basics down
	}
}