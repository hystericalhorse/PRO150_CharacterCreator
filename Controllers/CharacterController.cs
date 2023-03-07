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

			TempData["sInt"] = "active";

			return View("CharacterCreator", ch);
		}

		public IActionResult EditDetails(string name, string age, string gender, string bio, string bioselect)
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

			if (bioselect != null)
			{
				switch (bioselect)
				{
					default: break;
					case "0":
						ch.Backstory = "You are a child of the old world. You left home at a young age in order to help others find their way in the new world.\n";
						break;
					case "1":
						ch.Backstory = "You grew up in poverty in a shanty-town. You've gone into the wasteland to try and find work.\n";
						break;
					case "2":
						ch.Backstory = "Your parents were murdered by bounty hunters, and you were spared. Now you scour the wasteland for their killers.\n";
						break;
					case "3":
						ch.Backstory = "You saved your town from a gang of criminals, and now you're off looking for more adventure.\n";
						break;
					case "4":
						ch.Backstory = "Life at home was boring, and you're sure there's more for you out there in the wasteland.\n";
						break;

				}
			}

			ch.Backstory += bio;

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