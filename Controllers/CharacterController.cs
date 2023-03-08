using Microsoft.AspNetCore.Mvc;
using CharacterCreator.Models;
using CharacterCreator.Controllers.Utility;
using CharacterCreator.Interfaces;
using System.Security.Claims;

namespace CharacterCreator.Controllers
{
	public class CharacterController : Controller
	{
		public static IDataAccessLayer DAL;
		public CharacterController(IDataAccessLayer dal)
		{
			DAL = dal;
		}

		public IActionResult NewCharacter()
		{
			Character ch = new Character();
			ch.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

			DAL.addCharacter(ch);
			return EditCharacter(ch);
		}

		[HttpPost]
		public IActionResult EditCharacter(string id)
		{
			Character ch = DAL.getCharacter(int.Parse(id));
			CharacterManager.Load(ch);

			if (ch != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (ch.brawnAtt == (AttributeScore)1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (ch.toughAtt == (AttributeScore)1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (ch.personAtt == (AttributeScore)1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (ch.brawnAtt == (AttributeScore)1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (ch.toughAtt == (AttributeScore)1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (ch.personAtt == (AttributeScore)1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (ch.brawnAtt == (AttributeScore)2) { TempData["wb1"] = "checked"; got2 = true; break; }
					if (ch.finesseAtt == (AttributeScore)2) { TempData["wf1"] = "checked"; got2 = true; break; }
					if (ch.toughAtt == (AttributeScore)2) { TempData["wt1"] = "checked"; got2 = true; break; }
					if (ch.intellectAtt == (AttributeScore)2) { TempData["wi1"] = "checked"; got2 = true; break; }
					if (ch.personAtt == (AttributeScore)2) { TempData["wp1"] = "checked"; got2 = true; break; }
					if (ch.acuityAtt == (AttributeScore)2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			TempData["sDet"] = "active";
			return View("CharacterCreator", ch);
		}

		public IActionResult DeleteCharacter(string id)
		{
			Character ch = DAL.getCharacter(int.Parse(id));
			if (ch != null) DAL.deleteCharacter(int.Parse(id));

			return RedirectToAction("Characters", "Account");
		}

		public IActionResult EditCharacter(Character ch)
		{
			CharacterManager.Load(ch);
			TempData["sDet"] = "active";
			TempData["sAtt"] = "disabled";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			if (ch != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (ch.brawnAtt == (AttributeScore)1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (ch.toughAtt == (AttributeScore)1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (ch.personAtt == (AttributeScore)1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (ch.brawnAtt == (AttributeScore)1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (ch.toughAtt == (AttributeScore)1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (ch.personAtt == (AttributeScore)1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (ch.brawnAtt == (AttributeScore)2) { TempData["wb1"] = "checked"; got2 = true; break; }
					if (ch.finesseAtt == (AttributeScore)2) { TempData["wf1"] = "checked"; got2 = true; break; }
					if (ch.toughAtt == (AttributeScore)2) { TempData["wt1"] = "checked"; got2 = true; break; }
					if (ch.intellectAtt == (AttributeScore)2) { TempData["wi1"] = "checked"; got2 = true; break; }
					if (ch.personAtt == (AttributeScore)2) { TempData["wp1"] = "checked"; got2 = true; break; }
					if (ch.acuityAtt == (AttributeScore)2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			return View("CharacterCreator", ch);
		}

		public IActionResult EditAttributes(string btnradio0, string btnradio1, string btnradio2)
		{
			if (CharacterManager.character != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (CharacterManager.character.brawnAtt		== (AttributeScore) 1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.finesseAtt	== (AttributeScore) 1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.toughAtt		== (AttributeScore) 1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.intellectAtt == (AttributeScore) 1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.personAtt	== (AttributeScore) 1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.acuityAtt	== (AttributeScore) 1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (CharacterManager.character.brawnAtt		== (AttributeScore) 1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.finesseAtt	== (AttributeScore) 1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.toughAtt		== (AttributeScore) 1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.intellectAtt == (AttributeScore) 1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.personAtt	== (AttributeScore) 1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.acuityAtt	== (AttributeScore) 1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (CharacterManager.character.brawnAtt		== (AttributeScore) 2) { TempData["wb1"] = "checked"; got2 = true;  break;}
					if (CharacterManager.character.finesseAtt	== (AttributeScore) 2) { TempData["wf1"] = "checked"; got2 = true;  break;}
					if (CharacterManager.character.toughAtt		== (AttributeScore) 2) { TempData["wt1"] = "checked"; got2 = true;  break;}
					if (CharacterManager.character.intellectAtt == (AttributeScore) 2) { TempData["wi1"] = "checked"; got2 = true;  break;}
					if (CharacterManager.character.personAtt	== (AttributeScore) 2) { TempData["wp1"] = "checked"; got2 = true;  break;}
					if (CharacterManager.character.acuityAtt	== (AttributeScore) 2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			TempData["sDet"] = "";
			TempData["sAtt"] = "";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			if (Utilities.AnyNull(new string[] { btnradio2, btnradio1, btnradio0 }))
			{
				TempData["ErrorDisplay"] = "You Must Select Two Strong Attributes and One Weak Attribute";
				TempData["sAtt"] = "active";
				return View("CharacterCreator", CharacterManager.character);
			}

			if (Utilities.AnyEqual(btnradio2, btnradio1, btnradio0))
			{
				TempData["ErrorDisplay"] = "Don't Select The Same Attribute Twice";
				TempData["sAtt"] = "active";
				return View("CharacterCreator", CharacterManager.character);
			}
			else
			{
				CharacterManager.character.brawnAtt = 0;
				CharacterManager.character.finesseAtt = 0;
				CharacterManager.character.toughAtt = 0;
				CharacterManager.character.intellectAtt = 0;
				CharacterManager.character.personAtt = 0;
				CharacterManager.character.acuityAtt = 0;

				switch (btnradio0)
				{
					case "Brawn": CharacterManager.character.brawnAtt = (AttributeScore)1; break;
					case "Finesse": CharacterManager.character.finesseAtt = (AttributeScore)1; break;
					case "Toughness": CharacterManager.character.toughAtt = (AttributeScore)1; break;
					case "Intellect": CharacterManager.character.intellectAtt = (AttributeScore)1; break;
					case "Personality": CharacterManager.character.personAtt = (AttributeScore)1; break;
					case "Acuity": CharacterManager.character.acuityAtt = (AttributeScore)1; break;
				}

				switch (btnradio1)
				{
					case "Brawn": CharacterManager.character.brawnAtt = (AttributeScore)1; break;
					case "Finesse": CharacterManager.character.finesseAtt = (AttributeScore)1; break;
					case "Toughness": CharacterManager.character.toughAtt = (AttributeScore)1; break;
					case "Intellect": CharacterManager.character.intellectAtt = (AttributeScore)1; break;
					case "Personality": CharacterManager.character.personAtt = (AttributeScore)1; break;
					case "Acuity": CharacterManager.character.acuityAtt = (AttributeScore)1; break;
				}

				switch (btnradio2)
				{
					case "Brawn": CharacterManager.character.brawnAtt = (AttributeScore)2; break;
					case "Finesse": CharacterManager.character.finesseAtt = (AttributeScore)2; break;
					case "Toughness": CharacterManager.character.toughAtt = (AttributeScore)2; break;
					case "Intellect": CharacterManager.character.intellectAtt = (AttributeScore)2; break;
					case "Personality": CharacterManager.character.personAtt = (AttributeScore)2; break;
					case "Acuity": CharacterManager.character.acuityAtt = (AttributeScore)2; break;
				}
			}

			TempData["sInt"] = "active";

			DAL.editCharacter(CharacterManager.character);

			return View("CharacterCreator", CharacterManager.character);
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
				return View("CharacterCreator", CharacterManager.character);
			}

			CharacterManager.character.Name = name;
			CharacterManager.character.Age = uint.Parse(age);
			CharacterManager.character.Gender = gender;

			if (bioselect != null)
			{
				switch (bioselect)
				{
					default: break;
					case "0":
						CharacterManager.character.Backstory = "You are a child of the old world. You left home at a young age in order to help others find their way in the new world.\n";
						break;
					case "1":
						CharacterManager.character.Backstory = "You grew up in poverty in a shanty-town. You've gone into the wasteland to try and find work.\n";
						break;
					case "2":
						CharacterManager.character.Backstory = "Your parents were murdered by bounty hunters, and you were spared. Now you scour the wasteland for their killers.\n";
						break;
					case "3":
						CharacterManager.character.Backstory = "You saved your town from a gang of criminals, and now you're off looking for more adventure.\n";
						break;
					case "4":
						CharacterManager.character.Backstory = "Life at home was boring, and you're sure there's more for you out there in the wasteland.\n";
						break;

				}
			}

			CharacterManager.character.Backstory += bio;

			TempData["sAtt"] = "active";

			DAL.editCharacter(CharacterManager.character);

			return View("CharacterCreator", CharacterManager.character);
		}

		public IActionResult EditSkillsQualities(string[] skills, string quality)
		{
			TempData["sInt"] = "active";

			DAL.editCharacter(CharacterManager.character);

			return View("CharacterCreator", CharacterManager.character);
		}

		[HttpPost]
		public IActionResult InteractiveSheet(string id)
		{
			TempData["sInt"] = "active";
			Character ch = DAL.getCharacter(int.Parse(id));

			if (ch != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (ch.brawnAtt == (AttributeScore)1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (ch.toughAtt == (AttributeScore)1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (ch.personAtt == (AttributeScore)1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (ch.brawnAtt == (AttributeScore)1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (ch.toughAtt == (AttributeScore)1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (ch.personAtt == (AttributeScore)1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (ch.brawnAtt == (AttributeScore)2) { TempData["wb1"] = "checked"; got2 = true; break; }
					if (ch.finesseAtt == (AttributeScore)2) { TempData["wf1"] = "checked"; got2 = true; break; }
					if (ch.toughAtt == (AttributeScore)2) { TempData["wt1"] = "checked"; got2 = true; break; }
					if (ch.intellectAtt == (AttributeScore)2) { TempData["wi1"] = "checked"; got2 = true; break; }
					if (ch.personAtt == (AttributeScore)2) { TempData["wp1"] = "checked"; got2 = true; break; }
					if (ch.acuityAtt == (AttributeScore)2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			return View("CharacterCreator", ch);
		}
		public IActionResult InteractiveSheet(Character ch)
		{
			if (ch != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (ch.brawnAtt == (AttributeScore)1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (ch.toughAtt == (AttributeScore)1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (ch.personAtt == (AttributeScore)1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (ch.brawnAtt == (AttributeScore)1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (ch.finesseAtt == (AttributeScore)1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (ch.toughAtt == (AttributeScore)1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (ch.intellectAtt == (AttributeScore)1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (ch.personAtt == (AttributeScore)1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (ch.acuityAtt == (AttributeScore)1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (ch.brawnAtt == (AttributeScore)2) { TempData["wb1"] = "checked"; got2 = true; break; }
					if (ch.finesseAtt == (AttributeScore)2) { TempData["wf1"] = "checked"; got2 = true; break; }
					if (ch.toughAtt == (AttributeScore)2) { TempData["wt1"] = "checked"; got2 = true; break; }
					if (ch.intellectAtt == (AttributeScore)2) { TempData["wi1"] = "checked"; got2 = true; break; }
					if (ch.personAtt == (AttributeScore)2) { TempData["wp1"] = "checked"; got2 = true; break; }
					if (ch.acuityAtt == (AttributeScore)2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			return View("CharacterSheet", ch);
		}


		public IActionResult CharacterCreator()
		{
			TempData["sDet"] = "active";
			TempData["sAtt"] = "disabled";
			TempData["sSki"] = "disabled";
			TempData["sInt"] = "disabled";

			if (CharacterManager.character != null)
			{
				bool got0 = false;
				bool got1 = false;
				bool got2 = false;

				while (!got0)
				{
					TempData["sb1"] = "";
					TempData["sf1"] = "";
					TempData["st1"] = "";
					TempData["si1"] = "";
					TempData["sp1"] = "";
					TempData["sa1"] = "";

					if (CharacterManager.character.brawnAtt == (AttributeScore)1) { TempData["sb1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.finesseAtt == (AttributeScore)1) { TempData["sf1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.toughAtt == (AttributeScore)1) { TempData["st1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.intellectAtt == (AttributeScore)1) { TempData["si1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.personAtt == (AttributeScore)1) { TempData["sp1"] = "checked"; got0 = true; break; }
					if (CharacterManager.character.acuityAtt == (AttributeScore)1) { TempData["sa1"] = "checked"; got0 = true; break; }
					got0 = true;
				}

				while (!got1)
				{
					if (CharacterManager.character.brawnAtt == (AttributeScore)1 && TempData["sb1"] != "checked") { TempData["sb2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.finesseAtt == (AttributeScore)1 && TempData["sf1"] != "checked") { TempData["sf2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.toughAtt == (AttributeScore)1 && TempData["st1"] != "checked") { TempData["st2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.intellectAtt == (AttributeScore)1 && TempData["si1"] != "checked") { TempData["si2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.personAtt == (AttributeScore)1 && TempData["sp1"] != "checked") { TempData["sp2"] = "checked"; got1 = true; break; }
					if (CharacterManager.character.acuityAtt == (AttributeScore)1 && TempData["sa1"] != "checked") { TempData["sa2"] = "checked"; got1 = true; break; }
					got1 = true;
				}

				while (!got2)
				{
					if (CharacterManager.character.brawnAtt == (AttributeScore)2) { TempData["wb1"] = "checked"; got2 = true; break; }
					if (CharacterManager.character.finesseAtt == (AttributeScore)2) { TempData["wf1"] = "checked"; got2 = true; break; }
					if (CharacterManager.character.toughAtt == (AttributeScore)2) { TempData["wt1"] = "checked"; got2 = true; break; }
					if (CharacterManager.character.intellectAtt == (AttributeScore)2) { TempData["wi1"] = "checked"; got2 = true; break; }
					if (CharacterManager.character.personAtt == (AttributeScore)2) { TempData["wp1"] = "checked"; got2 = true; break; }
					if (CharacterManager.character.acuityAtt == (AttributeScore)2) { TempData["wa1"] = "checked"; got2 = true; break; }
					got2 = true;
				}
			}

			return View(CharacterManager.character);
		}

		//[Route("MyCharacters/{id?}")]
		//public IActionResult CharacterSheet(int? id)
		//{
		//    
		//    return View("CharacterSheetPartial", ch);
		//}

		//this should create a character pdf located in the wwwroot/Apifiles/ApiOutput
		//Change redirect to action of choice
		public IActionResult printPDF(int charID)
		{
			Character character = DAL.getCharacter(charID);

			API.API.runApiHtml(character, character.Name);
			return InteractiveSheet(character);
		}
	}
}