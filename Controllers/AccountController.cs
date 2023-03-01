using CharacterCreator.Interfaces;
using CharacterCreator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.LibraryModel;
using System.Security.Claims;

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

        public IActionResult Delete(int ID) {
            if (DAL.getAccount(ID) == null) {
                ModelState.AddModelError("Title", "Profile not found for destruction.");
            }

            if (ModelState.IsValid) {
                DAL.deleteAccount(ID);
                TempData["Success"] = "Profile deleted";
            }
            return RedirectToAction("Profiles", "Account");
        }

        [Authorize]
		[HttpGet]
		public IActionResult CreateProfile() {
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult CreateProfile(Accounts Account) {
			if (ModelState.IsValid) {
				Account.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                DAL.addAccount(Account);
				TempData["Success"] = "Profile Added!";
				return RedirectToAction("Profiles");
			}
			return View();
		}

        [Authorize]
        [HttpGet]
        public IActionResult EditProfile(int ID) {
            if (ID == null) return NotFound();
            Accounts FoundProfile = DAL.getAccount(ID);
            if (FoundProfile == null) return NotFound();

            return View(FoundProfile);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(Accounts Account) {
            if (ModelState.IsValid) {
                DAL.editAccount(Account);
                TempData["Success"] = Account.Title + " updated";
                return RedirectToAction("Profiles", "Account");
            }
            return View();
        }

        [Authorize]
		[HttpGet]
		public IActionResult Profiles() { // Loads all the profiles
			return View(DAL.getAccounts());
		}

		// Updates the profile page with the new values
		[Authorize]
		[HttpPost]
		public IActionResult Profiles(string Bio, string Username, string Email, string Password) { // Once we get a database we can send in an account object to update
			TempData["Success"] = "Profile updated";
			ViewBag.Username = Username;
			ViewBag.Bio = Bio;
			ViewBag.Email = Email;
			ViewBag.Password = Password;
			return View();
		}
	}
}
