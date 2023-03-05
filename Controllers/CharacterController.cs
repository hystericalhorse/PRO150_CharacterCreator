using Microsoft.AspNetCore.Mvc;
using CharacterCreator.Models;
using CharacterCreator.Controllers.Utility;

namespace CharacterCreator.Controllers
{
    public class CharacterController : Controller
    {
		static Character ch = new Character();

		public IActionResult CreatorPage()
        {
            ViewData["Title"] = "Character Creator";
            return View();
        }


        public IActionResult EditAttributes()
        {
            return View("CharacterAttribute", ch);
        }

		[HttpPost]
		public IActionResult EditAttributes(string btnradio0, string btnradio1, string btnradio2)
		{
            if (Utilities.AnyNull(btnradio2, btnradio1, btnradio0))
            {
				TempData["ErrorDisplay"] = "You Must Select Two Strong Attributes and One Weak Attribute";
				return View("CharacterAttribute", ch);
			}

            if (Utilities.AnyEqual(btnradio2, btnradio1, btnradio0))
            {
                TempData["ErrorDisplay"] = "Don't Select The Same Attribute Twice";
				return View("CharacterAttribute", ch);
			}
            else
            {
                ch.brawnAtt       = 0;
                ch.finesseAtt     = 0;
                ch.toughAtt       = 0;
                ch.intellectAtt   = 0;
                ch.personAtt      = 0;
                ch.acuityAtt      = 0;

                switch (btnradio0)
                {
                    case "Brawn":       ch.brawnAtt     = (AttributeScore) 1; break;
                    case "Finesse":     ch.finesseAtt   = (AttributeScore) 1; break;
                    case "Toughness":   ch.toughAtt     = (AttributeScore) 1; break;
                    case "Intellect":   ch.intellectAtt = (AttributeScore) 1; break;
                    case "Personality": ch.personAtt    = (AttributeScore) 1; break;
                    case "Acuity":      ch.acuityAtt    = (AttributeScore) 1; break;
                }

				switch (btnradio1)
				{
					case "Brawn":       ch.brawnAtt     = (AttributeScore) 1; break;
					case "Finesse":     ch.finesseAtt   = (AttributeScore) 1; break;
					case "Toughness":   ch.toughAtt     = (AttributeScore) 1; break;
					case "Intellect":   ch.intellectAtt = (AttributeScore) 1; break;
					case "Personality": ch.personAtt    = (AttributeScore) 1; break;
					case "Acuity":      ch.acuityAtt    = (AttributeScore) 1; break;
				}

				switch (btnradio2)
				{
					case "Brawn":       ch.brawnAtt     = (AttributeScore) 2; break;
					case "Finesse":     ch.finesseAtt   = (AttributeScore) 2; break;
					case "Toughness":   ch.toughAtt     = (AttributeScore) 2; break;
					case "Intellect":   ch.intellectAtt = (AttributeScore) 2; break;
					case "Personality": ch.personAtt    = (AttributeScore) 2; break;
					case "Acuity":      ch.acuityAtt    = (AttributeScore) 2; break;
				}
			}

			return View("CharacterSheetPartial", ch);
		}

		public IActionResult CharacterAttribute()
        {
            return View(ch);
        }

        public IActionResult CharacterCreator() => View(ch);

		public IActionResult CharacterStats()
        {
            return View();
        }

        [Route("character_sheet/{id?}")]
        public IActionResult CharacterSheet(int? id)
        {
            
            return View("CharacterSheetPartial", ch);
        }
    }
}