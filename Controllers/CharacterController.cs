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
                ch.brawnAtt.Score       = 0;
                ch.finesseAtt.Score     = 0;
                ch.toughAtt.Score       = 0;
                ch.intellectAtt.Score   = 0;
                ch.personAtt.Score      = 0;
                ch.acuityAtt.Score      = 0;

                switch (btnradio0)
                {
                    case "Brawn":       ch.brawnAtt.Score = (AttributeObject.AttributeScore) 1; break;
                    case "Finesse":     ch.finesseAtt.Score = (AttributeObject.AttributeScore) 1; break;
                    case "Toughness":   ch.toughAtt.Score = (AttributeObject.AttributeScore) 1; break;
                    case "Intellect":   ch.intellectAtt.Score = (AttributeObject.AttributeScore) 1; break;
                    case "Personality": ch.personAtt.Score = (AttributeObject.AttributeScore) 1; break;
                    case "Acuity":      ch.acuityAtt.Score = (AttributeObject.AttributeScore) 1; break;
                }

				switch (btnradio1)
				{
					case "Brawn":       ch.brawnAtt.Score = (AttributeObject.AttributeScore)1; break;
					case "Finesse":     ch.finesseAtt.Score = (AttributeObject.AttributeScore)1; break;
					case "Toughness":   ch.toughAtt.Score = (AttributeObject.AttributeScore)1; break;
					case "Intellect":   ch.intellectAtt.Score = (AttributeObject.AttributeScore)1; break;
					case "Personality": ch.personAtt.Score = (AttributeObject.AttributeScore)1; break;
					case "Acuity":      ch.acuityAtt.Score = (AttributeObject.AttributeScore)1; break;
				}

				switch (btnradio2)
				{
					case "Brawn":       ch.brawnAtt.Score = (AttributeObject.AttributeScore) 2; break;
					case "Finesse":     ch.finesseAtt.Score = (AttributeObject.AttributeScore) 2; break;
					case "Toughness":   ch.toughAtt.Score = (AttributeObject.AttributeScore) 2; break;
					case "Intellect":   ch.intellectAtt.Score = (AttributeObject.AttributeScore) 2; break;
					case "Personality": ch.personAtt.Score = (AttributeObject.AttributeScore) 2; break;
					case "Acuity":      ch.acuityAtt.Score = (AttributeObject.AttributeScore) 2; break;
				}
			}

			return View("CharacterStats", ch);
		}

		public IActionResult CharacterAttribute()
        {
            return View(ch);
        }

		public IActionResult CharacterStats()
        {
            return View();
        }
    }
}