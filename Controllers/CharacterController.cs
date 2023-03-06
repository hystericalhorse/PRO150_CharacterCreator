using Microsoft.AspNetCore.Mvc;
using CharacterCreator.Models;
using CharacterCreator.Controllers.Utility;

namespace CharacterCreator.Controllers
{
	public class CharacterController : Controller
	{
		static Character ch = new Character();

		public IActionResult EditAttributes(string btnradio0, string btnradio1, string btnradio2)
		{
			TempData["sDet"] = "";
			TempData["sAtt"] = "";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			if (Utilities.AnyNull(new string[] { btnradio2, btnradio1, btnradio0 }))
			{
				TempData["ErrorDisplay"] = "You Must Select Two Strong Attributes and One Weak Attribute";
				TempData["sAtt"] = "active";
				return View("CharacterCreator", ch);
			}

			if (Utilities.AnyEqual(btnradio2, btnradio1, btnradio0))
			{
				TempData["ErrorDisplay"] = "Don't Select The Same Attribute Twice";
				TempData["sAtt"] = "active";
				return View("CharacterCreator", ch);
			}
			else
			{
				ch.brawnAtt = 0;
				ch.finesseAtt = 0;
				ch.toughAtt = 0;
				ch.intellectAtt = 0;
				ch.personAtt = 0;
				ch.acuityAtt = 0;

				switch (btnradio0)
				{
					case "Brawn": ch.brawnAtt = (AttributeScore)1; break;
					case "Finesse": ch.finesseAtt = (AttributeScore)1; break;
					case "Toughness": ch.toughAtt = (AttributeScore)1; break;
					case "Intellect": ch.intellectAtt = (AttributeScore)1; break;
					case "Personality": ch.personAtt = (AttributeScore)1; break;
					case "Acuity": ch.acuityAtt = (AttributeScore)1; break;
				}

				switch (btnradio1)
				{
					case "Brawn": ch.brawnAtt = (AttributeScore)1; break;
					case "Finesse": ch.finesseAtt = (AttributeScore)1; break;
					case "Toughness": ch.toughAtt = (AttributeScore)1; break;
					case "Intellect": ch.intellectAtt = (AttributeScore)1; break;
					case "Personality": ch.personAtt = (AttributeScore)1; break;
					case "Acuity": ch.acuityAtt = (AttributeScore)1; break;
				}

				switch (btnradio2)
				{
					case "Brawn": ch.brawnAtt = (AttributeScore)2; break;
					case "Finesse": ch.finesseAtt = (AttributeScore)2; break;
					case "Toughness": ch.toughAtt = (AttributeScore)2; break;
					case "Intellect": ch.intellectAtt = (AttributeScore)2; break;
					case "Personality": ch.personAtt = (AttributeScore)2; break;
					case "Acuity": ch.acuityAtt = (AttributeScore)2; break;
				}
			}

			TempData["sSki"] = "active";

			return View("CharacterCreator", ch);
		}

		public IActionResult EditDetails(string name, string age, string gender, string bio, string bioSelect)
		{
			TempData["sDet"] = "";
			TempData["sAtt"] = "disabled";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			if (Utilities.AnyNull(new string[]{ name, age, gender }))
			{
				TempData["ErrorDisplay"] = "You Must Specify a Name, Age, and Gender";
				TempData["sDet"] = "active";
				return View("CharacterCreator", ch);
			}

			ch.Name = name;
			ch.Age = uint.Parse(age);
			ch.Gender = gender;

			TempData["sAtt"] = "active";

			return View("CharacterCreator", ch);
		}

		public IActionResult EditSkillsQualities(string[] skills, string quality)
		{
			TempData["sInt"] = "active";



			return View("CharacterCreator", ch);
		}

		public IActionResult InteractiveSheet()
		{
			TempData["sInt"] = "active";



			return View("CharacterCreator", ch);
		}

        public IActionResult CharacterCreator()
		{
			TempData["sDet"] = "active";
			TempData["sAtt"] = "disabled";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			return View(ch);
		}

        //[Route("MyCharacters/{id?}")]
        //public IActionResult CharacterSheet(int? id)
        //{
        //    
        //    return View("CharacterSheetPartial", ch);
        //}
    }
}