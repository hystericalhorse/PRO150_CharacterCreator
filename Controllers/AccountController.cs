using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index() {
			return View();
		}

		[HttpGet]
		public IActionResult CreateAccount() {
			return View();
		}

		// These paramaters are the old way of doing it, once we get connected to a database I or someone else can update them and the method itself
		[HttpPost]
		public IActionResult CreateAccount(string Username, string Password) {
			if (ModelState.IsValid) {
				TempData["Success"] = "Account Created";
			}
			return View();
		}
	}
}
