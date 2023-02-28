using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult CreatorPage()
        {
            ViewData["Title"] = "Character Creator";
            return View();
        }

        [Route("editatt")]
        public IActionResult EditAttributes()
        {
            return View("EditAttributesPartial");
        }
    }
}