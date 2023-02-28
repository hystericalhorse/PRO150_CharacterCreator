using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
	public class AccountController : Controller {
		IDataAccessLayer DAL;
		public AccountController(IDataAccessLayer indal) {
			DAL = indal;
		}

		public IActionResult Index() {
			return View();
		}

		[HttpGet]
		public IActionResult Login() {
			return View();
		}

		// These paramaters are the old way of saving, once we get connected to a database this method can be updated to save to a DB
		[HttpPost]
		public IActionResult Login(string Username, string Password) {
			if (ModelState.IsValid) {
				TempData["LoggedIn"] = "Successfully logged in";
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateAccount() {
			return View();
		}

		// These paramaters are the old way of saving, once we get connected to a database this method can be updated to save to a DB
		[HttpPost]
		public IActionResult CreateAccount(string Username, string Password) {
			if (ModelState.IsValid) {
				TempData["Success"] = "Account Created";
			}
			return View();
		}

		[Authorize]
		[HttpGet]
		public IActionResult Profile() { // Loads the profile page
			return View();
		}

		// Updates the profile page with the new values
		[Authorize]
		[HttpPost]
		public IActionResult Profile(string Bio, string Username, string Email, string Password) { // Once we get a database we can send in an account object to update
			TempData["Success"] = "Profile updated";
			ViewBag.Username = Username;
			ViewBag.Bio = Bio;
			ViewBag.Email = Email;
			ViewBag.Password = Password;
			return View();
		}
	}
}
